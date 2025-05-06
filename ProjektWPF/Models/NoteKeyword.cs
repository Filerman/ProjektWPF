namespace ProjektWPF.Models
{
    public class NoteKeyword
    {
        public int Id { get; set; }
        public string Keyword { get; set; } = "";

        public int NoteId { get; set; }
        public Note Note { get; set; }
    }
}
