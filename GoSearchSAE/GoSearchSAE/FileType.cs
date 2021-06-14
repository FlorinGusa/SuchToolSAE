using System;
using System.Collections.Generic;
using System.Text;

namespace GoSearchSAE
{
    class FileType
    {
        string name;
        byte[] size;

        FileType(string name)
        {
            this.name = name;
        }



        FileType getFileType(string fileName)
        {
            FileType file = new FileType(name = fileName);

            return file;
        }
    }
}
