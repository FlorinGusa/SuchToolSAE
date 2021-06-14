using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace GoSearchSAE
{
    class ListView
    {
        private string[] _headerTitles;
        public ListBoxItem[] listBoxItems;
        private int _length;


        //Public constants
        public string[] HeaderTitles { get => _headerTitles; set => _headerTitles = value; }
        
        public ListView()
        {
            fillListView();
        }

        void fillListView()
        {

            for(var i = 0; i < _length; i++)
            {
                //ListItem lbi = new ListItem();
                

            }

        }
    }
}
