

using KanjiKingDomain.Factories;
using KanjiKingDomain.Models;
using LanguageExt.Common;

namespace KanjiKingDomain.Services
{
    public static class RoundService
    {
        public static Result<Round> GetNewRound(Game game, List<Round> rounds)
        {
            try
            {
                if (game is not null && rounds is not null)
                {
                    if (rounds.Count > 0)
                    {
                        return RoundFactory.GetNewRound(game.RoundsPlayed, rounds);
                    }
                    return new Result<Round>(new Exception("Empty database"));
                }
                return new Result<Round>(new NullReferenceException());
            }
            catch (Exception ex) 
            {
                return new Result<Round>(ex);
            }
        }
    }
}
