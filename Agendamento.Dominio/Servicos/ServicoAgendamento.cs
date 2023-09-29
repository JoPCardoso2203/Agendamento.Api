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
    public class ServicoAgendamento : IServicoAgendamento
    {
        private readonly IRepositorioAgendamento _repositorioAgendamento;
        private readonly IRepositorioAmrTransportadoraMotorista _repositorioAmrTransportadoraMotorista;
        public ServicoAgendamento(IRepositorioAgendamento repositorioAgendamento, IRepositorioAmrTransportadoraMotorista repositorioAmrTransportadoraMotorista)
        {
            _repositorioAgendamento = repositorioAgendamento;
            _repositorioAmrTransportadoraMotorista = repositorioAmrTransportadoraMotorista;
        }

        public List<AgendamentoDto> BuscarListaAgendamento()
        {
            var agendamentos = _repositorioAgendamento.BuscarListaAgendamento();

            agendamentos = agendamentos?.Where(p => DateTime.Now < p.DataFimJanela).ToList();

            return agendamentos ?? new List<AgendamentoDto>();
        }

        public AgendamentoDto? BuscarAgendamentoPorId(decimal id)
        {
            var agendamento = _repositorioAgendamento.BuscarAgendamentoPorId(id);

            return agendamento;
        }

        public void SalvarAgendamento(AgendamentoDto agendamento)
        {
            var vinculo = _repositorioAmrTransportadoraMotorista.BuscarAmrTransportadoraMotoristaPorIds(agendamento.IdTransportadora, agendamento.IdMotorista);

            if (vinculo != null)
            {
                List<Dominio.Entidades.Agendamento> agendamentosVinculoValidos = _repositorioAgendamento.BuscarListaAgendamentoMotorista(agendamento.IdMotorista ?? 0);

                agendamentosVinculoValidos = agendamentosVinculoValidos.Where(p => p.DataCancelamento == null && DateTime.Now < p.DataJanela.AddHours(1)).ToList();

                if (agendamentosVinculoValidos.Count > 0 && agendamentosVinculoValidos?.FirstOrDefault()?.IdAgendamento != agendamento.IdAgendamento)
                {
                    throw new Exception("Já existe um agendamento ativo para o motorista selecionado");
                }
            }

            List<Entidades.Agendamento> agendamentosConteiner = _repositorioAgendamento.BuscarListaAgendamentoPorConteiner(agendamento?.NumeroConteiner?.ToUpper() ?? "");

            agendamentosConteiner = agendamentosConteiner.Where(p => p.DataCancelamento == null && DateTime.Now.CompareTo(p.DataJanela.AddHours(1)) <= 0).ToList();

            if (agendamentosConteiner.Count > 0 && agendamentosConteiner?.FirstOrDefault()?.IdAgendamento != agendamento?.IdAgendamento)
            {
                throw new Exception("Já existe um agendamento ativo com o contêiner selecionado");
            }


            if (agendamento?.IdAgendamento == 0)
            {
                var agendamentoNovo = new Entidades.Agendamento()
                {
                    DataCriacao = DateTime.Now,
                    DataJanela = agendamento.DataInicioJanela ?? new DateTime(),
                    NumeroConteiner = agendamento.NumeroConteiner,
                    IdAmrTransportadoraMotorista = vinculo?.IdAmrTransportadoraMotorista
                };

                _repositorioAgendamento.Adicionar(agendamentoNovo);
            }
            else
            {
                var agendamentoNovo = _repositorioAgendamento.BuscarAgendamento(agendamento?.IdAgendamento ?? 0);
                if (agendamentoNovo != null)
                {
                    if(DateTime.Now.CompareTo(agendamentoNovo.DataJanela.AddHours(-1)) > 0)
                    {
                        throw new Exception("Só é permitido alterar o agendamento em até uma hora antes da janela");
                    }

                    agendamentoNovo.DataJanela = agendamento?.DataInicioJanela ?? new DateTime();
                    agendamentoNovo.IdAmrTransportadoraMotorista = vinculo?.IdAmrTransportadoraMotorista;

                    if (agendamentoNovo != null)
                    {
                        _repositorioAgendamento.Atualizar(agendamentoNovo);
                    }
                }
            }
        }

        public void CancelarAgendamento(decimal id)
        {
            var agendamento = _repositorioAgendamento.BuscarAgendamento(id);
            if (agendamento != null)
            {
                agendamento.DataCancelamento = DateTime.Now;
                _repositorioAgendamento.Atualizar(agendamento);
            }
        }
    }
}
