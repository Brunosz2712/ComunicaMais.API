using System;
using System.Collections.Generic;

namespace ComunicaMais.API.Models
{
    public class Device
    {
        public string DeviceId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime? LastSeen { get; set; }

        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
