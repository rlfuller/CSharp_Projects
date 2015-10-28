using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaseballLeague.Models
{
    public class ListPlayersVM
    {
        public List<SelectListItem> TeamNameSelectList { get; set; }
        public int SelectedValue { get; set; }

        public void CreateTeamList(List<Team> teams)
        {
            TeamNameSelectList = new List<SelectListItem>();

            foreach (var team in teams)
            {
                TeamNameSelectList.Add(
                    new SelectListItem
                    {
                        Text = team.TeamName,
                        Value = team.TeamID.ToString()
                    }
                );
            }
        }

    }
}