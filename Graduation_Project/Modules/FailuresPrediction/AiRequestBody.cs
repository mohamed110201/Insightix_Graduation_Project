using System.Text.Json.Serialization;

namespace Graduation_Project.Modules.FailuresPrediction;

public class AiRequestBody
{
    [JsonPropertyName("model_name")]
    public string ModelName { get; set; } = string.Empty;
    
    [JsonPropertyName("data")]
    public List<List<dynamic?>> Data { get; set; } = [];
}