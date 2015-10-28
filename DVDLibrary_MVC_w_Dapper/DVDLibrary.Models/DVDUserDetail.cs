using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models
{
    public class DVDUserDetail
    {
        public int UserNoteId { get; set; }
        public int DVDId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string UserNotes { get; set; }
    }
}
