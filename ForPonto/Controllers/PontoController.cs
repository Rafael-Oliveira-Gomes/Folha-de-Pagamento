using ForPonto.Interface.Service;
using ForPonto.Model;
using ForPonto.Model.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ForPonto.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PontoController : ControllerBase
    {
        private readonly ILogger<PontoController> _logger;
        private readonly IPontoService _pontoService;

        public PontoController(ILogger<PontoController> logger, IPontoService pontoService)
        {
            _logger = logger;
            _pontoService = pontoService;
        }

        [HttpPost(template: "BaterPonto")]
        public async Task<IActionResult> BaterPonto()
        {
            try
            {
                var result = await _pontoService.AdicionarPonto();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(1, $"Erro: {nameof(PontoController)} - {ex.Message}" +
                    $"\n {ex.InnerException}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ConsultarPontoToday")]
        public async Task<IActionResult> ConsultarPontoToday()
        {
            try
            {
                var ponto = await _pontoService.ConsultarPontoToday();
                return Ok(ponto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
