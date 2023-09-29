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
    public class RepositorioMotorista : RepositorioBase, IRepositorioMotorista
    {
        public RepositorioMotorista(IConfiguration configuration) : base(configuration)
        {
        }

        public void Adicionar(Motorista motorista)
        {
            string script = $@"INSERT INTO motorista (moto_nome, moto_cnh, moto_cpf, moto_placa_veiculo, moto_data_criacao) 
                       VALUES(@Nome, @Cnh, @Cpf, @Placa, @DataCriacao)";
            Executar<Motorista>(script, motorista);
        }

        public void Atualizar(Motorista motorista)
        {
            string script = $@"UPDATE motorista SET 
                       moto_nome = @Nome,
                       moto_cnh = @Cnh,
                       moto_cpf = @Cpf,
                       moto_placa_veiculo = @Placa,
                       moto_data_cancelamento = @DataCancelamento
                       WHERE moto_id = @IdMotorista";

            Executar<Motorista>(script, motorista);
        }

        public Motorista? BuscarMotorista(decimal id)
        {
            string consulta = $@"SELECT moto_id IdMotorista,
                                    moto_nome Nome,
                                    moto_cnh Cnh,
                                    moto_cpf Cpf,
                                    moto_placa_veiculo Placa,
                                    moto_data_criacao DataCriacao,
                                    moto_data_cancelamento DataCancelamento FROM motorista WHERE moto_id = @Id";
            return Obter<Motorista>(consulta, new { Id = id });
        }

        public Motorista? BuscarMotoristaPorCpf(string cpf)
        {
            string consulta = $@"SELECT moto_id IdMotorista,
                                    moto_nome Nome,
                                    moto_cnh Cnh,
                                    moto_cpf Cpf,
                                    moto_placa_veiculo Placa,
                                    moto_data_criacao DataCriacao,
                                    moto_data_cancelamento DataCancelamento FROM motorista WHERE moto_data_cancelamento is null and moto_cpf = @Cpf";
            return Obter<Motorista>(consulta, new { Cpf = cpf });
        }

        public List<Motorista>? BuscarListaMotorista()
        {
            string consulta = $@"SELECT 
                                    moto_id IdMotorista,
                                    moto_nome Nome,
                                    moto_cnh Cnh,
                                    moto_cpf Cpf,
                                    moto_placa_veiculo Placa,
                                    moto_data_criacao DataCriacao,
                                    moto_data_cancelamento DataCancelamento
                                 FROM motorista Where moto_data_cancelamento IS NULL";
            return ObterLista<Motorista>(consulta);
        }

        public List<Motorista>? BuscarListaMotoristaPorTransportadora(decimal idTransportadora)
        {
            string consulta = $@"SELECT 
                                    moto_id IdMotorista,
                                    moto_nome Nome,
                                    moto_cnh Cnh,
                                    moto_cpf Cpf,
                                    moto_placa_veiculo Placa,
                                    moto_data_criacao DataCriacao,
                                    moto_data_cancelamento DataCancelamento
                                 FROM amr_transportadora_motorista
                                 INNER JOIN motorista on amtm_moto_id = moto_id
                                 WHERE amtm_tran_id = @Id AND amtm_data_cancelamento IS NULL";
            return ObterLista<Motorista>(consulta, new { Id = idTransportadora });
        }
    }
}
