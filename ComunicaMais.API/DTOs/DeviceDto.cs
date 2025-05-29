using System;

namespace ComunicaMais.API.DTOs
{
    public class DeviceDto
    {
        public string DeviceId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime? LastSeen { get; set; }
    }
}
