using ProjektWPF.Data;
using System.Windows;

namespace ProjektWPF.Views
{
    public partial class SearchDialog : Window
    {
        private readonly ApplicationDbContext _db;
        public SearchDialog(ApplicationDbContext db)
        {
            InitializeComponent();
            _db = db;
        }

        private void Search_Click(object s, RoutedEventArgs e)
        {
            // TODO: napisz zapytanie LINQ wg wprowadzonych kryteriów
            MessageBox.Show("Wyniki wyszukania – do zaimplementowania.");
        }
    }
}
