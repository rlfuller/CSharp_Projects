using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseballLeague.Models;

namespace BaseballLeague.Data
{
    public class PlayerMockRepo : IPlayerRepo
    {

        public static List<Player> Players = new List<Player>
        {
            new Player()
            {
                PlayerID = 1,
                PlayerName = "Ricky Bobby",
                JerseyNumber = 26,
                PositionID = 1,
                PreviousYrsBattingAvg = (decimal).75,
                NumYrsPlayed = 15,
                TeamID = 1
            },
            new Player()
            {
                PlayerID = 2,
                PlayerName = "Cal Naughton Jr.",
                JerseyNumber = 2,
                PositionID = 1,
                PreviousYrsBattingAvg = (decimal).60,
                NumYrsPlayed = 15,
                TeamID = 2
            },
            new Player()
            {
                PlayerID = 3,
                PlayerName = "Walker",
                JerseyNumber = 7,
                PositionID = 1,
                PreviousYrsBattingAvg = (decimal).15,
                NumYrsPlayed = 3,
                TeamID = 3
            },
             new Player()
            {
                PlayerID = 4,
                PlayerName = "Texas Ranger",
                JerseyNumber = 8,
                PositionID = 2,
                PreviousYrsBattingAvg = (decimal).25,
                NumYrsPlayed = 5,
                TeamID = 3
            },
              new Player()
            {
                PlayerID = 5,
                PlayerName = "Jean Girard",
                JerseyNumber = 1,
                PositionID = 1,
                PreviousYrsBattingAvg = (decimal).85,
                NumYrsPlayed = 14,
                TeamID = 4
            }
        };

        public static List<Team> Teams = new List<Team>()
        {
            new Team() {TeamID = 1, TeamName = "Sweet Baby Jesus", ManagerName = "Ricky Bobby" },
            new Team() {TeamID = 2, TeamName = "Tuxedo T Shirts", ManagerName = "Cal Naughton Jr." },
            new Team() {TeamID = 3, TeamName = "Death By Spider Monkey", ManagerName = "Walker & Texas Ranger" },
            new Team() {TeamID = 4, TeamName = "I Love Crepes", ManagerName = "Jean Girard" }           
        };

        public static List<League> Leagues = new List<League>()
        {
            new League() {LeagueID = 1, LeagueName = "Shake N' Bake" },
            new League() {LeagueID = 2, LeagueName = "Some Other League" }
        };

        public static List<Position> Positions = new List<Position>()
        {
            new Position() {PositionID = 1, PositionName = "P" },
            new Position() {PositionID = 2, PositionName = "C" },
            new Position() {PositionID = 3, PositionName = "1B" },
            new Position() {PositionID = 4, PositionName = "2B" },
            new Position() {PositionID = 5, PositionName = "3B" },
            new Position() {PositionID = 6, PositionName = "SS" },
            new Position() {PositionID = 7, PositionName = "LF" },
            new Position() {PositionID = 8, PositionName = "RF" },
            new Position() {PositionID = 9, PositionName = "CF" }

        };

        public static List<LeagueTeamDetail> LeagueTeamDetails = new List<LeagueTeamDetail>()
        {
            new LeagueTeamDetail() {LeagueID = 1, TeamID = 1 },
            new LeagueTeamDetail() {LeagueID = 1, TeamID = 2 },
            new LeagueTeamDetail() {LeagueID = 1, TeamID = 3 },
            new LeagueTeamDetail() {LeagueID = 1, TeamID = 4 }

        };
        public Player AddPlayer(Player player)
        {
            int results = Players.Max(p => p.PlayerID);
            results++;
            player.PlayerID = results;

            Players.Add(player);
            return player;
        }

        public List<Player> GetPlayers(int teamId)
        {

           var results = from player in Players
                          where player.TeamID == teamId
                          select player;

            return results.ToList();

        }

        public void DeletePlayerFromTeam(int playerId)
        {
            
            var playerToRemove = (from player in Players
                             where player.PlayerID == playerId
                             select player).FirstOrDefault();
            
            Players.Remove(playerToRemove);
        }

       

        public string GetPositionByID(int id)
        {
            var positionName = (from position in Positions
                            where position.PositionID == id
                            select position.PositionName).FirstOrDefault();

            return positionName;
        }

        public List<Position> GetPositions()
        {
            return Positions;
        }

        public string GetTeamByID(int id)
        {
            var teamName = (from team in Teams
                                where team.TeamID == id
                                select team.TeamName).FirstOrDefault();

            return teamName;
        }

        public Player TradePlayer(int playerId, int teamId)
        {
            var indexOfPlayerToTrade = Players.FindIndex(p => p.PlayerID == playerId);

            Players[indexOfPlayerToTrade].TeamID = teamId;

            return Players[indexOfPlayerToTrade];
        }
    }
}
