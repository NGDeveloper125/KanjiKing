
namespace Domain.Entities;

public record Result(bool seccuss, IEntity Entity);
public record FailResult(bool IsOver, string ErrorMessage) : IEntity; 
public record Game(bool IsOver, GameType GameType, 
                    List<Group> Groups, int CurrentGroupId, 
                    List<SubGroup> SubGroups, int CurrentSubGroupId, 
                    List<Round> Rounds, Round CurrentRound) : IEntity;
public record Group(bool IsOver, int GroupId, int[] SubGroupsIds) : IEntity;
public record SubGroup(bool IsOver, int SubGroupId, List<Round> Rounds) : IEntity;
public record Round(bool IsOver, int RoundId, string Kanji, string Hiragana, string English) : IEntity;