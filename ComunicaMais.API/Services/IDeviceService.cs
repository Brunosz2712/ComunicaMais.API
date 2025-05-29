using ComunicaMais.API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComunicaMais.API.Services
{
    public interface IDeviceService
    {
        Task<IEnumerable<DeviceDto>> GetDevicesAsync();
        Task<DeviceDto?> GetDeviceByIdAsync(string id);
        Task AddDeviceAsync(DeviceDto dto);
        Task<bool> UpdateDeviceAsync(string id, DeviceDto dto);
        Task<bool> DeleteDeviceAsync(string id);
    }
}
