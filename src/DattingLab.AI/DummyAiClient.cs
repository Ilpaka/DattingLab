using System.Threading.Tasks;

namespace DattingLab.AI
{
    public class DummyAiClient : IAiClient
    {
        public Task<string> GetReplyAsync(string message)
        {
            // Placeholder for real AI integration
            return Task.FromResult($"Echo: {message}");
        }
    }
}
