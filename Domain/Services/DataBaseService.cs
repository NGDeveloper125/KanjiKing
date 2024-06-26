using Domain.Entities;
namespace Domain.Services;

public static class DataBaseService
{
    public static async Task<List<GameData>?> GetGamesData(HttpClient httpClient)
    {
        try
        {
            return await GetGameDataFromJson(httpClient, "GameData.json");
        }
        catch(Exception)
        {
            return null;
        }
    }

    private static async Task<List<GameData>?> GetGameDataFromJson(HttpClient httpClient, string filePath) 
    {
        try
        {
            List<GameData>? data = System.Text.Json.JsonSerializer.Deserialize<List<GameData>>( await GetGameJsonData(httpClient, filePath));
            return data;
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    private static async Task<string> GetGameJsonData(HttpClient httpClient, string filePath)
    {
        return await httpClient.GetStringAsync(filePath);
    }
} 