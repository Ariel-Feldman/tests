namespace Ariel.Utilities
{
    public interface ISerializer
    {
        string ContentType { get; }
        T Deserialize<T>(string text);
    }
}