using System;
using System.Collections.Generic;
using System.Text;
using System.IO

namespace GoSearchSAE
{
    public class Config
    {
        private void config(object sender, EventArgs e)
        {
            FileStream config_data = new FileStream(@"config\config.txt", FileMode.Open);
            StreamReader config_reader = new StreamReader(config_data);
            string config_text = config_reader.ReadToEnd();
            config_reader.Close();
            config_data.Close();
        }
    }
}
