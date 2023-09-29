using Agendamento.Dominio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento.Dominio.Interfaces.Servicos
{
    public interface IServicoAgendamento
    {
        List<AgendamentoDto> BuscarListaAgendamento();
        AgendamentoDto? BuscarAgendamentoPorId(decimal id);
        void SalvarAgendamento(AgendamentoDto agendamento);
        void CancelarAgendamento(decimal id);
    }
}
