using GoSearchSAE.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GoSearchSAE
{
    public class FileTree : PropertyNotifier
    {

        private object dummyNode = null;
        // 1-argument constructor
        public FileTree(TreeView treeView)
        {
            populateTree(treeView);
        }
        // displays the file in tree View
        void populateTree(TreeView treeView)
        {

            List<string> debugtext = new List<string>();
            //Set up drive tree view
            foreach (string s in Directory.GetLogicalDrives())
            {
                TreeViewItem item = new TreeViewItem();
                item.Header = s;    
                item.Tag = s;
                item.FontWeight = FontWeights.Normal;
                item.Items.Add(dummyNode);
                item.Expanded += new RoutedEventHandler(folderExpanded);
                item.MouseDown += new MouseButtonEventHandler(clickedItem);
                treeView.Items.Add(item);
                debugtext.Add(s);
            
            }


        }

        void clickedItem(object sender, RoutedEventArgs e)
        {
            ListHelper.Instance.clearList();
        }
        // expands the selected folder
        void folderExpanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)sender;
            if (item.Items.Count == 1 && item.Items[0] == dummyNode)
            {
                item.Items.Clear();
                try
                {
                    foreach (string s in Directory.GetDirectories(item.Tag.ToString()))
                    {
                        TreeViewItem subitem = new TreeViewItem();
                        subitem.Header = s.Substring(s.LastIndexOf("\\") + 1);
                        subitem.Tag = s;
                        subitem.FontWeight = FontWeights.Normal;
                        subitem.Items.Add(dummyNode);
                        subitem.Expanded += new RoutedEventHandler(folderExpanded);
                        item.Items.Add(subitem);
                    }
                }
                catch (Exception) { }
            }
        }
    }
}
