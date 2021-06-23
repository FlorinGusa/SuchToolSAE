using GoSearchSAE.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GoSearchSAE
{
    [Serializable]
    public class ListItem : PropertyNotifier
    {

        private string _name;
        private string _path;
        private string _size;

        private DateTime _lastModified;
        private FileInfo _fileInfo;
        private DirectoryInfo _dirInfo;
        private string _extension;

        // gets and sets the _name
        public string Name { get => _name; set => _name = value; }
        // gets and sets the _path
        public string Path { get => _path; set => _path = value; }

        // gets and sets the _size
        public string Size { get => _size; set => _size = value; }
        // gets and sets the _extension
        public string Extension { get => _extension; set => _extension = value; }
        // gets and sets the _lastModified
        public DateTime LastModified { get => _lastModified; set => _lastModified = value; }
        // gets and sets the _fileInfo
        public FileInfo FileInfo { get => _fileInfo; set => _fileInfo = value; }
        // gets and sets the _dirInfo
        public DirectoryInfo DirInfo { get => _dirInfo; set => _dirInfo = value; }

        // lists the files from given path
        public ListItem(string path)
        {
            _fileInfo = new FileInfo(this.Path);
            getDefaultsFromPath();
        }

        //Folders
        public ListItem(DirectoryInfo dirInfo)
        {
            _dirInfo = dirInfo;
            setFolderDefaults();
        }

        public ListItem(FileInfo info)
        {
            _fileInfo = info;
            getDefaultsFromPath();
        }
        // sets defauls values for folder( name, path, lastModified)
        public void setFolderDefaults()
        {
            this.Name = _dirInfo.Name;
            this.Path = _dirInfo.FullName;   
            this.LastModified = _dirInfo.LastWriteTime;
        }

        public void getDefaultsFromPath()
        {
            this.Name = _fileInfo.Name;
            this.Path = _fileInfo.FullName;
            this.Size = ListHelper.Instance.formatFileSize(_fileInfo.Length);
            this.LastModified = _fileInfo.LastWriteTime;
        }

       
    }

}

