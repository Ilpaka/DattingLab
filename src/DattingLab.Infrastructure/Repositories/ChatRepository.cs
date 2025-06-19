using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DattingLab.Domain.Entities;
using DattingLab.Domain.Repositories;
using DattingLab.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DattingLab.Infrastructure.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly AppDbContext _context;

        public ChatRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ChatMessage>> GetChatAsync(Guid chatId)
        {
            return await _context.ChatMessages
                .Where(m => m.ChatId == chatId)
                .OrderBy(m => m.Timestamp)
                .ToListAsync();
        }

        public async Task AddMessageAsync(ChatMessage message)
        {
            _context.ChatMessages.Add(message);
            await _context.SaveChangesAsync();
        }
    }
}
