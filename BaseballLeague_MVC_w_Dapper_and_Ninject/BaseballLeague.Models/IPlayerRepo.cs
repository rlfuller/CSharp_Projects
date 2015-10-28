using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballLeague.Models
{
    public interface IPlayerRepo
    {
        List<Player> GetPlayers(int teamId);
        Player AddPlayer(Player player);
        Player TradePlayer(int playerId, int teamId);
        void DeletePlayerFromTeam(int playerId);
        List<Position> GetPositions();
        string GetTeamByID(int id);
        string GetPositionByID(int id);
    }
}
