using System.ComponentModel;
using Domain.Entities;
using Domain.Extensions;

namespace Domain.Services;

public static class SubGroupService
{
    public static Game GetNextSubGroup(Game game)
    {
        game = UpdateSubGroups(game);
        List<SubGroup> subGroupsOfCurrentGroup = GetSubGroupsByGroupId(game, game.CurrentGroupId);
        SubGroup subGroup = subGroupsOfCurrentGroup.FirstOrDefault(sbgr => sbgr.IsOver == false)!;
        if(subGroup is not null)
        {
            List<Round> updatedRounds = new List<Round>();
            foreach(Round round in game.Rounds)
            {
                Round newRound = new Round(false, round.RoundId, round.Kanji, round.Hiragana, round.English, round.Sound);
                updatedRounds.Add(newRound);
            }
            return game.UpdateGame(subGroup.SubGroupId, updatedRounds);
        }
        else
        {
            return game;
        }
    }
    private static Game UpdateSubGroups(Game game)
    {
        SubGroup currentSubGroup = GetCurrentSubGroup(game)!;
        SubGroup updatedSubGroup = new SubGroup(true, currentSubGroup.SubGroupId, GetSubGroupRoundsById(game, currentSubGroup.SubGroupId));
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

    private static SubGroup? GetCurrentSubGroup(Game game)
    {
        return game.SubGroups.FirstOrDefault(sb => sb.SubGroupId == game.CurrentSubGroupId);
    }
}