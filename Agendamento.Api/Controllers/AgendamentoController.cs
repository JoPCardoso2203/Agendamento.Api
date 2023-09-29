using Agendamento.Dominio.DTOs;
using Agendamento.Dominio.Interfaces.Servicos;
using Agendamento.Dominio.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Agendamento.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgendamentoController : ControllerBase
    {
        private readonly IServicoAgendamento _servicoAgendamento;
        public AgendamentoController(IServicoAgendamento servicoAgendamento)
        {
            _servicoAgendamento = servicoAgendamento;
        }

        [HttpGet("ListaAgendamento")]
        public ActionResult ListaAgendamento()
        {
            return Ok(_servicoAgendamento.BuscarListaAgendamento());
        }

        [HttpGet("AgendamentoPorId")]
        public ActionResult AgendamentoPorId(decimal id)
        {
            return Ok(_servicoAgendamento.BuscarAgendamentoPorId(id));
        }

        [HttpPost("SalvarAgendamento")]
        public ActionResult SalvarAgendamento(AgendamentoDto agendamento)
        {
            try
            {
                _servicoAgendamento.SalvarAgendamento(agendamento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("CancelarAgendamento")]
        public ActionResult CancelarAgendamento(decimal id)
        {
            _servicoAgendamento.CancelarAgendamento(id);
            return Ok();
        }
    }
}
