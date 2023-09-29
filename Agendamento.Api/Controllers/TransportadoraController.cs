using Agendamento.Dominio.Entidades;
using Agendamento.Dominio.Interfaces.Servicos;
using Agendamento.Dominio.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Agendamento.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransportadoraController : ControllerBase
    {
        private readonly IServicoTransportadora _servicoTransportadora;
        public TransportadoraController(IServicoTransportadora servicoTransportadora)
        {
            _servicoTransportadora = servicoTransportadora;
        }

        [HttpGet("ListaTransportadora")]
        public ActionResult ListaTransportadora()
        {
            return Ok(_servicoTransportadora.BuscarListaTransportadora());
        }

        [HttpGet("TransportadoraPorId")]
        public ActionResult TransportadoraPorId(decimal id)
        {
            return Ok(_servicoTransportadora.BuscarTransportadoraPorId(id));
        }

        [HttpGet("TransportadoraPorCnpj")]
        public ActionResult TransportadoraPorCnpj(string cnpj)
        {
            return Ok(_servicoTransportadora.BuscarTransportadoraPorCnpj(cnpj));
        }

        [HttpPost("SalvarTransportadora")]
        public ActionResult SalvarTransportadora(Transportadora transportadora)
        {
            _servicoTransportadora.SalvarTransportadora(transportadora);
            return Ok();
        }

        [HttpPost("SalvarVinculo")]
        public ActionResult SalvarVinculo(AmrTransportadoraMotorista vinculo)
        {
            try
            {
                _servicoTransportadora.SalvarVinculo(vinculo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpDelete("CancelarTransportadora")]
        public ActionResult CancelarTransportadora(decimal id)
        {
            _servicoTransportadora.CancelarTransportadora(id);
            return Ok();
        }

        [HttpDelete("CancelarVinculo")]
        public ActionResult CancelarVinculo(decimal idTransportadora, decimal idMotorista)
        {
            try
            {
                _servicoTransportadora.CancelarVinculoTransportadora(idTransportadora, idMotorista);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
