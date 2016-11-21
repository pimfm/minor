using InfoSupport.BKE.GameAdministration.Domain.Entities;
using InfoSupport.BKE.GameAdministration.Domain.Enums;

namespace InfoSupport.BKE.GameAdministration.Domain.Factories
{
    public class GameFactory
    {
        public Game MakeGame(GameType type)
        {
            switch (type)
            {
                case GameType.TicTacToe:
                    return new 
                default:
                    break;
            }
        }
    }
}