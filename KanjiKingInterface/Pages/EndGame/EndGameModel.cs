using KanjiKingInterface.Pages.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanjiKingInterface.Pages.EndGame
{
    public class EndGameModel
    {
        public string SuccessfullKanjis { get; set; } = null!;
        public string TotalKanjis { get; set; } = null!;
        public bool Completed {  get; set; } = false;
        public string MistakesMade { get; set; } = null!;

        public EndGameModel(string successfullKanjis, string totalKanjis, bool completed, string mistakesMade)
        {
            SuccessfullKanjis = successfullKanjis;
            TotalKanjis = totalKanjis;
            Completed = completed;
            MistakesMade = mistakesMade;
        }
    }
}
