

using KanjiKingDomain.Models;

namespace KanjiKingInterface.DatabaseLayer
{
    public record DatabaseModel(List<Round> Radicals, List<Round> SingleKanjis, List<Round> KanjiWords);
}
