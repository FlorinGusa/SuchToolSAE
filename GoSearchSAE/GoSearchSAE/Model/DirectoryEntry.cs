using System;
using System.Collections.ObjectModel;

namespace GoSearchSAE.Model
{
    public class DirectoryEntry
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Size { get; set; }
        public DateTime LastModified { get; set; }
        public ObservableCollection<DirectoryEntry> Children { get; set; } = new ObservableCollection<DirectoryEntry>();

        public override string ToString()
        {
            return Path;
        }
    }
}
