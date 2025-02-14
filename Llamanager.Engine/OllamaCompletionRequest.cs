namespace Llamamanager.Engine;

internal record OllamaCompletionRequest(string Model, string Prompt, bool Stream);
