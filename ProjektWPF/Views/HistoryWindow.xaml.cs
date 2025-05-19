using ProjektWPF.Data;
using System.Linq;
using System.Windows;

namespace ProjektWPF.Views
{
    public partial class HistoryWindow : Window
    {
        public HistoryWindow(ApplicationDbContext db)
        {
            InitializeComponent();
            HistoryList.ItemsSource = db.NoteHistories.OrderByDescending(h => h.ActionDate).ToList();
        }
    }
}
