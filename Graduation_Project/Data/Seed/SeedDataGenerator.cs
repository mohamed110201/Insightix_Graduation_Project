using System.Text.Json;

namespace Graduation_Project.Data.Seed;

public class SeedDataGenerator
{
    public static async Task<SeedDataContainer?> GenerateAsync()
    {
        await using var stream = OpenJsonStream();
        var data = await DeserializeAsync(stream);
        return data;
    }

    private static async Task<SeedDataContainer?> DeserializeAsync(Stream stream)
    {
        return await JsonSerializer.DeserializeAsync<SeedDataContainer>(stream);
    }

    private static Stream OpenJsonStream()
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Seed", "TestData.json");
        return new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true);
    }

}