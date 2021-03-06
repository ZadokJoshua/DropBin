using DropBinWpf.DataAccess;
using DropBinWpf.Model;
using System;
using System.IO;
using System.Windows;

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

                    var newFolder = new FolderInfo();
                    newFolder.ProjectName = ProjectName;
                    newFolder.NewProjectPath = ProjectPath;

                    using (var db = new FolderInfoContext())
                    {
                        db.FolderInfo.Add(newFolder);
                        db.SaveChanges();
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

        private void Browse_Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            if (dialog.ShowDialog(this).GetValueOrDefault())
            {
                PathTextBox.Text = dialog.SelectedPath;
            }
        }

        private void CheckHistory_Click(object sender, RoutedEventArgs e)
        {
            CheckHistoryWindow checkHistoryWindow = new CheckHistoryWindow();
            checkHistoryWindow.ShowDialog();
        }
    }


}
