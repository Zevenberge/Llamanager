namespace Llamamanager.Engine;

public class LlmSettings
{
    public string Url { get; set; } = "";
    public string Model { get; set; } = "";
}

public interface ILlmAgent
{

}

public class LlmAgent(OllamaClient ollamaClient): ILlmAgent
{

}
