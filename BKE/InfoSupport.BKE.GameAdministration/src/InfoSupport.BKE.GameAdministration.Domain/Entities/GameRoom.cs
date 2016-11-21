using System;
using System.Collections;
using InfoSupport.BKE.GameAdministration.Domain.Enums;
using System.Collections.Generic;

namespace InfoSupport.BKE.GameAdministration.Domain.Entities
{
    public class GameRoom
    {
        public GameType GameType { get; set; }
        public string Name { get; set; }
        public List<Player> Players { get; set; }

        public GameRoom(string roomName, GameType gameType, Player initialPlayer)
        {
            Name = roomName;
            GameType = gameType;
            Players = new List<Player>() { initialPlayer };
        }

        public static GameRoom Create(string roomName, GameType gameType, Player initialPlayer)
        {
            return new GameRoom(roomName, gameType, initialPlayer);
        }

        public void Join(Player joiningPlayer)
        {
            Players.Add(joiningPlayer);
        }
    }
}