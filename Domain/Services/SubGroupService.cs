using Domain.Entities;
using Domain.Extensions;

namespace Domain.Services;

public static class SubGroupService
{
    public static Game GetNextSubGroup(Game game)
    {
        game = UpdateSubGroups(game);
        List<SubGroup> subGroupsOfCurrentGroup = GetSubGroupsByGroupId(game, game.CurrentGroupId);
        SubGroup subGroup = subGroupsOfCurrentGroup.FirstOrDefault(sbgr => sbgr.SubGroupId != game.CurrentSubGroupId && sbgr.IsOver == false)!;
        if(subGroup is not null)
        {
            List<Round> updatedRounds = new List<Round>();
            foreach(Round round in game.Rounds)
            {
                Round newRound = new Round(false, round.RoundId, round.Kanji, round.Hiragana, round.English);
            }
            updatedRounds.AddRange(subGroup.Rounds);
            return game.UpdateGame(subGroup);
        }
        else
        {
            return game;
        }
    }
    private static Game UpdateSubGroups(Game game)
    {
        SubGroup updatedSubGroup = new SubGroup(true, game.CurrentSubGroupId, GetSubGroupRoundsById(game, game.CurrentSubGroupId));
        List<SubGroup> updatedSubGroups = game.SubGroups.Where(sg => sg.SubGroupId != updatedSubGroup.SubGroupId).ToList();
        updatedSubGroups.Add(updatedSubGroup);
        return game.UpdateGame(updatedSubGroups);
    }
    public static List<Round> GetSubGroupRoundsById(Game game, int id)
    {
        SubGroup subGroup = game.SubGroups.FirstOrDefault(gsg => gsg.SubGroupId == id)!;
        return subGroup.Rounds;
    }

    private static List<SubGroup> GetSubGroupsByGroupId(Game game, int groupId)
    {
        Group group = game.Groups.FirstOrDefault(gr => gr.GroupId == groupId)!;
        return game.SubGroups.Where(sbg => group.SubGroupsIds.Contains(sbg.SubGroupId)).ToList();
    }
}