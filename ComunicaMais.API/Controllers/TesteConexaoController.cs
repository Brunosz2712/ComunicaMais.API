using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using Microsoft.Extensions.Configuration;

namespace ComunicaMais.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TesteConexaoController : ControllerBase
    {
        private readonly IConfiguration _config;

        public TesteConexaoController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public IActionResult TestarConexao()
        {
            var connectionString = _config.GetConnectionString("DefaultConnection");

            try
            {
                using var connection = new OracleConnection(connectionString);
                connection.Open();
                return Ok("✅ Conexão com o Oracle realizada com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"❌ Erro na conexão: {ex.Message}");
            }
        }
    }
}
