using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace GoSearchSAE
{
    class ListView
    {
        private string[] _headerTitles;
        private List<ListItem> listBoxItems;
        private int _length;
        private ListBox _listBox;


        //Public constants
        public string[] HeaderTitles { get => _headerTitles; set => _headerTitles = value; }

        public ListView()
        {

            _length = 10;
            createItems();
            createListBox();
        }

        void createListBox()
        {
            _listBox = new ListBox();
            _listBox.ItemsSource = listBoxItems;
            
        }
       

        void bindListBox()
        {


        }
    void createItems()
        {
            //Datenbank 18,7mb
            for(var i = 0; i < _length; i++)
            {
                var lbi = new ListItem(i.ToString(), i.ToString());
               // listBoxItems.Add(lbi);
            }

        }
    }
}
