using InfoSupport.BKE.GameAdministration.Domain.Enums;
using InfoSupport.BKE.GameAdministration.Domain.Entities;
using InfoSupport.BKE.GameAdministration.Domain.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InfoSupport.BKE.GameAdministration.Domain.Test
{
    [TestClass]
    public class GameRoomTest
    {
        [TestMethod]
        public void GameRoomCanBeCreated()
        {
            // Arrange
            Player player = Player.Register("Vaardigheden");
            Game game = GameFactory.MakeGame(GameType.TicTacToe); 

            // Act
            GameRoom room = GameRoom.Create("Chessmatch04", game, player);

            // Assert
            Assert.AreEqual("Chessmatch04", room.Name);
            Assert.AreEqual(GameType.TicTacToe, room.GameType);
            CollectionAssert.Contains(room.Players, player);
        }

        [TestMethod]
        public void GameRoomCanBeJoined()
        {
            // Arrange
            Player initialPlayer = Player.Register("Vaardigheden");
            GameRoom room = GameRoom.Create("Chessmatch04", GameType.TicTacToe, initialPlayer);
            Player joiningPlayer = Player.Register("BestTicTacToePlayerEver");

            // Act
            room.Join(joiningPlayer);

            // Assert
            Assert.AreEqual("Chessmatch04", room.Name);
            Assert.AreEqual(GameType.TicTacToe, room.GameType);
            CollectionAssert.Contains(room.Players, initialPlayer);
            CollectionAssert.Contains(room.Players, joiningPlayer);
        }

        [TestMethod]
        public void GameRoomCanNotBeJoinedWhenMaximumAmountOfPlayersReached()
        {
            // Arrange
            Player initialPlayer = Player.Register("Vaardigheden");
            GameRoom room = GameRoom.Create("Chessmatch04", GameType.TicTacToe, initialPlayer);
            Player joiningPlayer = Player.Register("BestTicTacToePlayerEver");

            // Act
            room.Join(joiningPlayer);

            // Assert
            Assert.AreEqual("Chessmatch04", room.Name);
            Assert.AreEqual(GameType.TicTacToe, room.GameType);
            CollectionAssert.Contains(room.Players, initialPlayer);
            CollectionAssert.Contains(room.Players, joiningPlayer);
        }
    }
}
