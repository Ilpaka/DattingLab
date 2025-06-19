using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DattingLab.Domain.Entities;
using DattingLab.Domain.Repositories;

namespace DattingLab.Application.Services
{
    public class GirlProfileGenerator
    {
        private readonly IGirlProfileRepository _repository;
        private readonly string _photoFolder;
        private readonly Random _random = new();
        private readonly string[] _names = new[] { "Anna", "Maria", "Kate", "Julia", "Olga" };

        public GirlProfileGenerator(IGirlProfileRepository repository, string photoFolder)
        {
            _repository = repository;
            _photoFolder = photoFolder;
        }

        public async Task<IEnumerable<GirlProfile>> GetRandomGirlsAsync(int count)
        {
            var girls = new List<GirlProfile>();
            var photos = Directory.GetFiles(_photoFolder, "*.jpg");
            for (int i = 0; i < count; i++)
            {
                var girl = new GirlProfile
                {
                    Name = _names[_random.Next(_names.Length)],
                    Age = _random.Next(18, 30),
                    Interests = "Music, Movies, Travel",
                    Description = "Generated profile",
                    PhotoPath = photos[_random.Next(photos.Length)]
                };
                girls.Add(girl);
            }
            return await Task.FromResult(girls);
        }

        public Task LikeAsync(GirlProfile profile) => _repository.LikeAsync(profile);
        public Task DislikeAsync(GirlProfile profile) => _repository.DislikeAsync(profile);
    }
}
