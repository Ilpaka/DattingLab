using System.Collections.Generic;
using System.Threading.Tasks;
using DattingLab.Domain.Entities;

namespace DattingLab.Domain.Repositories
{
    public interface IGirlProfileRepository
    {
        Task<IEnumerable<GirlProfile>> GetRandomAsync(int count);
        Task LikeAsync(GirlProfile profile);
        Task DislikeAsync(GirlProfile profile);
    }
}
