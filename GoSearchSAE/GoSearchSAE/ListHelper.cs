using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace GoSearchSAE
{
    public sealed class ListHelper
    {
        private static readonly ListHelper instance = new ListHelper();

        public static List<ListItem> LIST_ITEMS = new List<ListItem> { };
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

        public void setDefaults(ListView listView)
        {
            listView.ItemsSource = LIST_ITEMS;
        }

        public void addItem(ListItem entry)
        {
            LIST_ITEMS.Add(new ListItem(entry.Name, entry.Path) { });
        }

        public void addItem(string name, string path)
        {
            LIST_ITEMS.Add(new ListItem(name, path) { });
        }

        public void addItems(string name, string path, int amt)
        {
            for (var i = 0; i < amt; i++)
            {
                LIST_ITEMS.Add(new ListItem(name, path) { });
            }
        }

    }
}
