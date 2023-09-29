using Agendamento.Dominio.Entidades;
using Agendamento.Dominio.Interfaces.Servicos;
using Agendamento.Dominio.Servicos;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Agendamento.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MotoristaController : ControllerBase
    {
        private readonly IServicoMotorista _servicoMotorista;
        public MotoristaController(IServicoMotorista servicoMotorista)
        {
            _servicoMotorista = servicoMotorista;
        }

        [HttpGet("ListaMotorista")]
        public ActionResult ListaMotorista()
        {
            return Ok(_servicoMotorista.BuscarListaMotorista());
        }

        [HttpGet("ListaMotoristaPorTransportadora")]
        public ActionResult ListaMotoristaPorTransportadora(decimal id)
        {
            return Ok(_servicoMotorista.BuscarListaMotoristaPorTransportadora(id));
        }

        [HttpGet("MotoristaPorId")]
        public ActionResult MotoristaPorId(decimal id)
        {
            return Ok(_servicoMotorista.BuscarMotoristaPorId(id));
        }

        [HttpGet("MotoristaPorCpf")]
        public ActionResult MotoristaPorCpf(string cpf)
        {
            return Ok(_servicoMotorista.BuscarMotoristaPorCpf(cpf));
        }

        [HttpPost("SalvarMotorista")]
        public ActionResult SalvarMotorista(Motorista motorista)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _servicoMotorista.SalvarMotorista(motorista);
                    return Ok();
                }

                return BadRequest(new { message = "Erro ao cadastrar Motorista" });
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("CancelarMotorista")]
        public ActionResult CancelarMotorista(decimal id)
        {
            _servicoMotorista.CancelarMotorista(id);
            return Ok();
        }
    }
}
