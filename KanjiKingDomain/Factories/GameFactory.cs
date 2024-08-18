using KanjiKingDomain.Models;
using LanguageExt.Common;

namespace KanjiKingDomain.Factories
{
    public static class GameFactory
    {
        public static Result<Game> CreateGame(GameSettings gameSettings)
        {
            return gameSettings.GameLevel switch
            {
                GameLevel.Easy => new Game(50, new List<int>(), 20, gameSettings.GameType),
                GameLevel.Normal => new Game(100, new List<int>(), 10, gameSettings.GameType),
                GameLevel.Hard => new Game(200, new List<int>(), 5, gameSettings.GameType),
                _ => new Result<Game>(new ArgumentOutOfRangeException())
            };
        }
    }
}
