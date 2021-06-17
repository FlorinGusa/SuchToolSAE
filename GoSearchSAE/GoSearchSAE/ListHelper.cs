using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Visualis.Extractor;

namespace GoSearchSAE
{
    public sealed class ListHelper
    {
        private static readonly ListHelper instance = new ListHelper();

        public static List<ListItem> LIST_ITEMS = new List<ListItem> { };
        public static TextExtractorD extractor = new TextExtractorD();
        string[] sizes = { "B", "KB", "MB", "GB", "TB" };


        static ListHelper()
        {
        }

        private ListHelper()
        {
        }


        public static ListHelper Instance
        {
            get
            {
                return instance;
            }
        
        }

        public string formatFileSize(long size)
        {
            if (size == 0)
                return "0" + sizes[0];
            
            long bytes = Math.Abs(size);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(size) * num).ToString() + sizes[place];
        }

        public void setItemSource(ListView listView)
        {
            listView.ItemsSource = LIST_ITEMS;
        }

        public void addItem(ListItem entry)
        {
            LIST_ITEMS.Add(entry);
        }

        public void addItems(ListItem entry, int amt)
        {
            for(var i = 0; i < amt; i++) {
                addItem(entry);    
            }
        }


        public void addItem(string path)
        {
            if (!isValidPath(path)) return;

            ListItem item = new ListItem(path);
            item.getDefaultsFromPath();
            LIST_ITEMS.Add(item);
        }

        public void addItems(string path, int amt)
        {
            for (var i = 0; i < amt; i++)
            {
                addItem(path);
            }
        }

        public void setupDriveInfo()
        {
            DriveInfo driveInfo = new DriveInfo(@"C:\");
            DirectoryInfo dirInfo = driveInfo.RootDirectory;
            
            //Files
            FileInfo[] fileNames = dirInfo.GetFiles("*.*");

            foreach (FileInfo fi in fileNames)
            {
                addItem(new ListItem(fi));
            }

            //Folders
            DirectoryInfo[] dirs = dirInfo.GetDirectories();
            foreach(DirectoryInfo di in dirs)
            {
                addItem(new ListItem(di));
            }
        }
        public bool isValidPath(string path, bool allowRelativePaths = false)
        {
            bool isValid = true;

            try
            {
                string fullPath = Path.GetFullPath(path);

                if (allowRelativePaths)
                {
                    isValid = Path.IsPathRooted(path);
                }
                else
                {
                    string root = Path.GetPathRoot(path);
                    isValid = string.IsNullOrEmpty(root.Trim(new char[] { '\\', '/' })) == false;
                }
            }
            catch (Exception ex)
            {
                isValid = false;
            }

            return isValid;
        }

    }

}
