using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DattingLab.Domain.Entities;

namespace DattingLab.Domain.Repositories
{
    public interface IChatRepository
    {
        Task<IEnumerable<ChatMessage>> GetChatAsync(Guid chatId);
        Task AddMessageAsync(ChatMessage message);
    }
}
