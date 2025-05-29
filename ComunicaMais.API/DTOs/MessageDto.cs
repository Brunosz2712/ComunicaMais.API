using System;

namespace ComunicaMais.API.DTOs
{
    public class MessageDto
    {
        public string Sender { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string DeviceId { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }  // pode ser usado para exibir
    }
}
