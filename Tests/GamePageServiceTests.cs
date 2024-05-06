using Xunit;
using FluentAssertions;
using Domain.Entities;
using Domain.Services;

namespace Tests;

public class GamePageServiceTests
{
    [Fact]
    public void GetNewGameByType_ReturnsFailResult_WhenGamesDataIsNull()
    {
        List<GameData> gamesData = null;

        Result result = GamePageService.GetNewGameByType("1", gamesData);

        result.seccuss.Should().BeFalse();
    }
    
    [Fact]
    public void GetNewGameByType_ReturnsFailResult_WhenGamesDataIsEmpty()
    {
        List<GameData> gamesData = new List<GameData>();

        Result result = GamePageService.GetNewGameByType("1", gamesData);

        result.seccuss.Should().BeFalse();
    }
    
    [Fact]
    public void GetNewGameByType_ReturnsGame_WhenGamesDataIsValid()
    {
        List<GameData> gamesData = GenerateValidGamesData();
        
        Result result = GamePageService.GetNewGameByType("1", gamesData);

        result.seccuss.Should().BeTrue();
        Game game = (result.Entity as Game)!;
        game.IsOver.Should().BeFalse();
    }

    [Fact]
    public void GetNextRound_ReturnsNextRoundFromSameSubGroup_WhenAnswerIsTrueAndThereAreMoreRoundsInRounds()
    {
        Game game = GenerateGameWithTwoRoundsInRounds();

        Result result = GamePageService.GetNextRound(true, game);

        result.seccuss.Should().BeTrue();
        game = (result.Entity as Game)!;
        game.IsOver.Should().BeFalse();
        game.Rounds.Count.Should().BeGreaterThan(1);
        game.CurrentRound.RoundId.Should().Be(2);
    }

    
    [Fact]
    public void GetNextRound_ReturnsNextRoundFromSameSubGroup_WhenAnswerIsWrongAndThereAreMoreRoundsInRounds()
    {
        Game game = GenerateGameWithTwoRoundsInRounds();

        Result result = GamePageService.GetNextRound(false, game);

        result.seccuss.Should().BeTrue();
        game = (result.Entity as Game)!;
        game.IsOver.Should().BeFalse();
        game.CurrentRound.RoundId.Should().Be(2);
    }

    [Fact]
    public void GetNextRound_ReturnsSameRoundFromSameSubGroup_WhenAnswerIsWrongAndThereAreNoMoreRoundsInRounds()
    {
        Game game = GenerateGameWithOneRoundInRounds();

        Result result = GamePageService.GetNextRound(false, game);

        result.seccuss.Should().BeTrue();
        game = (result.Entity as Game)!;
        game.IsOver.Should().BeFalse();
        game.CurrentRound.RoundId.Should().Be(1);
    }

    [Fact]
    public void GetNextRound_ReturnsNewRoundFromNewSubGroup_WhenAnswerIsTrueAndThereAreNoMoreRoundsInSubGroup()
    {
        Game game = GenerateGameWithTwoSubGroupsAndOneRoundInRounds();

        Result result = GamePageService.GetNextRound(true, game);

        result.seccuss.Should().BeTrue();
        game = (result.Entity as Game)!;
        game.IsOver.Should().BeFalse();
        game.Rounds.Count.Should().BeGreaterThan(1);
        game.CurrentSubGroupId.Should().Be(2);
    }

    [Fact]
    public void GetNextRound_ReturnsNewRoundFromNewGroup_WhenAnswerIsTrueAndThereAreNoMoreRoundsInRoundsAndNoMoreSubGroupsInGroup()
    {
        Game game = GenerateGameWithTwoGroupsAndOneSubGroupInEachAndOneRoundInRounds();

        Result result = GamePageService.GetNextRound(true, game);

        result.seccuss.Should().BeTrue();
        game = (result.Entity as Game)!;
        game.IsOver.Should().BeFalse();
        game.CurrentGroupId.Should().Be(2);
        game.Rounds.Count().Should().Be(2);
    }

