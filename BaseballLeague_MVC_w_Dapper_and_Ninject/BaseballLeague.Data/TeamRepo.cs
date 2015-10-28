using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseballLeague.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BaseballLeague.Data.Config;
using Dapper;


namespace BaseballLeague.Data
{
    public class TeamRepo : ITeamRepo
    {
        public List<Team> GetTeams(int leagueId)
        {
            var results = new List<Team>();
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var p = new DynamicParameters();
                p.Add("LeagueID", leagueId);
                results = cn.Query<Team>("SELECT * FROM Teams t INNER JOIN LeagueTeamDetails l ON t.teamID = l.teamID WHERE LeagueID = @LeagueID", p).ToList();
            }
            return results;
        }

        public List<Team> GetTeams()
        {
            var results = new List<Team>();
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                results = cn.Query<Team>("SELECT * FROM Teams").ToList();
            }
            return results;
        }

        public int AddTeam(Team team)
        {
            int teamId;

            using (var connection = new SqlConnection(Settings.ConnectionString))
            {
                var command = new SqlCommand();
                command.CommandText = "SP_AddTeam";
                command.CommandType = CommandType.StoredProcedure;

                var outputParam = new SqlParameter("@TeamID", SqlDbType.Int) { Direction = ParameterDirection.Output };

                command.Connection = connection;
                command.Parameters.AddWithValue("@TeamName", team.TeamName);
                command.Parameters.AddWithValue("@ManagerName", team.ManagerName);
                command.Parameters.Add(outputParam);
                connection.Open();

                command.ExecuteNonQuery();

                teamId = (int)outputParam.Value;
            }

            return teamId;
        }

        public void AddLeagueTeamDetails(int teamId, int leagueId)
        {
            using (var connection = new SqlConnection(Settings.ConnectionString))
            {
                var command = new SqlCommand();
                command.CommandText = "SP_AddLeagueTeamDetails";
                command.CommandType = CommandType.StoredProcedure;

                command.Connection = connection;
                command.Parameters.AddWithValue("@TeamID", teamId);
                command.Parameters.AddWithValue("@LeagueID", leagueId);

                connection.Open();

                command.ExecuteNonQuery();

            }
        }
    }
}
