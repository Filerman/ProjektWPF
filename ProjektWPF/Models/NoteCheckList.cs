using System.Collections.Generic;
using System.Linq;

namespace ProjektWPF.Models
{
    public class NoteCheckList : Note
    {
        public ICollection<CheckListItem> Items { get; set; }

        protected override int GetContentLength()
        {
            return Items?.Sum(i => i.Text.Length) ?? 0;
        }
    }

    public class CheckListItem
    {
        public int Id { get; set; }
        public string Text { get; set; } = "";
        public bool IsDone { get; set; }

        public int NoteCheckListId { get; set; }
        public NoteCheckList NoteCheckList { get; set; }
    }
}
