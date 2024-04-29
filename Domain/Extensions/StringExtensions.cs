using Domain.Entities;

namespace Domain.Extensions;

public static class StringExtensions
{
    public static GameType ConvertStringToGameType(this string self) => self switch
    {
        "1" => GameType.Radicals,
        "2" => GameType.BasicKanjis,
        "3" => GameType.Words,
        _ => throw new Exception($"{self} is not valid game type!") 
    };
}