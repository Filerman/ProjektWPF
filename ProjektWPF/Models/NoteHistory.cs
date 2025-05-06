using System;

namespace ProjektWPF.Models
{
    public class NoteHistory
    {
        public int Id { get; set; }

        public int NoteId { get; set; }
        public Note Note { get; set; }

        public DateTime ActionDate { get; set; }
        public string Action { get; set; } = ""; // np. "Created", "Edited", "Deleted"
    }
}
