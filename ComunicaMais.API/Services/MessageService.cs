using ComunicaMais.API.DTOs;
using ComunicaMais.API.Models;
using ComunicaMais.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComunicaMais.API.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _repository;

        public MessageService(IMessageRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MessageDto>> GetMessagesAsync()
        {
            var messages = await _repository.GetAllAsync();

            // Projeta e retorna lista já avaliada
            return messages.Select(m => new MessageDto
            {
                Sender = m.Sender,
                Content = m.Content,
                Timestamp = m.Timestamp,
                DeviceId = m.DeviceId
            }).ToList();
        }

        public async Task SendMessageAsync(MessageDto dto)
        {
            var message = new Message
            {
                Sender = dto.Sender,
                Content = dto.Content,
                DeviceId = dto.DeviceId,
                Timestamp = dto.Timestamp == default ? DateTime.UtcNow : dto.Timestamp
            };

            await _repository.AddAsync(message);
        }
    }
}
