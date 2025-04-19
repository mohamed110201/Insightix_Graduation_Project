using System.Text.Json.Serialization;

namespace Graduation_Project.Modules.FailuresPrediction;

public class AiResponseBody
{
    [JsonPropertyName("prediction")]
    public bool? Prediction { get; set; }
}