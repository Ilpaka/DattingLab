using System.Threading.Tasks;
using DattingLab.Domain.Entities;
using DattingLab.Domain.Repositories;

namespace DattingLab.Application.Services
{
    public class ProfileService
    {
        private readonly IUserProfileRepository _repository;

        public ProfileService(IUserProfileRepository repository)
        {
            _repository = repository;
        }

        public Task<UserProfile?> GetAsync() => _repository.GetAsync();

        public Task SaveAsync(UserProfile profile) => _repository.SaveAsync(profile);
    }
}
