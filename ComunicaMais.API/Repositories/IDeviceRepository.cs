using ComunicaMais.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComunicaMais.API.Repositories
{
    public interface IDeviceRepository
    {
        Task<IEnumerable<Device>> GetAllAsync();
        Task<Device?> GetByIdAsync(string id);
        Task AddAsync(Device device);
        Task UpdateAsync(Device device);
        Task DeleteAsync(Device device);
    }
}
