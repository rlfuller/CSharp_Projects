using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace DVDLibrary.Models
{
    public class DvdBorrowerDetailVM
    {
        public DVD Dvd { get; set; }
        public List<DVDBorrowerDetail> BorrowerDetails { get; set; }
        public List<Borrower> Borrowers { get; set; }

        public DvdBorrowerDetailVM()
        {
            Dvd = new DVD();
            BorrowerDetails = new List<DVDBorrowerDetail>();
            Borrowers = new List<Borrower>();
        }
    }
}