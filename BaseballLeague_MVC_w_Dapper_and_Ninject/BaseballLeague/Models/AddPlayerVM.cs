using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaseballLeague.Models
{
    public class AddPlayerVM
    {
        public Player PlayerToAdd { get; set; }

        public List<SelectListItem> TeamNameSelectList { get; set; }
        public int TeamSelectedValue { get; set; }

        public List<SelectListItem> PositionSelectList { get; set; }
        public int PositionSelectedValue { get; set; }

        public AddPlayerVM()
        {
            PlayerToAdd = new Player();
            TeamNameSelectList = new List<SelectListItem>();
            PositionSelectList = new List<SelectListItem>();
        }

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

        public void CreatePositionList(List<Position> positions)
        {
            PositionSelectList = new List<SelectListItem>();

            foreach (var position in positions)
            {
                PositionSelectList.Add(
                    new SelectListItem
                    {
                        Text = position.PositionName,
                        Value = position.PositionID.ToString()
                    }
                );
            }
        }
    }
}