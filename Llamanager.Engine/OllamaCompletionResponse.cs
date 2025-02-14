using System.Text.Json.Serialization;

namespace Llamanager.Engine;

internal record OllamaCompletionResponse(
    [property: JsonPropertyName("model")]
    string Model, 
    [property: JsonPropertyName("created_at")]
    DateTime CreatedAt, 
    [property: JsonPropertyName("response")]
    string Response, 
    [property: JsonPropertyName("done")]
    bool Done);