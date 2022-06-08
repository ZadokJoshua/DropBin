using DropBinWpf.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
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

namespace DropBinWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string ProjectPath;

        public MainWindow()
        {
            InitializeComponent();
        }



        private void Zip_Project_Button_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(PathTextBox.Text))
            {
                MessageBox.Show("Please enter a File Path", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    ProjectPath = PathTextBox.Text.ToString();
                    string ProjectName = new DirectoryInfo(ProjectPath).Name;

                    if (!String.IsNullOrEmpty(RenameTextBox.Text))
                    {
                        ProjectName = RenameTextBox.Text.ToString();
                    }

                    if (Bin_Check_Box.IsChecked == false && Obj_Check_Box.IsChecked == true)
                    {
                        ActionClass.Operator(ProjectPath, ProjectName, FolderEnum.Obj);
                    }
                    else if (Bin_Check_Box.IsChecked == true && Obj_Check_Box.IsChecked == false)
                    {
                        ActionClass.Operator(ProjectPath, ProjectName, FolderEnum.Bin);
                    }
                    else
                    {
                        ActionClass.Operator(ProjectPath, ProjectName);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Reset_Button_Click(object sender, RoutedEventArgs e)
        {
            RenameTextBox.Clear();
            PathTextBox.Clear();
            Obj_Check_Box.IsChecked = false;
            Bin_Check_Box.IsChecked = false;
        }
    }


}
