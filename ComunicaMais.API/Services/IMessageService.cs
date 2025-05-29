using ComunicaMais.API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComunicaMais.API.Services
{
    public interface IMessageService
    {
        Task<IEnumerable<MessageDto>> GetMessagesAsync();
        Task SendMessageAsync(MessageDto dto);
    }
}
