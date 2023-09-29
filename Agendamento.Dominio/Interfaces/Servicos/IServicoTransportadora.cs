using Agendamento.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento.Dominio.Interfaces.Servicos
{
    public interface IServicoTransportadora
    {
        List<Transportadora> BuscarListaTransportadora();
        Transportadora? BuscarTransportadoraPorId(decimal id);
        Transportadora? BuscarTransportadoraPorCnpj(string cnpj);
        void SalvarTransportadora(Transportadora transportadora);
        void SalvarVinculo(AmrTransportadoraMotorista vinculo);
        void CancelarTransportadora(decimal id);
        void CancelarVinculoTransportadora(decimal? idTransportadora, decimal? idMotorista);
    }
}
