using GoSearchSAE.Model;
using System.Collections.Generic;
using System.IO;

namespace GoSearchSAE.ViewModel.Services
{
    public class DirectoryService
    {
        public IEnumerable<DirectoryEntry> GetDrives()
        {
            var entries = new List<DirectoryEntry>();

            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                entries.Add(GetDirectoryEntry(drive.RootDirectory));
            }

            return entries;
        }

        public IEnumerable<DirectoryEntry> GetAllEntries(string directoryPath)
        {
            var entries = new List<DirectoryEntry>();

            var targetDirectory = new DirectoryInfo(directoryPath);

            FileInfo[] files = targetDirectory.GetFiles();
            foreach (var file in files)
            {
                entries.Add(GetDirectoryEntry(file));
            }

            DirectoryInfo[] directories = targetDirectory.GetDirectories();
            foreach (var directory in directories)
            {
                entries.Add(GetDirectoryEntry(directory));
            }

            return entries;
        }

        public IEnumerable<DirectoryEntry> GetOnlySubDirectories(string directoryPath)
        {
            var entries = new List<DirectoryEntry>();

            var targetDirectory = new DirectoryInfo(directoryPath);

            DirectoryInfo[] directories = targetDirectory.GetDirectories();
            foreach (var directory in directories)
            {
                entries.Add(GetDirectoryEntry(directory));
            }

            return entries;
        }

        public IEnumerable<DirectoryEntry> SearchForDirectoryEntries(string path, string searchPattern)
        {
            var entries = new List<DirectoryEntry>();

            var targetDirectory = new DirectoryInfo(path);
            var options = new EnumerationOptions
            {
                IgnoreInaccessible = true,
                RecurseSubdirectories = true,
            };

            FileInfo[] files = targetDirectory.GetFiles(searchPattern, options);
            foreach (var file in files)
            {
                entries.Add(GetDirectoryEntry(file));
            }

            DirectoryInfo[] directories = targetDirectory.GetDirectories(searchPattern, options);
            foreach (var directory in directories)
            {
                entries.Add(GetDirectoryEntry(directory));
            }

            return entries;
        }

        private DirectoryEntry GetDirectoryEntry(FileInfo fileInfo)
        {
            return new DirectoryEntry
            {
                Name = fileInfo.Name,
                Path = fileInfo.FullName,
                LastModified = fileInfo.LastWriteTime
            };
        }

        private DirectoryEntry GetDirectoryEntry(DirectoryInfo directoryInfo)
        {
            return new DirectoryEntry
            {
                Name = directoryInfo.Name,
                Path = directoryInfo.FullName,
                LastModified = directoryInfo.LastWriteTime
            };
        }
    }
}