using ComunicaMais.API.DTOs;
using ComunicaMais.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ComunicaMais.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DevicesController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public DevicesController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        // GET: api/devices
        [HttpGet]
        public async Task<IActionResult> GetDevices()
        {
            var devices = await _deviceService.GetDevicesAsync();
            return Ok(devices);
        }

        // GET: api/devices/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDevice(string id)
        {
            var device = await _deviceService.GetDeviceByIdAsync(id);
            if (device == null)
                return NotFound(new { message = $"Dispositivo com id '{id}' não encontrado." });

            return Ok(device);
        }

        // POST: api/devices
        [HttpPost]
        public async Task<IActionResult> AddDevice([FromBody] DeviceDto dto)
        {
            if (dto == null || !ModelState.IsValid)
                return BadRequest("Dados do dispositivo são obrigatórios e devem ser válidos.");

            // Verifica se o ID já existe (opcional, caso você deseje evitar duplicatas)
            var existingDevice = await _deviceService.GetDeviceByIdAsync(dto.DeviceId);
            if (existingDevice != null)
                return Conflict(new { message = $"Já existe um dispositivo com o id '{dto.DeviceId}'." });

            await _deviceService.AddDeviceAsync(dto);

            // Retorna 201 Created com localização do novo recurso
            return CreatedAtAction(nameof(GetDevice), new { id = dto.DeviceId }, new { message = "Dispositivo adicionado com sucesso!" });
        }

        // PUT: api/devices/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDevice(string id, [FromBody] DeviceDto dto)
        {
            if (dto == null || !ModelState.IsValid)
                return BadRequest("Dados do dispositivo são obrigatórios e devem ser válidos.");

            var updated = await _deviceService.UpdateDeviceAsync(id, dto);
            if (!updated)
                return NotFound(new { message = $"Dispositivo com id '{id}' não encontrado." });

            return Ok(new { message = "Dispositivo atualizado com sucesso!" });
        }

        // DELETE: api/devices/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(string id)
        {
            var deleted = await _deviceService.DeleteDeviceAsync(id);
            if (!deleted)
                return NotFound(new { message = $"Dispositivo com id '{id}' não encontrado." });

            return Ok(new { message = "Dispositivo removido com sucesso!" });
        }
    }
}
