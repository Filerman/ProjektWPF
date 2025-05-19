using ProjektWPF.Data;
using ProjektWPF.Models;
using System.Linq;
using System.Windows;

namespace ProjektWPF.Views
{
    public partial class FolderDialog : Window
    {
        private readonly ApplicationDbContext _db;
        public FolderDialog(ApplicationDbContext db)
        {
            InitializeComponent();
            _db = db;
            Refresh();
        }

        private void Refresh() => FolderList.ItemsSource = _db.Folders.ToList();

        private void Add_Click(object s, RoutedEventArgs e)
        {
            var name = Microsoft.VisualBasic.Interaction.InputBox("Nazwa folderu:", "Nowy folder");
            if (!string.IsNullOrWhiteSpace(name))
            {
                _db.Folders.Add(new Folder { Name = name.Trim() });
                _db.SaveChanges();
                Refresh();
            }
        }

        private void Rename_Click(object s, RoutedEventArgs e) { /* TODO */ }
        private void Delete_Click(object s, RoutedEventArgs e) { /* TODO */ }
    }
}
