
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

    public static Round? GetNextRoundById(Game game)
    {
        List<Round> releventRounds = GetReleventRounds(game);
        
        Round? newCurrentRound = null; 
        if(releventRounds.Any())
        {
            Random random = new Random();
            int randomIndex = random.Next(0, releventRounds.Count);
            newCurrentRound = releventRounds.Count > 0 ? releventRounds[randomIndex] : releventRounds[0];
        }
        return newCurrentRound; 
    }

    public static List<Round> GetReleventRounds(Game game)
    {
        Group? group = game.Groups.FirstOrDefault(gr => gr.GroupId == game.CurrentGroupId);
        int[] ids = group.SubGroupsIds;
        List<SubGroup> subGroups = new List<SubGroup>();
        foreach(int id in ids)
        {
            SubGroup? s = game.SubGroups.FirstOrDefault(sbg => sbg.SubGroupId == id && (sbg.IsOver == true || sbg.SubGroupId == game.CurrentSubGroupId));
            if(s is not null)
            {
                subGroups.Add(s);
            }
        }
        List<Round> SubGroupsRounds = new List<Round>();
        foreach (var subGroup in subGroups)
        {
            if (subGroup.Rounds != null)
            {
                SubGroupsRounds.AddRange(subGroup.Rounds);
            }
        } 
        int[] SubGroupsRoundsIds = SubGroupsRounds.Select(rnd => rnd.RoundId).ToArray();
        IEnumerable<Round> Rounds = game.Rounds.Where(rnd => SubGroupsRoundsIds.Contains(rnd.RoundId));
        
        List<Round> releventRounds = Rounds.Where(rnd => rnd.RoundId != game.CurrentRound.RoundId && rnd.IsOver == false).ToList();

        return releventRounds.Any() ? releventRounds : releventRounds = Rounds.Where(rnd => rnd.IsOver == false).ToList();
    }
}