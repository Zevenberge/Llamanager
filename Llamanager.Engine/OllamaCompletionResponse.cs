using System.Text.Json.Serialization;

namespace Llamamanager.Engine;

internal record OllamaCompletionResponse(string Model, 
    [property: JsonPropertyName("created_at")]
    DateTime CreatedAt, string Response, bool Done);