using ProjektWPF.Models;
using System.Printing;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Xps;

namespace ProjektWPF.Views
{
    public partial class PrintPreviewWindow : Window
    {
        public PrintPreviewWindow(Note note)
        {
            InitializeComponent();

            // TODO: skonwertuj notatkę do FlowDocument i wyświetl
            Viewer.Document = new FlowDocument(new Paragraph(new Run(note.Title + "\n\nPodgląd do zaimplementowania…")));
        }
    }
}