    [Fact]
    public void GetNextRound_ReturnsGameIsOver_WhenAnswerIsTrueAndThereAreNoMoreRoundsInRoundsAndNoMoreSubGroupsInGroupAndNoMoreGroups()
    {
        Game game = GenerateGameWithFourGroupsAndFourSubGroupInEachAndOneRoundLeftInRounds();

        Result result = GamePageService.GetNextRound(true, game);

        result.seccuss.Should().BeTrue();
        game = (result.Entity as Game)!;
        game.IsOver.Should().BeTrue();
    }
    private static Game GenerateGameWithTwoRoundsInRounds()
    {
        Round round1 = new Round(false, 1, "test", "test", "test", "sound");
        Round round2 = new Round(false, 2, "test", "test", "test", "sound");
        SubGroup subGroup1 = new SubGroup(false, 1, new List<Round>(){round1, round2});
        Group group = new Group(false, 1, [1]); 
        List<Round> rounds = new List<Round>{round1, round2};
        return new Game(false, GameType.Radicals, [group], 1, [subGroup1], 1, rounds, round1);
    }
    private static Game GenerateGameWithOneRoundInRounds()
    {
        Round round1 = new Round(false, 1, "test", "test", "test", "sound");
        List<Round> rounds = new List<Round>{round1};
        SubGroup subGroup1 = new SubGroup(false, 1, new List<Round>(){round1});
        Group group = new Group(false, 1, [1]); 
        return new Game(false, GameType.Radicals, [group], 1, [subGroup1], 1, rounds, round1);
    }
    private static Game GenerateGameWithTwoSubGroupsAndOneRoundInRounds()
    {
        Round round1 = new Round(false, 1, "test", "test", "test", "sound");
        SubGroup subGroup1 = new SubGroup(false, 1, new List<Round>(){round1});
        Round round2 = new Round(false, 2, "test", "test", "test", "sound");
        SubGroup subGroup2 = new SubGroup(false, 2, new List<Round>(){round2});
        Group group = new Group(false, 1, [1,2]); 
        List<Round> rounds = new List<Round>{round1, round2};
        return new Game(false, GameType.Radicals, new List<Group>(){group}, 1, new List<SubGroup>(){subGroup1, subGroup2}, 1, rounds, round1);
    }
    private static Game GenerateGameWithTwoGroupsAndOneSubGroupInEachAndOneRoundInRounds()
    {
        Round round1 = new Round(false, 1, "test", "test", "test", "sound");
        SubGroup subGroup1 = new SubGroup(false, 1, new List<Round>(){round1});
        Group group1 = new Group(false, 1, new int[]{subGroup1.SubGroupId});
        Round round2 = new Round(false, 2, "test", "test", "test", "sound");
        SubGroup subGroup2 = new SubGroup(false, 2, new List<Round>(){round2});
        Group group2 = new Group(false, 2, new int[]{subGroup2.SubGroupId});
        List<Round> rounds = new List<Round>{round1, round2};
        return new Game(false, GameType.Radicals, new List<Group>(){group1, group2}, 1, new List<SubGroup>(){subGroup1, subGroup2}, 1, rounds, round1);
    }
    private static Game GenerateGameWithFourGroupsAndFourSubGroupInEachAndOneRoundLeftInRounds()
    {
        Round round1 = new Round(false, 1, "test", "test", "test", "sound");
        SubGroup subGroup1 = new SubGroup(false, 1, new List<Round>(){round1});
        Group group1 = new Group(false, 1, new int[]{subGroup1.SubGroupId});
        Round round2 = new Round(true, 2, "test", "test", "test", "sound");
        SubGroup subGroup2 = new SubGroup(true, 2, new List<Round>(){round2});
        Group group2 = new Group(true, 2, new int[]{subGroup2.SubGroupId});
        Round round3 = new Round(true, 1, "test", "test", "test", "sound");
        SubGroup subGroup3 = new SubGroup(true, 1, new List<Round>(){round3});
        Group group3 = new Group(true, 1, new int[]{subGroup3.SubGroupId});
        Round round4 = new Round(true, 1, "test", "test", "test", "sound");
        SubGroup subGroup4 = new SubGroup(true, 1, new List<Round>(){round4});
        Group group4 = new Group(true, 1, new int[]{subGroup4.SubGroupId});
        List<Round> rounds = new List<Round>{round1, round2, round3, round4};
        return new Game(false, GameType.Radicals, new List<Group>(){group1, group2, group3, group4}, 1, new List<SubGroup>(){subGroup1, subGroup2, subGroup3, subGroup4}, 1, rounds, round1);  
    }
    private static List<GameData> GenerateValidGamesData()
    {
            GameData gameData = new GameData();
        gameData.GameType = "1";
        RoundDataDto round1 = new RoundDataDto
        {
            Kanji = "",
            Hiragana = "",
            English = ""
        };
        RoundDataDto round2 = new RoundDataDto  
        {
            Kanji = "",
            Hiragana = "",
            English = ""
        };
        RoundDataDto round3 = new RoundDataDto  
        {
            Kanji = "",
            Hiragana = "",
            English = ""
        };
        RoundDataDto round4 = new RoundDataDto  
        {
            Kanji = "",
            Hiragana = "",
            English = ""
        };
        RoundDataDto round5 = new RoundDataDto  
        {
            Kanji = "",
            Hiragana = "",
            English = ""
        };
        RoundDataDto round6 = new RoundDataDto  
        {
            Kanji = "",
            Hiragana = "",
            English = ""
        };
        RoundDataDto round7 = new RoundDataDto  
        {
            Kanji = "",
            Hiragana = "",
            English = ""
        };
        RoundDataDto round8 = new RoundDataDto  
        {
            Kanji = "",
            Hiragana = "",
            English = ""
        };
        RoundDataDto round9 = new RoundDataDto  
        {
            Kanji = "",
            Hiragana = "",
            English = ""
        };
        RoundDataDto round10 = new RoundDataDto  
        {
            Kanji = "",
            Hiragana = "",
            English = ""
        };
        RoundDataDto round11 = new RoundDataDto  
        {
            Kanji = "",
            Hiragana = "",
            English = ""
        };
        RoundDataDto round12 = new RoundDataDto  
        {
            Kanji = "",
            Hiragana = "",
            English = ""
        };
        gameData.Rounds = new List<RoundDataDto>{round1, round2, round3, round4, round5, round6, round7, round8, round9, round10, round11, round12};
        return new List<GameData>(){gameData};
    }
}