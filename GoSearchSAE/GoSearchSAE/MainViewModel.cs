using GoSearchSAE.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
namespace GoSearchSAE
{
    class MainViewModel : PropertyNotifier
    {
        public Command ShowInExplorerCommand { get; }

        private Command _filterElementsCommand;
        public Command FilterElementsCommand => _filterElementsCommand ??= new Command(o => ExecuteFiltering());

        private void ExecuteFiltering()
        {
            var ha = SearchText;
            //throw new NotImplementedException();
        }

        public MainViewModel()
        {
            ShowInExplorerCommand = new Command(ShowInExplorer);
        }

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
        public List<ListItem> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged();
            }

        }

        //public ObservableCollection<ListItem> ObservableItems

        private string _searchText;

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
            }
        }

        void ShowInExplorer(object param)
        {
            if (SelectedItem == null)
                return;
           
            string path = Path.Combine(SelectedItem.Path, SelectedItem.Name);
            Process.Start("explorer.exe", "/n, /select, \"" + path + "\"");
        }


    }
}