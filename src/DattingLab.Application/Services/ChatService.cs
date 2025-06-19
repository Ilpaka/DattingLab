using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DattingLab.Domain.Entities;
using DattingLab.Domain.Repositories;
using DattingLab.AI;

namespace DattingLab.Application.Services
{
    public class ChatService
    {
        private readonly IChatRepository _repository;
        private readonly IAiClient _aiClient;

        public ChatService(IChatRepository repository, IAiClient aiClient)
        {
            _repository = repository;
            _aiClient = aiClient;
        }

        public Task<IEnumerable<ChatMessage>> GetChatAsync(Guid chatId) => _repository.GetChatAsync(chatId);

        public async Task<ChatMessage> SendUserMessageAsync(Guid chatId, string content)
        {
            var message = new ChatMessage
            {
                ChatId = chatId,
                FromUser = true,
                Content = content
            };
            await _repository.AddMessageAsync(message);
            var replyContent = await _aiClient.GetReplyAsync(content);
            var reply = new ChatMessage
            {
                ChatId = chatId,
                FromUser = false,
                Content = replyContent
            };
            await _repository.AddMessageAsync(reply);
            return reply;
        }
    }
}
