using System.Threading.Tasks;

namespace DattingLab.AI
{
    public interface IAiClient
    {
        Task<string> GetReplyAsync(string message);
    }
}
