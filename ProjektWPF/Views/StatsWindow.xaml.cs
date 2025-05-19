using ProjektWPF.Data;
using System.Linq;
using System.Windows;

namespace ProjektWPF.Views
{
    public partial class StatsWindow : Window
    {
        public StatsWindow(ApplicationDbContext db)
        {
            InitializeComponent();

            var stats =
                db.Notes
                   .AsEnumerable()
                   .GroupBy(n => n.GetType().Name)
                   .Select(g => new
                   {
                       Type = g.Key,
                       Count = g.Count(),
                       Length = g.Sum(n => n.Length)
                   })
                   .ToList();

            StatsList.ItemsSource = stats;
        }
    }
}
