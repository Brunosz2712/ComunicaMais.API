using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComunicaMais.API.Models
{
    public class Message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Indica que o banco gera o valor
        public int MessageId { get; set; }

        public string Sender { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime Timestamp { get; set; }

        public string DeviceId { get; set; } = null!;
        public Device Device { get; set; } = null!;
    }
}
