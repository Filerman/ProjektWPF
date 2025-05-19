using ProjektWPF.Data;
using ProjektWPF.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace ProjektWPF.Views
{
    public partial class NoteEditorWindow : Window
    {
        private readonly ApplicationDbContext _db;
        private readonly Note _note;
        private readonly NoteType _type;

        public NoteEditorWindow(NoteType type, ApplicationDbContext db, Note? existing = null)
        {
            InitializeComponent();

            _type = type;
            _db = db;
            _note = existing ?? CreateEmpty(type);

            TitleBox.Text = _note.Title;

            BuildEditor();
        }

        private Note CreateEmpty(NoteType t) => t switch
        {
            NoteType.Text => new NoteText(),
            NoteType.LongFormat => new NoteLongFormat(),
            NoteType.CheckList => new NoteCheckList { Items = [] },
            _ => throw new()
        };

        private void BuildEditor()
        {
            switch (_type)
            {
                case NoteType.Text:
                    EditorHost.Content = new TextBox
                    {
                        AcceptsReturn = true,
                        TextWrapping = TextWrapping.Wrap,
                        VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                        Text = (_note as NoteText)!.Text
                    };
                    break;

                case NoteType.LongFormat:
                    EditorHost.Content = new TextBox
                    {
                        AcceptsReturn = true,
                        TextWrapping = TextWrapping.Wrap,
                        VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                        Text = (_note as NoteLongFormat)!.Content
                    };
                    break;

                case NoteType.CheckList:
                    EditorHost.Content = new ListBox
                    {
                        ItemsSource = new ObservableCollection<CheckListItem>((_note as NoteCheckList)!.Items ?? [])
                    };
                    break;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            _note.Title = TitleBox.Text;

            // TODO: przenieś dane z kontrolek do modelu (Text, Content, Items…)

            if (_note.Id == 0) _db.Notes.Add(_note);
            _db.SaveChanges();
            DialogResult = true;
        }
    }
}
