using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballLeague.Models
{
    public interface ITeamRepo
    {
        List<Team> GetTeams(int leagueId);
        List<Team> GetTeams();
        int AddTeam(Team team);
        void AddLeagueTeamDetails(int teamId, int leagueId);
    }
}
