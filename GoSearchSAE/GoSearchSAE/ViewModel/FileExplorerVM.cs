using GoSearchSAE.Model;
using GoSearchSAE.ViewModel.Commands;
using GoSearchSAE.ViewModel.Common;
using GoSearchSAE.ViewModel.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GoSearchSAE.ViewModel
{
    public class FileExplorerVM : PropertyNotifier
    {
        private readonly DirectoryService _directoryService;

        public FileExplorerVM()
        {
            _directoryService = new DirectoryService();
            
            SearchCommand = new SearchCommand(this);
            LoadSubfoldersCommand = new LoadSubfoldersCommand(this);
            
            FoundEntries = new ObservableCollection<DirectoryEntry>();
            Folders = new ObservableCollection<DirectoryEntry>();

            SetRootFolders(Folders);
        }

        private DirectoryEntry _selectedFolder;
        public DirectoryEntry SelectedFolder
        {
            get { return _selectedFolder; }
            set
            {
                _selectedFolder = value;
                OnPropertyChanged(nameof(SelectedFolder));
            }
        }

        private string _searchTerm;
        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                _searchTerm = value;
                OnPropertyChanged(nameof(SearchTerm));
            }
        }

        public ObservableCollection<DirectoryEntry> FoundEntries { get; set; }

        public ObservableCollection<DirectoryEntry> Folders { get; set; }

        public SearchCommand SearchCommand { get; set; }

        public LoadSubfoldersCommand LoadSubfoldersCommand { get; set; }

        public void SearchForDirectoryEntries()
        {
            if (SelectedFolder == null)
            {
                return;
            }

            var entries = _directoryService.SearchForDirectoryEntries(SelectedFolder.Path, SearchTerm);
            UpdateFoundEntries(FoundEntries, entries);
        }

        public void ShowDirectoryEntries()
        {
            if (SelectedFolder == null)
            {
                return;
            }
            
            var entries = _directoryService.GetAllEntries(SelectedFolder.Path);
            UpdateFoundEntries(FoundEntries, entries);
        }

        public void LoadSubfolders(DirectoryEntry entry)
        {
            var directories = _directoryService.GetOnlySubDirectories(entry.Path);
            foreach (var directory in directories)
            {
                entry.Children.Add(directory);
            }

            SelectedFolder = entry;
            ShowDirectoryEntries();
        }

        private void UpdateFoundEntries(ObservableCollection<DirectoryEntry> foundEntries, IEnumerable<DirectoryEntry> entries)
        {
            foundEntries.Clear();
            foreach (var entry in entries)
            {
                foundEntries.Add(entry);
            }
        }

        private void SetRootFolders(ObservableCollection<DirectoryEntry> folders)
        {
            var drives = _directoryService.GetDrives();
            foreach (var drive in drives)
            {
                folders.Add(drive);
            }
        }
    }
}