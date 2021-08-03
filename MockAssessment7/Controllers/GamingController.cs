using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockAssessment7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockAssessment7.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class GamingController : ControllerBase
    {
        GameDB DB = new GameDB();

        //#1
        //GET: api/gaming/players
        [HttpGet("players")] //this annotation is essentailly a method & can take overloads
        public List<Player> GetPlayers()
        {
            //Players - an endpoint that returns all players.
            return DB.Players;  
        }

        //#2
        //GET: api/gaming/classes
        [HttpGet("classes")]
        public List<PlayerClass> Classes()
        {
            //Classes - an endpoint that returns all PlayerClasses.
            return DB.PlayerClasses;
        }

        //#3
        //GET: api/gaming/minlevel/90
        [HttpGet("minlevel/{level}")]
        public List<Player> PlayersMinLevel(int level)
        {
            //PlayersMinLevel - this endpoint takes in a parameter of int level and returns back all players above or equal to that level

            List<Player> minLevel = new List<Player>();

            foreach (Player player in DB.Players)
            {
                if (player.Level >= level)
                {
                    minLevel.Add(player);
                }
            }

            return minLevel;            
            
        }

        //#4 - google sorting objects in c# by property
        //GET: api/gaming/sortedPlayers
        [HttpGet("sortedPlayers")]
        public List<Player> sortPlayers()
        {
            // This endpoint returns all of the players sorted by their levels.(highest level first)

            List<Player> sortedPlayers = DB.Players.OrderByDescending(x => x.Level).ToList();

            return sortedPlayers;

        }
       



        //5
        // GET: api/gaming/playersofclass/healer
        [HttpGet("playersofclass/{name}")]
        public List<Player> getPlayersByClass(string name)
        {
            List<Player> playersByClass = new List<Player>();

            foreach (Player player in DB.Players)
            {
                if (player.CurrentClass.Name.ToLower() == name.ToLower())
                {
                    playersByClass.Add(player);
                }
            }

            return playersByClass;
        }

        //#6
        //GET: api/gaming/playersoftype/damage
        [HttpGet("playersoftype/{type}")]
        public List<Player> getPlayerByType(string type)
        {
            List<Player> playerByType = new List<Player>();

            foreach (Player player in DB.Players)
            {
                if (player.CurrentClass.Type.ToLower() == type.ToLower())
                {
                    playerByType.Add(player);
                }

            }
            return playerByType;
        }


        //#7
        //GET api/gaming/playerclass
        [HttpGet("playerclass")]
        public List<Player> GetAllPlayerClasses()
        {
            //this endpoint will filter through the Players and return all CurrentClasses (PlayerClass) being used.The returned list should not return duplicates

            List<Player> playerClasses = DB.Players.GroupBy(x => x.CurrentClass).Select(x => x.First()).ToList();

            return playerClasses;

        }
    }

   
}
