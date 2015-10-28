using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using DVDLibrary.Models.Attributes;

namespace DVDLibrary.Models
{
    public class DVD
    {
        public int DVDId { get; set; }

        [LongerLengthCheck]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public string MPAA { get; set; }

        [LengthCheck]
        public string Director { get; set; }

        public int StudioID { get; set; }
    }
}
