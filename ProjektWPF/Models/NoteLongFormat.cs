using System.Collections.Generic;

namespace ProjektWPF.Models
{
    public class NoteLongFormat : Note
    {
        public string Content { get; set; } = "";

        // public byte[]? Image { get; set; } // zapis zdjęcia jako bajty

        protected override int GetContentLength()
        {
            return Content?.Length ?? 0;
        }
    }
}
