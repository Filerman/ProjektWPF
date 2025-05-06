using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektWPF.Models
{
    public class NoteText : Note
    {
        public string Text { get; set; } = "";

        protected override int GetContentLength()
        {
            return Text?.Length ?? 0;
        }
    }
}

