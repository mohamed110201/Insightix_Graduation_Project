using System.Text.Json;

namespace Graduation_Project.Data.Seed;

public class SeedDataGenerator
{
    public static SeedDataContainer Generate()
    {
        var jsonText = ReadJsonText();
        var data = Deserialize(jsonText);
        return data;
    }

    private static SeedDataContainer Deserialize(string jsonText)
    {
        var data = JsonSerializer.Deserialize<SeedDataContainer>(jsonText);
        return data;
    }

    private static string ReadJsonText()
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Seed", "TestData.json");
        var jsonText = File.ReadAllText(path);
        return jsonText;
    }
}