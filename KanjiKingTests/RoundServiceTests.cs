using Xunit;
using FluentAssertions;
using KanjiKingDomain.Models;
using LanguageExt.Common;
using KanjiKingDomain.Services;

namespace KanjiKingTests
{
    public class RoundServiceTests
    {
        [Fact]
        public void GetNewRound_ReturnError_WhenGameIsNull()
        {
            var rounds = new List<Round>() { new Round(0, "t", "t", "t", "t")};
            Result<Round> result = RoundService.GetNewRound(null, rounds);

            string resultValue = result.Match(
                        _ => "Succes!",
                        error => error.Message);

            resultValue.Should().Be("Object reference not set to an instance of an object.");
        }

        [Fact]
        public void GetNewRound_ReturnError_WhenRoundsPlayedIsNull()
        {
            var rounds = new List<Round>() { new Round(0, "t", "t", "t", "t") };
            var game = new Game(50, null!, 20, GameType.Radicals);
            
            Result<Round> result = RoundService.GetNewRound(game, rounds);

            string resultValue = result.Match(
                        _ => "Success!",
                        error => error.Message);

            resultValue.Should().Be("Object reference not set to an instance of an object.");
        }

        [Fact]
        public void GetNewRound_ReturnError_WhenRoundsIsNull()
        {
            var game = new Game(50, null!, 20, GameType.Radicals);

            Result<Round> result = RoundService.GetNewRound(game, null);

            string resultValue = result.Match(
                        _ => "Success!",
                        error => error.Message);

            resultValue.Should().Be("Object reference not set to an instance of an object.");
        }

        [Fact]
        public void GetNewRound_ReturnNewRound_WhenGameIsValid()
        {
            var rounds = new List<Round>() { new Round(0, "t", "t", "t", "t") };
            var game = new Game(50, new List<int>(), 20, GameType.Radicals);

            Result<Round> result = RoundService.GetNewRound(game, rounds);

            result.Match(
                r =>
                {
                    r.Id.Should().Be(0);
                    return r;
                },
                error =>
                {
                    Assert.True(false, "Expected successsful result but found an error");
                    return default;
                });
        }

        [Fact]
        public void GetNewRound_ReturnError_WhenGameIsValidAndNoMoreRoundsLeft()
        {
            var rounds = new List<Round>() { new Round(0, "t", "t", "t", "t") };
            var game = new Game(50, new List<int>() { 0 }, 20, GameType.Radicals);

            Result<Round> result = RoundService.GetNewRound(game, rounds);

            string resultValue = result.Match(
                           _ => "Successful",
                           error => error.Message);

            resultValue.Should().Be("Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')");
        }

        [Fact]
        public void GetNewRound_ReturnNextRound_WhenOneRoundWasPlayedAndOneRoundLeft()
        {
            var rounds = new List<Round>() { new Round(0, "t", "t", "t", "t"), new Round(1, "t", "t", "t", "t") };
            var game = new Game(50, new List<int>() { 0 }, 20, GameType.Radicals);

            Result<Round> result = RoundService.GetNewRound(game, rounds);

            result.Match(
                    r =>
                    {
                        r.Id.Should().Be(1);
                        return r;
                    },
                    error =>
                    {
                        Assert.True(false, "Expected successful result but found an error");
                        return default;
                    });
        }
    }
}
