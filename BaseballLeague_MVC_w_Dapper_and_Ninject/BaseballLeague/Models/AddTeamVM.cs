using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseballLeague.Models
{
    public class AddTeamVM
    {
        public List<Team> TeamList { get; set; }
        public Team NewTeam { get; set; }
    }
}