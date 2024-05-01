
namespace Domain.Entities;

public class GameData
{
    public string GameType { get; set; }
    public List<RoundDataDto> Rounds {get; set;}
}

public class RoundDataDto
{
    public string Kanji { get; set; }
    public string Hiragana { get; set; }
    public string English { get; set; }
    public string Sound { get; set; }
}