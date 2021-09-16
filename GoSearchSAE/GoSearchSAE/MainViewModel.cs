using GoSearchSAE.Util;
using System;
using System.Collections.Generic;
using System.Text;
namespace GoSearchSAE
{
    class MainViewModel : PropertyNotifier
    {
        private ListItem _SelectedItem;
        public ListItem SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
            }
        }
        private List<ListItem> _items;
    }
}