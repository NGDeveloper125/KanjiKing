using KanjiKingDomain.Models;
using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanjiKingDomain.Factories
{
    public static class RoundFactory
    {
        public static Result<Round> GetNewRound(List<int> roundsPlayed, List<Round> rounds)
        {
            List<Round> newRounds = rounds.Where(r => !roundsPlayed.Contains(r.Id)).ToList();

            return newRounds[GetRandomIndex(newRounds.Count)];
        }

        private static int GetRandomIndex(int top) 
        {
            Random random = new Random();
            return random.Next(top);
        }
    }
}
