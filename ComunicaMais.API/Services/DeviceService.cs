using ComunicaMais.API.DTOs;
using ComunicaMais.API.Models;
using ComunicaMais.API.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComunicaMais.API.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _repository;

        public DeviceService(IDeviceRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DeviceDto>> GetDevicesAsync()
        {
            var devices = await _repository.GetAllAsync();
            return devices.Select(d => new DeviceDto
            {
                DeviceId = d.DeviceId,
                Name = d.Name,
                LastSeen = d.LastSeen,
                Status = d.Status
            });
        }

        public async Task<DeviceDto?> GetDeviceByIdAsync(string deviceId)
        {
            var device = await _repository.GetByIdAsync(deviceId);
            if (device == null) return null;

            return new DeviceDto
            {
                DeviceId = device.DeviceId,
                Name = device.Name,
                LastSeen = device.LastSeen,
                Status = device.Status
            };
        }

        public async Task AddDeviceAsync(DeviceDto dto)
        {
            var device = new Device
            {
                DeviceId = dto.DeviceId,
                Name = dto.Name,
                LastSeen = dto.LastSeen,
                Status = dto.Status
            };
            await _repository.AddAsync(device);
        }

        public async Task<bool> UpdateDeviceAsync(string deviceId, DeviceDto dto)
        {
            var device = await _repository.GetByIdAsync(deviceId);
            if (device == null) return false;

            device.Name = dto.Name;
            device.LastSeen = dto.LastSeen;
            device.Status = dto.Status;

            await _repository.UpdateAsync(device);
            return true;
        }

        public async Task<bool> DeleteDeviceAsync(string deviceId)
        {
            var device = await _repository.GetByIdAsync(deviceId);
            if (device == null) return false;

            await _repository.DeleteAsync(device);
            return true;
        }
    }
}
