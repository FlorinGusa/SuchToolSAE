using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GoSearchSAE
{
    public class ListItem
    {

        private string _name;
        private string _path;
        private string _size;

        private FileType _fileType;
        private DateTime _lastModified;
        private FileInfo _fileInfo;
        private DirectoryInfo _dirInfo;
        private string _extension;


        public int id { get => id; set => id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Path { get => _path; set => _path = value; }
        public string Size { get => _size; set => _size = value; }
        public string Extension { get => _extension; set => _extension = value; }
        public DateTime LastModified { get => _lastModified; set => _lastModified = value; }
        public FileInfo FileInfo { get => _fileInfo; set => _fileInfo = value; }
        public DirectoryInfo DirInfo { get => _dirInfo; set => _dirInfo = value; }

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

