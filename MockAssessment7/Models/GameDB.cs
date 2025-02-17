﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockAssessment7.Models
{
    public class GameDB
    {
        public List<Player> Players { get; set; }
        public List<PlayerClass> PlayerClasses { get; set; }
        public GameDB()
        {
            PlayerClasses = new List<PlayerClass>()
            {
                new PlayerClass(0, "Archer", "Damage"),
                new PlayerClass(1, "Healer", "Support"),
                new PlayerClass(2, "Knight", "Tank"),
                new PlayerClass(3, "Wizard", "Damage"),
                new PlayerClass(4, "Thief", "Damage")
            };
            Players = new List<Player>()
            {
                new Player(0,"GrantChirpus",100, this.PlayerClasses[1]),
                new Player(1,"Gamer",75, this.PlayerClasses[0]),
                new Player(2,"Green-Bean-Gaming",75, this.PlayerClasses[2]),
                new Player(3,"Jeffery",80, this.PlayerClasses[0]),
                new Player(4,"FunnyFrog2",90, this.PlayerClasses[3]),
            };
        }
    }
}
