using Xunit;
using FluentAssertions;
using KanjiKingDomain.Models;
using LanguageExt.Common;
using KanjiKingDomain.Services;

namespace KanjiKingTests;

public class GameServiceTests
{
    [Fact]
    public void GetNewGame_ReturnError_WhenGameSettingsIsNull()
    {
        Result<Game> result = GameService.GetNewGame(null);

        string resultValue = result.Match(_ => "Success!", error => error.Message);
        
        resultValue.Should().Be("Object reference not set to an instance of an object.");
   }

    [Fact]
    public void GetNewGame_ReturnGame_WhenGameSettingsAreValid()
    {
        var gameSettings = new GameSettings(GameType.Radicals, GameLevel.Easy);

        Result<Game> result = GameService.GetNewGame(gameSettings);

        string resultValue = result.Match(_ => "Success!", error => error.Message);

        resultValue.Should().Be("Success!");
    }

    [Fact]
    public void IsMoreRounds_ReturnError_WhenGameIsNull()
    {
        Game game = new Game(50, new List<int>(), 10, GameType.Radicals);

        Result<bool> result = GameService.IsMoreRounds(null!);

        string resultValue = result.Match(_ => "Success!", error => error.Message);

        resultValue.Should().Be("Object reference not set to an instance of an object.");
    }

    [Fact]
    public void IsMoreRounds_ReturnTrue_WhenThereAreMoreRoundsAndMoreMistakesLeft()
    {
        Game game = new Game(50, new List<int>(), 10, GameType.Radicals);

        Result<bool> result = GameService.IsMoreRounds(game);

        result.Match(
            r =>
            {
                r.Should().BeTrue();
                return true;
            },
            ex =>
            {
                Assert.True(false, "Expected a success result but found an error");
                return false;
            });
    }

    [Fact]
    public void IsMoreRounds_ReturnFalse_WhenThereAreMoreRoundsAndNoMoreMistakesLeft()
    {
        Game game = new Game(50, new List<int>(), 0, GameType.Radicals);

        Result<bool> result = GameService.IsMoreRounds(game);

        result.Match(
            r =>
            {
                r.Should().BeFalse();
                return false;
            },
            ex =>
            {
                Assert.True(false, "Expected a success result but found an error");
                return false;
            });
    }


    [Fact]
    public void IsMoreRounds_ReturnFalse_WhenThereAreNoMoreRoundsAndNoMoreMistakesLeft()
    {
        Game game = new Game(0, new List<int>(), 0, GameType.Radicals);

        Result<bool> result = GameService.IsMoreRounds(game);

        result.Match(
            r =>
            {
                r.Should().BeFalse();
                return false;
            },
            ex =>
            {
                Assert.True(false, "Expected a success result but found an error");
                return false;
            });
    }

    [Fact]
    public void IsMoreRounds_ReturnFalse_WhenThereArenNoMoreRoundsAndMoreMistakesLeft()
    {
        Game game = new Game(0, new List<int>(), 10, GameType.Radicals);

        Result<bool> result = GameService.IsMoreRounds(game);

        result.Match(
            r =>
            {
                r.Should().BeFalse();
                return false;
            },
            ex =>
            {
                Assert.True(false, "Expected a success result but found an error");
                return false;
            });
    }
}