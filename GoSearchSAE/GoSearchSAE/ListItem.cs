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
        private long _size;

        private FileType _fileType;
        private DateTime _lastModified;

        private string _extension;
        private bool isFolder;


        public int id { get => id; set => id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Path { get => _path; set => _path = value; }
        public long Size { get => _size; set => _size = value; }
        public string Extension { get => _extension; set => _extension = value; }
        public bool IsFolder { get => isFolder; set => isFolder = value; }
        public DateTime LastModified { get => _lastModified; set => _lastModified = value; }

        public ListItem(string name, string path)
        {
            this.Name = name;
            this.Path = path;

        }
        public ListItem(string path)
        {
            this.Path = path;
            getDefaultsFromPath();
        }

        public void getDefaultsFromPath(string path = "")
        {
            this.Path = this.Path.Length == 0 ? path : this.Path;
            if (ListHelper.Instance.isValidPath(this.Path))
            {
                DirectoryInfo sd = ListHelper.Instance.readFile(this.Path);
                foreach (FileInfo fi in sd.GetFiles())
                {
                   
                    this.Name = fi.Name;
                    this.Path = fi.DirectoryName;
                    this.Size = fi.Length;
                    this.Extension = fi.Extension;
                    this.LastModified = fi.LastWriteTime;
                }

            }
        }

    }
}
