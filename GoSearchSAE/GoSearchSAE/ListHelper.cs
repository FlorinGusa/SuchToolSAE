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

      
        public DirectoryInfo readFile(string path)
        {
            if (isValidPath(path))
            {
                DirectoryInfo sd = new DirectoryInfo(path);
                return sd;
            }
            return null;
        }

        public void setDefaults(ListView listView)
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

        public void addFolder(string path)
        {
            try
            {
                foreach(string f in Directory.GetFiles(path))
                {
                    ListItem li = new ListItem(path);

                    li.getDefaultsFromPath(path);
                    //TODO: Fix
                    li.Name = f;
                    addItem(li);
                }

                foreach (string d in Directory.GetDirectories(path))
                {
                }
            }catch(Exception e)
            {
                Console.Write(e);
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
