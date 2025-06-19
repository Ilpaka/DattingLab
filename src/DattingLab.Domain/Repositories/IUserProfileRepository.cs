using System.Threading.Tasks;
using DattingLab.Domain.Entities;

namespace DattingLab.Domain.Repositories
{
    public interface IUserProfileRepository
    {
        Task<UserProfile?> GetAsync();
        Task SaveAsync(UserProfile profile);
    }
}
