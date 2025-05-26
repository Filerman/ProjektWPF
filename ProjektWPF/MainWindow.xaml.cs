using ProjektWPF.Data;
using ProjektWPF.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace ProjektWPF
{
    public partial class MainWindow : Window
    {
        private readonly ApplicationDbContext _db;
        public ObservableCollection<Folder> Folders { get; } = new();
        public ObservableCollection<Note> Notes { get; } = new();

        public MainWindow()
        {
            InitializeComponent();

            _db = new DesignTimeDbContextFactory().CreateDbContext([]);

            FoldersTree.ItemsSource = Folders;
            NotesList.ItemsSource = Notes;

            LoadFolders();
        }

        #region Ładowanie
        private void LoadFolders()
        {
            Folders.Clear();
            //foreach (var f in _db.Folders)
                //Folders.Add(f);
        }
        private void LoadNotes(int folderId)
        {
            Notes.Clear();
            foreach (var n in _db.Notes.Where(n => n.FolderId == folderId))
                Notes.Add(n);
        }
        #endregion

        #region Zdarzenia UI
        private void FoldersTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is Folder f) LoadNotes(f.Id);
        }

        private void NotesList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //PreviewHost.Content = NotesList.SelectedItem;
        }
        #endregion

        #region Menu / Toolbar
        private void NewTextNote_Click(object s, RoutedEventArgs e) => OpenEditor(NoteType.Text);
        private void NewChecklistNote_Click(object s, RoutedEventArgs e) => OpenEditor(NoteType.CheckList);
        private void NewLongNote_Click(object s, RoutedEventArgs e) => OpenEditor(NoteType.LongFormat);

        private void OpenEditor(NoteType type, Note? existing = null)
        {
            var wnd = new Views.NoteEditorWindow(type, _db, existing);
            if (wnd.ShowDialog() == true)
            {
                LoadFolders();
                if (FoldersTree.SelectedItem is Folder f) LoadNotes(f.Id);
            }
        }

        private void ManageFolders_Click(object s, RoutedEventArgs e)
        {
            new Views.FolderDialog(_db).ShowDialog();
            LoadFolders();
        }
        private void Search_Click(object s, RoutedEventArgs e) => new Views.SearchDialog(_db).ShowDialog();
        private void History_Click(object s, RoutedEventArgs e) => new Views.HistoryWindow(_db).ShowDialog();
        private void Stats_Click(object s, RoutedEventArgs e) => new Views.StatsWindow(_db).ShowDialog();

        private void Print_Click(object s, RoutedEventArgs e)
        {
            if (NotesList.SelectedItem is Note n)
                new Views.PrintPreviewWindow(n).ShowDialog();
        }
        private void Exit_Click(object s, RoutedEventArgs e) => Close();
        #endregion
    }

    public enum NoteType { Text, CheckList, LongFormat }
}
