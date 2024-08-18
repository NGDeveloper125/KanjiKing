using KanjiKingDomain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace KanjiKingInterface.DatabaseLayer
{
    public class JsonDatabaseService : IDatabaseService
    {
        public List<Round> GameRounds = null!;
        private string databaseFilePath;

        public JsonDatabaseService(GameType gameType, string databaseFilePath)
        {
            this.databaseFilePath = databaseFilePath;
            SetGameRounds(gameType);
        } 

        public List<Round> GetGameRounds() => GameRounds;
        

        private void SetGameRounds(GameType gameType) 
        {
            try
            {
                DatabaseModel? databaseModel = GetDatabaseModel();
                if (databaseModel is null) throw new Exception("Fail to get data from db: database model is null");

                GameRounds = GetGameRoundsByGameType(gameType, databaseModel);
            }
            catch (Exception ex)
            {
                throw new Exception($"Fail to get data from db: {ex}");
            }

        }

        private DatabaseModel? GetDatabaseModel() 
        {
            string databaseJson = File.ReadAllText(databaseFilePath);
            return JsonSerializer.Deserialize<DatabaseModel>(databaseJson);
        }

        private List<Round> GetGameRoundsByGameType(GameType gameType, DatabaseModel databaseModel)
        {
            return gameType switch
            {
                GameType.Radicals => databaseModel.Radicals,
                GameType.SingleKanjis => databaseModel.SingleKanjis,
                GameType.KanjiWords => databaseModel.KanjiWords,
                _ => throw new Exception("Out of range game type")
            };
        }
    }
}
