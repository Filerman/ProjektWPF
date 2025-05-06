using System;
using System.Collections.Generic;

namespace ProjektWPF.Models
{
    public abstract class Note
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";

        public DateTime CreationDate { get; set; }
        public DateTime LastModificationDate { get; set; }

        public int FolderId { get; set; }
        public Folder Folder { get; set; }

        public ICollection<NoteKeyword> Keywords { get; set; }
        public ICollection<NoteHistory> History { get; set; }

        public int Length => GetContentLength();

        protected abstract int GetContentLength();
    }
}
