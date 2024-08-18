using KanjiKingDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanjiKingInterface.DatabaseLayer
{
    public interface IDatabaseService
    {
        public List<Round> GetGameRounds();
    }
}
