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
        // create new ListHelper instance
        private static readonly ListHelper instance = new ListHelper();
        // initialize LIST_ITEMS to empty list
        public static List<ListItem> LIST_ITEMS = new List<ListItem> { };
        // initialize the file sizes e.g Bytes, Kilo Bytes, Mega Bytes, Giga Bytes, Tera Bytes
        string[] sizes = { "B", "KB", "MB", "GB", "TB" };


        static ListHelper()
        {
        }

        private ListHelper()
        {
        }

        // create static single instance of ListHelper
        public static ListHelper Instance
        {
            get
            {
                return instance;
            }
        
        }
        // formats the given size with sizes array
        // e.g 0B, 5MB, 3KB ..
        public string formatFileSize(long size)
        {
            if (size == 0)
                return "0" + sizes[0];
            
            long bytes = Math.Abs(size);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(size) * num).ToString() + sizes[place];
        }
        // sets source for ListView population
        public void setItemSource(ListView listView)
        {
            listView.ItemsSource = LIST_ITEMS;
        }
        // adds given entry to LIST_ITEMS list
        public void addItem(ListItem entry)
        {
            LIST_ITEMS.Add(entry);
        }

        public void addItems(ListItem entry, int amt)
        {
            // adds single entry multiple times in the list
            for (var i = 0; i < amt; i++) {
                addItem(entry);    
            }
        }

        public void clearList()
        {
            //listView.Items.Clear();
        }
        // sets up default drive to C
        // gets the files names in current directory and adds them to LIST_ITMES
        // gets the sub directories in current directory and adds them to LIST_ITMES
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
       

    }

}
