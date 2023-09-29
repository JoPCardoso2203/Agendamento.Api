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
    public class ServicoMotorista : IServicoMotorista
    {
        private readonly IRepositorioMotorista _repositorioMotorista;

        public ServicoMotorista(IRepositorioMotorista repositorioMotorista)
        {
            _repositorioMotorista = repositorioMotorista;
        }

        public List<Motorista> BuscarListaMotorista()
        {
            var motoristas = _repositorioMotorista.BuscarListaMotorista();

            return motoristas ?? new List<Motorista>();
        }

        public List<Motorista> BuscarListaMotoristaPorTransportadora(decimal idTransportadora)
        {
            var motoristas = _repositorioMotorista.BuscarListaMotoristaPorTransportadora(idTransportadora);

            return motoristas ?? new List<Motorista>();
        }

        public Motorista? BuscarMotoristaPorId(decimal id)
        {
            var motorista = _repositorioMotorista.BuscarMotorista(id);

            return motorista;
        }

        public Motorista? BuscarMotoristaPorCpf(string cpf)
        {
            var motorista = _repositorioMotorista.BuscarMotoristaPorCpf(cpf);

            return motorista;
        }

        public void SalvarMotorista(Motorista motorista)
        {
            if(motorista.IdMotorista == 0)
            {

                var motoristaCpf = _repositorioMotorista.BuscarMotoristaPorCpf(motorista.Cpf ?? "");
                if (motoristaCpf != null && motoristaCpf.DataCancelamento == null)
                {
                    throw new Exception("Já existe registro cadastrado com o CPF informado");
                }
                else if(motoristaCpf != null && motoristaCpf.DataCancelamento != null)
                {
                    motorista.DataCriacao = motoristaCpf.DataCriacao;
                    _repositorioMotorista.Atualizar(motorista);
                }
                else
                {
                    motorista.DataCriacao = DateTime.Now;
                    _repositorioMotorista.Adicionar(motorista);
                }
            }
            else
            {
                var motoristaCpf = _repositorioMotorista.BuscarMotoristaPorCpf(motorista.Cpf ?? "");
                if (motoristaCpf != null && motorista.IdMotorista != motoristaCpf.IdMotorista)
                {
                    throw new Exception("Já existe registro cadastrado com o CPF informado");
                }
                else
                {
                    _repositorioMotorista.Atualizar(motorista);
                }
            }
        }

        public void CancelarMotorista(decimal id)
        {
            var motorista = _repositorioMotorista.BuscarMotorista(id);
            if (motorista != null)
            {
                motorista.DataCancelamento = DateTime.Now;
                _repositorioMotorista.Atualizar(motorista);
            }
        }
    }
}
