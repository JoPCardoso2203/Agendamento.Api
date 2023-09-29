using Agendamento.Dominio.DTOs;
using Agendamento.Dominio.Entidades;
using Agendamento.Dominio.Interfaces.Repositorios;
using Agendamento.Infraestrutura.Dados.Repositorios;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento.Infraestrutura.Repositorios
{
    public class RepositorioAgendamento : RepositorioBase, IRepositorioAgendamento
    {
        public RepositorioAgendamento(IConfiguration configuration) : base(configuration)
        {
        }

        public void Adicionar(Dominio.Entidades.Agendamento agendamento)
        {
            string script = $@"INSERT INTO agendamento (agen_numero_conteiner, agen_data_janela, agen_amtm_id, agen_data_criacao) 
                               VALUES(@NumeroConteiner, @DataJanela, @IdAmrTransportadoraMotorista, @DataCriacao)";
            Executar<Dominio.Entidades.Agendamento>(script, agendamento);
        }

        public void Atualizar(Dominio.Entidades.Agendamento agendamento) 
        {
            string script = $@"UPDATE agendamento SET 
                               agen_numero_conteiner = @NumeroConteiner, 
                               agen_data_janela = @DataJanela, 
                               agen_amtm_id = @IdAmrTransportadoraMotorista,
                               agen_data_cancelamento = @DataCancelamento
                               WHERE agen_id = @IdAgendamento";

            Executar<Dominio.Entidades.Agendamento>(script, agendamento);
        }

        public Dominio.Entidades.Agendamento? BuscarAgendamento(decimal id)
        {
            string consulta = $@"SELECT 
                                    agen_id IdAgendamento,
                                    agen_numero_conteiner NumeroConteiner,
                                    agen_data_janela DataJanela,
                                    agen_amtm_id IdAmrTransportadoraMotorista,
                                    agen_data_criacao DataCriacao,
                                    agen_data_cancelamento DataCancelamento
                                 FROM agendamento WHERE agen_id = @Id";
            return Obter<Dominio.Entidades.Agendamento>(consulta, new { Id = id });
        }

        public List<Dominio.Entidades.Agendamento> BuscarListaAgendamentoPorConteiner(string conteiner)
        {
            string consulta = $@"SELECT 
                                    agen_id IdAgendamento,
                                    agen_numero_conteiner NumeroConteiner,
                                    agen_data_janela DataJanela,
                                    agen_amtm_id IdAmrTransportadoraMotorista,
                                    agen_data_criacao DataCriacao,
                                    agen_data_cancelamento DataCancelamento
                                 FROM agendamento WHERE agen_numero_conteiner = @Conteiner";
            return ObterLista<Dominio.Entidades.Agendamento>(consulta, new { Conteiner = conteiner });
        }

        public List<Dominio.Entidades.Agendamento> BuscarListaAgendamentoVinculo(decimal id)
        {
            string consulta = $@"SELECT 
                                    agen_id IdAgendamento,
                                    agen_numero_conteiner NumeroConteiner,
                                    agen_data_janela DataJanela,
                                    agen_amtm_id IdAmrTransportadoraMotorista,
                                    agen_data_criacao DataCriacao,
                                    agen_data_cancelamento DataCancelamento
                                 FROM agendamento WHERE agen_amtm_id = @Id";
            return ObterLista<Dominio.Entidades.Agendamento>(consulta, new { Id = id });
        }

        public List<Dominio.Entidades.Agendamento> BuscarListaAgendamentoMotorista(decimal id)
        {
            string consulta = $@"SELECT 
                                    agen_id IdAgendamento,
                                    agen_numero_conteiner NumeroConteiner,
                                    agen_data_janela DataJanela,
                                    agen_amtm_id IdAmrTransportadoraMotorista,
                                    agen_data_criacao DataCriacao,
                                    agen_data_cancelamento DataCancelamento
                                 FROM agendamento 
                                 INNER JOIN amr_transportadora_motorista ON amtm_id = agen_amtm_id
                                 WHERE amtm_moto_id = @Id";
            return ObterLista<Dominio.Entidades.Agendamento>(consulta, new { Id = id });
        }

        public List<AgendamentoDto>? BuscarListaAgendamento()
        {
            string consulta = $@"SELECT 
                                    agen_id IdAgendamento,
                                    agen_numero_conteiner NumeroConteiner,
                                    agen_data_janela DataInicioJanela,
                                    moto_nome NomeMotorista,
                                    moto_placa_veiculo Placa,
                                    tran_nome_fantasia Transportadora
                                 FROM agendamento
                                 INNER JOIN amr_transportadora_motorista ON amtm_id = agen_amtm_id
                                 INNER JOIN motorista ON moto_id = amtm_moto_id
                                 INNER JOIN transportadora ON tran_id = amtm_tran_id
                                 WHERE agen_data_cancelamento IS NULL";
            return ObterLista<AgendamentoDto>(consulta);
        }

        public AgendamentoDto? BuscarAgendamentoPorId(decimal id)
        {
            string consulta = $@"SELECT 
                                    agen_id IdAgendamento,
                                    agen_numero_conteiner NumeroConteiner,
                                    agen_data_janela DataInicioJanela,
                                    moto_nome NomeMotorista,
                                    moto_placa_veiculo Placa,
                                    tran_nome_fantasia Transportadora,
                                    tran_cnpj Cnpj
                                 FROM agendamento
                                 INNER JOIN amr_transportadora_motorista ON amtm_id = agen_amtm_id
                                 INNER JOIN motorista ON moto_id = amtm_moto_id
                                 INNER JOIN transportadora ON tran_id = amtm_tran_id
                                 WHERE agen_id = @Id";
            return Obter<AgendamentoDto>(consulta, new { Id = id });
        }
    }
}
