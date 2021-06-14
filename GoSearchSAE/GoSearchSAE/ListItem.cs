using System;
using System.Collections.Generic;
using System.Text;

namespace GoSearchSAE
{
    class ListItem
    {

        private string _name;
        private string _path;
        private byte[] _size;
        private string[] tags;

        public int id { get => id; set => id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Path { get => _path; set => _path = value; }
        public byte[] Size { get => _size; set => _size = value; }


        public ListItem(string name, string path)
        {


        }


    }
}
