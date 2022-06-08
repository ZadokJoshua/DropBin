using System.Windows;

namespace DropBinWpf.Model
{
    public class ActionClass
    {
        public static void Operator(string path, string FileName)
        {
            if (Checker.CheckingFolder(path) is true)
            {
                if (Deleter.DeletingOperation(path) is true)
                {
                    ZipClass.ZipFileOperation(path, FileName);
                    MessageBox.Show("Project has been Dropbined", "Superb!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    ZipClass.ZipFileOperation(path, FileName);
                    MessageBox.Show("No Bin or Obj or Both found\nProject has been Dropbined", "Superb!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("NotFoundException: Project not Found", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public static void Operator(string path, string FileName, FolderEnum folderEnum)
        {
            if (Checker.CheckingFolder(path) is true)
            {
                if (Deleter.DeletingOperation(path, folderEnum) is true)
                {
                    ZipClass.ZipFileOperation(path, FileName);
                    MessageBox.Show("Project has been Dropbined", "Superb!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    ZipClass.ZipFileOperation(path, FileName);
                    MessageBox.Show("No Bin or Obj or Both found\nProject has been Dropbined", "Superb!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("NotFoundException: Project not Found");
            }
        }

        public static void Operator(string path, string newPath, string FileName)
        {
            if (Checker.CheckingFolder(path) is true)
            {
                if (Deleter.DeletingOperation(path) is true)
                {
                    ZipClass.ZipFileOperation(path, newPath, FileName);
                    MessageBox.Show("Project has been Dropbined", "Superb!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    ZipClass.ZipFileOperation(path, newPath, FileName);
                    MessageBox.Show("No Bin or Obj or Both found\nProject has been Dropbined", "Superb!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("NotFoundException: Project not Found", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
