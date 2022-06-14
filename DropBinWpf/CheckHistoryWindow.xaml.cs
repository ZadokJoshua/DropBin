using DropBinWpf.DataAccess;
using DropBinWpf.Model;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace DropBinWpf
{
    /// <summary>
    /// Interaction logic for CheckHistoryWindow.xaml
    /// </summary>
    public partial class CheckHistoryWindow : Window
    {
        public CheckHistoryWindow()
        {
            InitializeComponent();
            Load();
        }

        public void Load()
        {
            using (var db = new FolderInfoContext())
            {
                myDataGrid.ItemsSource = db.FolderInfo.ToList();
            }
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int Id = (myDataGrid.SelectedItem as FolderInfo).Id;
                using (var db = new FolderInfoContext())
                {
                    var deleteMember = db.FolderInfo.Where(m => m.Id == Id).Single();
                    db.FolderInfo.Remove(deleteMember);
                    db.SaveChanges();
                    myDataGrid.ItemsSource = db.FolderInfo.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                //throw;
            }
        }
    }
}
