using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVDLibrary.Models
{
    public class DVDDetailVM
    {
        public DVD Dvd { get; set; }
        public string StudioDescription { get; set; } 
        public List<string> ActorNames { get; set; } 

        public DVDDetailVM()
        {
            Dvd = new DVD();
            StudioDescription = "";
            ActorNames = new List<string>();
        }
    }
}