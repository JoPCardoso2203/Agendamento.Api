using Agendamento.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioAmrTransportadoraMotorista
    {
        void Adicionar(AmrTransportadoraMotorista amrTransportadoraMotorista);
        void Atualizar(AmrTransportadoraMotorista amrTransportadoraMotorista);
        AmrTransportadoraMotorista? BuscarAmrTransportadoraMotorista(decimal? id);
        AmrTransportadoraMotorista? BuscarAmrTransportadoraMotoristaPorIds(decimal? idTransportadora, decimal? idMotorista);
        List<AmrTransportadoraMotorista>? BuscarListaAmrTransportadoraMotorista();
    }
}
