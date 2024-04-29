
using Domain.Entities;

namespace Domain.Extensions;

public static class GameExtensions
{
    public static Game UpdateGame(this Game self, bool IsOver)
    {
        return new Game(IsOver, self.GameType, self.Groups, self.CurrentGroupId, self.SubGroups, self.CurrentSubGroupId, self.Rounds, self.CurrentRound);
    }

    public static Game UpdateGame(this Game self, List<Group> groups)
    {
        return new Game(self.IsOver, self.GameType, groups, self.CurrentGroupId, self.SubGroups, self.CurrentSubGroupId, self.Rounds, self.CurrentRound);
    }
    
    public static Game UpdateGame(this Game self, Group group)
    {
        return new Game(self.IsOver, self.GameType, self.Groups, group.GroupId, self.SubGroups, self.CurrentSubGroupId, self.Rounds, self.CurrentRound);
    }
    public static Game UpdateGame(this Game self, List<Group> groups, Group group)
    {
        return new Game(self.IsOver, self.GameType, groups, group.GroupId, self.SubGroups, self.CurrentSubGroupId, self.Rounds, self.CurrentRound);
    }
    
    public static Game UpdateGame(this Game self, List<SubGroup> subGroups, int subGroupId)
    {
        return new Game(self.IsOver, self.GameType, self.Groups, self.CurrentGroupId, subGroups, subGroupId, self.Rounds, self.CurrentRound);
    }

    public static Game UpdateGame(this Game self, List<SubGroup> subGroups)
    {
        return new Game(self.IsOver, self.GameType, self.Groups, self.CurrentGroupId, subGroups, self.CurrentSubGroupId, self.Rounds, self.CurrentRound);
    }
    
    public static Game UpdateGame(this Game self, int subGroupId)
    {
        return new Game(self.IsOver, self.GameType, self.Groups, self.CurrentGroupId, self.SubGroups, subGroupId, self.Rounds, self.CurrentRound);
    }

    public static Game UpdateGame(this Game self, int subGroupId, List<Round> rounds)
    {
        return new Game(self.IsOver, self.GameType, self.Groups, self.CurrentGroupId, self.SubGroups, subGroupId, rounds, self.CurrentRound);
    }

    public static Game UpdateGame(this Game self, List<Round> rounds, Round round)
    {
        return new Game(self.IsOver, self.GameType, self.Groups, self.CurrentGroupId, self.SubGroups, self.CurrentSubGroupId, rounds, round);
    }

    
    public static Game UpdateGame(this Game self, List<Round> rounds)
    {
        return new Game(self.IsOver, self.GameType, self.Groups, self.CurrentGroupId, self.SubGroups, self.CurrentSubGroupId, rounds, self.CurrentRound);
    }

    
    public static Game UpdateGame(this Game self, Round round)
    {
        return new Game(self.IsOver, self.GameType, self.Groups, self.CurrentGroupId, self.SubGroups, self.CurrentSubGroupId, self.Rounds, round);
    }
}