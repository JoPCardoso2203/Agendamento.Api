using Agendamento.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioMotorista
    {
        void Adicionar(Motorista motorista);
        void Atualizar(Motorista agendamento);
        Motorista? BuscarMotorista(decimal id);
        Motorista? BuscarMotoristaPorCpf(string cpf);
        List<Motorista>? BuscarListaMotorista();
        List<Motorista>? BuscarListaMotoristaPorTransportadora(decimal idTransportadora);
    }
}
