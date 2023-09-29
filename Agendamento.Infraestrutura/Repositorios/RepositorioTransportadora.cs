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
    public class RepositorioTransportadora : RepositorioBase, IRepositorioTransportadora
    {
        public RepositorioTransportadora(IConfiguration configuration) : base(configuration)
        {
        }

        public void Adicionar(Transportadora transportadora)
        {
            string script = $@"INSERT INTO transportadora (tran_razao_social, tran_nome_fantasia, tran_cnpj, tran_data_criacao) 
                               VALUES(@RazaoSocial, @NomeFantasia, @Cnpj, @DataCriacao)";
            Executar<Transportadora>(script, transportadora);
        }

        public void Atualizar(Transportadora transportadora)
        {
            string script = $@"UPDATE transportadora SET 
                               tran_razao_social = @RazaoSocial,
                               tran_nome_fantasia = @NomeFantasia,
                               tran_cnpj = @Cnpj,
                               tran_data_cancelamento = @DataCancelamento
                               WHERE tran_id = @IdTransportadora";

            Executar<Transportadora>(script, transportadora);
        }

        public Transportadora? BuscarTrasportadora(decimal id)
        {
            string consulta = $@"SELECT tran_id IdTransportadora,
                                    tran_razao_social RazaoSocial,
                                    tran_nome_fantasia NomeFantasia,
                                    tran_cnpj Cnpj,
                                    tran_data_criacao DataCriacao,
                                    tran_data_cancelamento DataCancelamento 
                                 FROM transportadora WHERE tran_id = @Id";
            return Obter<Transportadora>(consulta, new { Id = id });
        }

        public Transportadora? BuscarTrasportadoraPorCnpj(string cnpj)
        {
            string consulta = $@"SELECT tran_id IdTransportadora,
                                    tran_razao_social RazaoSocial,
                                    tran_nome_fantasia NomeFantasia,
                                    tran_cnpj Cnpj,
                                    tran_data_criacao DataCriacao,
                                    tran_data_cancelamento DataCancelamento 
                                 FROM transportadora WHERE tran_cnpj = @Cnpj";
            return Obter<Transportadora>(consulta, new { Cnpj = cnpj });
        }

        public List<Transportadora>? BuscarListaTrasportadora()
        {
            string consulta = $@"SELECT 
                                    tran_id IdTransportadora,
                                    tran_razao_social RazaoSocial,
                                    tran_nome_fantasia NomeFantasia,
                                    tran_cnpj Cnpj,
                                    tran_data_criacao DataCriacao,
                                    tran_data_cancelamento DataCancelamento
                                 FROM transportadora WHERE tran_data_cancelamento IS NULL";
            return ObterLista<Transportadora>(consulta);
        }
    }
}
