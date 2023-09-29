using Agendamento.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento.Dominio.Interfaces.Servicos
{
    public interface IServicoMotorista
    {
        List<Motorista> BuscarListaMotorista();
        List<Motorista> BuscarListaMotoristaPorTransportadora(decimal idTransportadora);
        Motorista? BuscarMotoristaPorId(decimal id);
        Motorista? BuscarMotoristaPorCpf(string cpf);
        void SalvarMotorista(Motorista motorista);
        void CancelarMotorista(decimal id);
    }
}
