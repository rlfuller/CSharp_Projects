using BaseballLeague.Data;
using BaseballLeague.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballLeague.Tests
{

    [TestFixture]
    public class PlayerTests
    {
              
        [Test]
        public void GetPlayersTest()
        {
            var repo = new PlayerMockRepo();
            int teamId = 3;
            var result = repo.GetPlayers(teamId);
                        
            Assert.AreEqual(result.Count, 2);
        }

        [Test]
        public void AddPlayerTest()
        {
            var repo = new PlayerMockRepo();
            
            Player player = new Player()
            {
                PlayerID = 8,
                PlayerName = "Lucius Washington",
                JerseyNumber = 25,
                PositionID = 3,
                PreviousYrsBattingAvg = (decimal).900,
                NumYrsPlayed = 12,
                TeamID = 3
            };


            var result = repo.AddPlayer(player);

            Assert.AreEqual(result.PlayerID, 6);
        }

        [Test]
        public void TradePlayerTest()
        {
            var repo = new PlayerMockRepo();
            int playerIdToTrade = 1;
            int teamIdToAdd = 2;

            var result = repo.TradePlayer(playerIdToTrade, teamIdToAdd);

            Assert.AreEqual(result.TeamID, 2);
            Assert.AreEqual(repo.GetPlayers(1).Count(), 0);
        }

        [Test]
        public void RemovePlayerfromTeamTest()
        {
            var repo = new PlayerMockRepo();
            int playerToRemove = 3;

            repo.DeletePlayerFromTeam(playerToRemove);

            var result = repo.GetPlayers(3);

            Assert.AreEqual(result.Count, 1);
            
        }

        /*

       List<Position> GetPositions();
       string GetTeamByID(int id);
       string GetPositionByID(int id);
       */
        [Test]
        public void GetPositionsTest()
        {
            var repo = new PlayerMockRepo();
            var result = repo.GetPositions();

            Assert.AreEqual(result.Count, 9);

        }

        [Test]
        public void GetTeamByIDTest()
        {
            var repo = new PlayerMockRepo();
            int teamID = 1;
            var result = repo.GetTeamByID(teamID);

            Assert.AreEqual(result, "Sweet Baby Jesus");

        }

        [Test]
        public void GetPositionByIDTest()
        {
            var repo = new PlayerMockRepo();
            int positionID = 1;
            var result = repo.GetPositionByID(positionID);

            Assert.AreEqual(result, "P");

        }
    }
}
