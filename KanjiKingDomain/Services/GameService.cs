using KanjiKingDomain.Factories;
using KanjiKingDomain.Models;
using LanguageExt;
using LanguageExt.Common;

namespace KanjiKingDomain.Services;

public class GameService
{
    public static Result<Game> GetNewGame(GameSettings? gameSettings)
    {
        try
        {
            if(gameSettings is not null)
            {
                return GameFactory.CreateGame(gameSettings!);
            }
            return new Result<Game>(new NullReferenceException());
        }
        catch (Exception ex) 
        {
            return new Result<Game>(ex);
        }
    }

    public static Result<bool> IsMoreRounds(Game game)
    {
        try
        {
            if(game is not null)
            {
                return CheckForMoreRounds(game.RoundsLeft, game.MistakesAllowed);
            }
            return new Result<bool>(new NullReferenceException());
        }
        catch (Exception ex) 
        {
            return new Result<bool>(ex);
        }
    }

    private static bool CheckForMoreRounds(int roundsLeft, int mistakesLeft) =>
                        (roundsLeft <= 0 || mistakesLeft <= 0) ? false : true;

}
