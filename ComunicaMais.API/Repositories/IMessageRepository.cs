using ComunicaMais.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComunicaMais.API.Repositories
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> GetAllAsync();
        Task AddAsync(Message message);
    }
}
