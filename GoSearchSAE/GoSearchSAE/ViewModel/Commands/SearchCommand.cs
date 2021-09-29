using System;
using System.Windows.Input;

namespace GoSearchSAE.ViewModel.Commands
{
    public class SearchCommand : ICommand
    {
        public FileExplorerVM ViewModel { get; set; }

        public SearchCommand(FileExplorerVM viewModel)
        {
            ViewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            string searchTerm = parameter as string;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return false;
            }
            return true;
        }

        public void Execute(object parameter)
        {
            ViewModel.SearchForDirectoryEntries();
        }
    }
}
