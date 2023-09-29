using Agendamento.Dominio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioAgendamento
    {
        void Adicionar(Entidades.Agendamento agendamento);
        void Atualizar(Entidades.Agendamento agendamento);
        Entidades.Agendamento? BuscarAgendamento(decimal id);
        List<Entidades.Agendamento> BuscarListaAgendamentoVinculo(decimal id);
        List<Entidades.Agendamento> BuscarListaAgendamentoPorConteiner(string conteiner);
        List<Dominio.Entidades.Agendamento> BuscarListaAgendamentoMotorista(decimal id);
        List<AgendamentoDto>? BuscarListaAgendamento();
        AgendamentoDto? BuscarAgendamentoPorId(decimal id);

    }
}
