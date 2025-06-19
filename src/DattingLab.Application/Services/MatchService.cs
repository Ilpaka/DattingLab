using System;
using System.Threading.Tasks;
using DattingLab.Domain.Entities;

namespace DattingLab.Application.Services
{
    public class MatchService
    {
        private readonly Random _random = new();

        public Task<bool> TryMatchAsync(GirlProfile girl)
        {
            // 20% chance to match
            bool match = _random.NextDouble() < 0.2;
            return Task.FromResult(match);
        }
    }
}
