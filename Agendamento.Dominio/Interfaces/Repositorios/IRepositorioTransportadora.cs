using Agendamento.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioTransportadora
    {
        void Adicionar(Transportadora transportadora);
        void Atualizar(Transportadora transportadora);
        Transportadora? BuscarTrasportadora(decimal id);
        Transportadora? BuscarTrasportadoraPorCnpj(string cnpj);
        List<Transportadora>? BuscarListaTrasportadora();
    }
}
