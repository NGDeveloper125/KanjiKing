using Domain.Entities;
using Domain.Extensions;
namespace Domain.Services;

public static class GamePageService
{
    public static Result GetNewGameByType(GameType gameType, List<GameData>? gamesData)
    {
        try
        {
            if(gamesData is null || gamesData.Count == 0) 
                return new Result(false, new FailResult(false, "the games data is null or emtpy!"));
        
            GameData gameData = gamesData.FirstOrDefault(gamedata => gamedata.GameType == gameType.ToString())!;
            Game game = gameData.ConvertGamaDataToGame()!;

            return new Result(true, game);
        }
        catch(Exception ex)
        {
            return new Result(false, new FailResult(false, $"Fail to get new game by type: {ex.Message}"));
        }
    }

    public static Result GetNextRound(bool rightAnswer, Game game)
    {
        if(rightAnswer)
        {
            List<Round> updatedRounds = RoundService.UpdateGameRounds(game);
            game = game.UpdateGame(updatedRounds); 
        }
        Round? round = RoundService.GetNextRoundById(game.Rounds, game.CurrentRound);
        if(round is not null) return new Result(true, game.UpdateGame(round));

        int previousSubGroupId = game.CurrentSubGroupId;
        game = SubGroupService.GetNextSubGroup(game);
        if(game.CurrentSubGroupId != previousSubGroupId) 
        {
            round = RoundService.GetNextRoundById(game.Rounds, game.CurrentRound);
            return  new Result(true, game.UpdateGame(round!));
        }

        game = GroupService.GetNextGroup(game);
        if(!game.IsOver)
        {
            round = RoundService.GetNextRoundById(game.Rounds, game.CurrentRound);
            return  new Result(true, game.UpdateGame(round!));
        }
        return new Result(true, game);
    }
}
