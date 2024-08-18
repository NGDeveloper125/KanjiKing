using KanjiKingDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanjiKingInterface.Pages.MainMenu
{
    public class MainMenuModel
    {
        public string GameTypeInput = null!;
        public string GameLevelInput = null!;

        public GameType GameType => GetGameType();
        public GameLevel GameLevel => GetGameLevel();
    
        private GameType GetGameType()
        {
            if(GameTypeInput is null) return GameType.Radicals;
            return GameTypeInput switch
            {
                "Radicals" => GameType.Radicals,
                "SingleKanjis" => GameType.SingleKanjis,
                "KanjiWords" => GameType.KanjiWords,
                _ => GameType.Radicals
            };
        }

        private GameLevel GetGameLevel()
        {
            if (GameLevelInput is null) return GameLevel.Easy;
            return GameLevelInput switch
            {
                "Easy" => GameLevel.Easy,
                "Normal" => GameLevel.Normal,
                "Hard" => GameLevel.Hard,
                _ => GameLevel.Easy
            };
        }
    }
}
