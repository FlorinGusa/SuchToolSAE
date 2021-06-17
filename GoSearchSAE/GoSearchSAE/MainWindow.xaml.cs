using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GoSearchSAE
{

    public partial class MainWindow : Window
    {

        public static ListHelper LIST_HELPER;


        public MainWindow()
        {

            InitializeComponent();
            Initialize();

            
        }


        public void Initialize()
        {

            FileTree ft = new FileTree(treeView);
            //Set up list
            LIST_HELPER = ListHelper.Instance;
            LIST_HELPER.setupDriveInfo();
            LIST_HELPER.setItemSource(listView);
       
        
        }

      
    }





}