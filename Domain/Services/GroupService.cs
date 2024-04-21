using Domain.Entities;
using Domain.Extensions;

namespace Domain.Services;

public static class GroupService
{
    public static Game GetNextGroup(Game game)
    {
        game = UpdateGroups(game);
        Group? group = game.Groups.FirstOrDefault(grp => grp.IsOver == false && grp.GroupId != game.CurrentGroupId);
        if(group is null) return game.UpdateGame(true);
        game = game.UpdateGame(group);
        game = SubGroupService.GetNextSubGroup(game);

        Round round = RoundService.GetNextRoundById(game.Rounds, game.CurrentRound)!;
        return game.UpdateGame(round!);
    }
    private static Game UpdateGroups(Game game)
    {
        Group updatedGroup = new Group(true, game.CurrentGroupId, GetGroupSubGroupsById(game, game.CurrentGroupId));
        List<Group> updatedGroups = game.Groups.Where(sg => sg.GroupId != updatedGroup.GroupId).ToList();
        updatedGroups.Add(updatedGroup);
        return game.UpdateGame(updatedGroups, updatedGroup);
    }
    private static int[] GetGroupSubGroupsById(Game game, int id)
    {
        return game.Groups.FirstOrDefault(gsg => gsg.GroupId == id)!.SubGroupsIds.ToArray();
    }
}