using Agendamento.Dominio.DTOs;
using Agendamento.Dominio.Entidades;
using Agendamento.Dominio.Interfaces.Repositorios;
using Agendamento.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento.Dominio.Servicos
{
    public class ServicoTransportadora : IServicoTransportadora
    {
        private readonly IRepositorioTransportadora _repositorioTransportadora;
        private readonly IRepositorioAmrTransportadoraMotorista _repositorioAmrTransportadoraMotorista;

        public ServicoTransportadora(IRepositorioTransportadora repositorioTransportadora, IRepositorioAmrTransportadoraMotorista repositorioAmrTransportadoraMotorista)
        {
            _repositorioTransportadora = repositorioTransportadora;
            _repositorioAmrTransportadoraMotorista = repositorioAmrTransportadoraMotorista;
        }

        public List<Transportadora> BuscarListaTransportadora()
        {
            var transportadoras = _repositorioTransportadora.BuscarListaTrasportadora();

            return transportadoras ?? new List<Transportadora>();
        }

        public Transportadora? BuscarTransportadoraPorId(decimal id)
        {
            var transportadora = _repositorioTransportadora.BuscarTrasportadora(id);

            return transportadora;
        }

        public Transportadora? BuscarTransportadoraPorCnpj(string cnpj)
        {
            var transportadora = _repositorioTransportadora.BuscarTrasportadoraPorCnpj(cnpj);

            return transportadora;
        }

        public void SalvarTransportadora(Transportadora transportadora)
        {
            if (transportadora.IdTransportadora == 0)
            {
                transportadora.DataCriacao = DateTime.Now;
                _repositorioTransportadora.Adicionar(transportadora);
            }
            else
            {
                _repositorioTransportadora.Atualizar(transportadora);
            }
        }

        public void SalvarVinculo(AmrTransportadoraMotorista vinculo)
        {
            var vinculoAntigo = _repositorioAmrTransportadoraMotorista.BuscarAmrTransportadoraMotoristaPorIds(vinculo.IdTransportadora, vinculo.IdMotorista);
            if (vinculoAntigo == null) 
            {                
                vinculo.DataCriacao = DateTime.Now;
                _repositorioAmrTransportadoraMotorista.Adicionar(vinculo);
            }
            else if (vinculoAntigo.DataCancelamento != null)
            {
                vinculo.IdAmrTransportadoraMotorista = vinculoAntigo.IdAmrTransportadoraMotorista;
                vinculo.DataCriacao = vinculoAntigo.DataCriacao;
                vinculo.DataCancelamento = null;
                _repositorioAmrTransportadoraMotorista.Atualizar(vinculo);
            }
            else
            {
                throw new Exception("Já existe vínculo entre a transportadora e o motorista selecionados");
            }
        }

        public void CancelarTransportadora(decimal id)
        {
            var transportadora = _repositorioTransportadora.BuscarTrasportadora(id);
            if (transportadora != null)
            {
                transportadora.DataCancelamento = DateTime.Now;
                _repositorioTransportadora.Atualizar(transportadora);
            }
        }

        public void CancelarVinculoTransportadora(decimal? idTransportadora, decimal? idMotorista)
        {
            var vinculo = _repositorioAmrTransportadoraMotorista.BuscarAmrTransportadoraMotoristaPorIds(idTransportadora, idMotorista);

            if (vinculo != null)
            {
                vinculo.DataCancelamento = DateTime.Now;
                _repositorioAmrTransportadoraMotorista.Atualizar(vinculo);
            }
            else
            {
                throw new Exception("Vinculo não encontrado");
            }
        }
    }
}
