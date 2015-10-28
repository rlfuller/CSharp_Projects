using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseballLeague.Models
{
    public class AddPlayerSuccessVM
    {
        public Player PlayerToAdd { get; set; }
        public string Position { get; set; }
        public string Team { get; set; }
    }
}