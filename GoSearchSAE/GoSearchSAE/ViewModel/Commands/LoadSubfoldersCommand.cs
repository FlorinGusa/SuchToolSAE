using GoSearchSAE.Model;
using System;
using System.Windows;
using System.Windows.Input;

namespace GoSearchSAE.ViewModel.Commands
{
    public class LoadSubfoldersCommand : ICommand
    {
        public FileExplorerVM ViewModel { get; set; }

        public LoadSubfoldersCommand(FileExplorerVM viewModel)
        {
            ViewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var folder = (parameter as RoutedPropertyChangedEventArgs<object>).NewValue as DirectoryEntry;
            ViewModel.LoadSubfolders(folder);
        }
    }
}
