using System.Collections.Generic;

namespace ProjektWPF.Models
{
    public class Folder
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public ICollection<Note> Notes { get; set; }
    }
}
