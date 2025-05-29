using ComunicaMais.API.DTOs;
using ComunicaMais.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ComunicaMais.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            var messages = await _messageService.GetMessagesAsync();
            return Ok(messages);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] MessageDto dto)
        {
            await _messageService.SendMessageAsync(dto);
            return Ok(new
            {
                message = "Mensagem enviada com sucesso!"
            });
        }
    }
}
