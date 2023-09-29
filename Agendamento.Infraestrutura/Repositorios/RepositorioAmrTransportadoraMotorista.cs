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
    public class RepositorioAmrTransportadoraMotorista : RepositorioBase, IRepositorioAmrTransportadoraMotorista
    {
        public RepositorioAmrTransportadoraMotorista(IConfiguration configuration) : base(configuration)
        {
        }

        public void Adicionar(AmrTransportadoraMotorista amrTransportadoraMotorista)
        {
            string script = $@"INSERT INTO amr_transportadora_motorista (amtm_tran_id, amtm_moto_id, amtm_data_criacao) 
                       VALUES(@IdTransportadora, @IdMotorista, @DataCriacao)";
            Executar<AmrTransportadoraMotorista>(script, amrTransportadoraMotorista);
        }

        public void Atualizar(AmrTransportadoraMotorista amrTransportadoraMotorista)
        {
            string script = $@"UPDATE amr_transportadora_motorista SET 
                       amtm_tran_id = @IdTransportadora,
                       amtm_moto_id = @IdMotorista,
                       amtm_data_cancelamento = @DataCancelamento
                       WHERE amtm_id = @IdAmrTransportadoraMotorista";

            Executar<AmrTransportadoraMotorista>(script, amrTransportadoraMotorista);
        }

        public AmrTransportadoraMotorista? BuscarAmrTransportadoraMotorista(decimal? id)
        {
            string consulta = $@"SELECT 
                                    amtm_id IdAmrTransportadoraMotorista,
                                    amtm_tran_id IdTransportadora,
                                    amtm_moto_id IdMotorista,
                                    amtm_data_criacao DataCriacao,
                                    amtm_data_cancelamento DataCancelamento
                                 FROM amr_transportadora_motorista WHERE amtm_id = @Id";
            return Obter<AmrTransportadoraMotorista>(consulta, new { Id = id });
        }
        public AmrTransportadoraMotorista? BuscarAmrTransportadoraMotoristaPorIds(decimal? idTransportadora, decimal? idMotorista)
        {
            string consulta = $@"SELECT 
                                    amtm_id IdAmrTransportadoraMotorista,
                                    amtm_tran_id IdTransportadora,
                                    amtm_moto_id IdMotorista,
                                    amtm_data_criacao DataCriacao,
                                    amtm_data_cancelamento DataCancelamento
                                 FROM amr_transportadora_motorista WHERE amtm_tran_id = @IdTransportadora AND amtm_moto_id = @IdMotorista";
            return Obter<AmrTransportadoraMotorista>(consulta, new { IdTransportadora = idTransportadora, IdMotorista = idMotorista });
        }

        public List<AmrTransportadoraMotorista>? BuscarListaAmrTransportadoraMotorista()
        {
            string consulta = $@"SELECT * FROM amr_transportadora_motorista";
            return ObterLista<AmrTransportadoraMotorista>(consulta);
        }
    }
}
