using System.Security.Cryptography;
using Domain.Entities;
namespace Domain.Extensions;

public static class GameDataExtensions
{
    public static Game? ConvertGamaDataToGame(this GameData self)
    {
        List<Round> rounds = ConvertGameDataRoundsToRounds(self.Rounds);
        List<SubGroup> subGroups = SpliteRoundsToSubGroups(rounds);
        List<Group> groups = SpliteSubGroupsToGroups(subGroups);
        return new Game(false, ConvertStringToGameType(self.GameType), 
                        groups, groups[0].GroupId, subGroups,   
                        subGroups[0].SubGroupId, rounds, rounds[0]);
    } 

    private static List<Round> ConvertGameDataRoundsToRounds(List<RoundDataDto> roundDataDtos)
    {
        List<Round> rounds = new List<Round>();
        int id = 1;
        foreach(RoundDataDto roundDataDto in roundDataDtos)
        {
            Round round = new Round(false, id, roundDataDto.Kanji, roundDataDto.Hiragana, roundDataDto.English);
            rounds.Add(round);
            id++;
        }
        return rounds;
    }

    public static List<SubGroup> SpliteRoundsToSubGroups(this List<Round> rounds)
    {
        List<SubGroup> subGroups = new List<SubGroup>();
        int amountOfRoundsInSubGroup = rounds.Count / 12;
        int id = 1;
        int index = 0;
        for(int i = 0; i < 12; i++)
        {
            List<Round> roundsForSubGroup = new List<Round>();
            for(int r = 0; r < amountOfRoundsInSubGroup; r++)
            {
                if(rounds.Count < index)
                {
                    break;
                }
                roundsForSubGroup.Add(rounds[index]);
                index++;
            }
            SubGroup subGroup = new SubGroup(false, id, roundsForSubGroup);
            id++;
            subGroups.Add(subGroup);
        }
        return subGroups;
    }

    public static List<Group> SpliteSubGroupsToGroups(this List<SubGroup> subGroups)
    {
        List<Group> groups = new List<Group>();
        int amountOfSubGroupsInGroup = subGroups.Count / 4;
        int id = 1;
        int index = 0;
        for(int i = 0; i < 4; i++)
        {
            List<int> subGroupsForGroup = new List<int>();
            for(int r = 0; r < amountOfSubGroupsInGroup; r++)
            {
                if(subGroups.Count < index)
                {
                    break;
                }
                subGroupsForGroup.Add(subGroups[index].SubGroupId);
                index++;
            }
            Group group = new Group(false, id, subGroupsForGroup.ToArray());
            id++;
            groups.Add(group);
        }
        return groups;
    }

    private static GameType ConvertStringToGameType(string gameType) => gameType switch
    {
        "Radicals" => GameType.Radicals,
        "BasicKanjis" => GameType.BasicKanjis,
        "Words" => GameType.Words,
        _ => throw new Exception($"{gameType} is not valid game type!") 
    };
}