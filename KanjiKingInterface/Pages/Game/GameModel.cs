using KanjiKingDomain.Models;
using KanjiKingDomain.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageExt.Common;

namespace KanjiKingInterface.Pages.Game
{
    public class GameModel
    {
        public KanjiKingDomain.Models.Game Game { get; set; } = null!;

        public GameModel(GameType gameType, GameLevel gameLevel)
        {
            GameSettings gameSettings = new GameSettings(gameType, gameLevel);
            Result<KanjiKingDomain.Models.Game> gameResult = GameFactory.CreateGame(gameSettings);
            gameResult.Match(
                    g => Game = g,
                    error => throw new Exception(error.Message));
        }




    }
}
