
using Domain.Entities;

namespace Domain.Services;

public static class RoundService
{
    public static List<Round> UpdateGameRounds(Game game)
    {
        Round round = new Round(true, game.CurrentRound.RoundId, game.CurrentRound.Kanji, game.CurrentRound.Hiragana, game.CurrentRound.English);
        List<Round> rounds = UpdateRounds(game.Rounds, round);
        return rounds;
    }

    private static List<Round> UpdateRounds(List<Round> rounds, Round round)
    {
        List<Round> updatedRounds = rounds.Where(rnd => rnd.RoundId != round.RoundId).ToList();
        updatedRounds.Add(round);
        return updatedRounds;
    }

    public static Round? GetNextRoundById(List<Round> rounds, Round previousRound)
    {
        List<Round> releventRounds; 
        if(previousRound is not null)
        {
            releventRounds = rounds.Where(rnd => rnd.RoundId != previousRound.RoundId && rnd.IsOver == false).ToList();
        } 
        else
        {
            releventRounds = rounds.Where(rnd => rnd.IsOver == false).ToList();
        }
        Round? newCurrentRound = null; 
        if(releventRounds.Any())
        {
            Random random = new Random();
            newCurrentRound = rounds.Count == 0 ? releventRounds[random.Next(0, rounds.Count)] : releventRounds[0];
        }
        if(newCurrentRound is not null) return newCurrentRound;
    
        newCurrentRound = rounds.FirstOrDefault(rnd => rnd.IsOver == false)!;
        return newCurrentRound;    
    }
}