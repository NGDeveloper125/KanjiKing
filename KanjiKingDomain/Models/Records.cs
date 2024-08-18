using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanjiKingDomain.Models
{
    public record GameSettings(GameType GameType, GameLevel GameLevel);
    public record Game(int RoundsLeft, List<int> RoundsPlayed, int MistakesAllowed, GameType GameType);
    public record Round(int Id, string Kanji, string Hiragana, string English, string Sound);
}
