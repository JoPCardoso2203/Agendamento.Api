using Agendamento.Infraestrutura.Servicos;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Agendamento.Dominio.Interfaces.Repositorios;
using ZstdSharp.Unsafe;

namespace Agendamento.Infraestrutura.Dados.Repositorios
{
    public class RepositorioBase : IRepositorioBase
    {
        IConfiguration _configuracao;

        public RepositorioBase(IConfiguration configuration)
        {
            _configuracao = configuration;
        }

        public void Executar<T>(string query, object? parametros)
        {
            using var db = ServicoConnection.ObterConexao(_configuracao);
            var result = db.Execute(query, parametros);
        }

        public T? Obter<T>(string consulta, object? parametros = null)
        {
            using var db = ServicoConnection.ObterConexao(_configuracao);
            var retorno = db.Query<T>(consulta, parametros).FirstOrDefault();
            return retorno;
        }

        public List<T> ObterLista<T>(string consulta, object? parametros = null)
        {
            using var db = ServicoConnection.ObterConexao(_configuracao);
            var retorno = db.Query<T>(consulta, parametros).ToList();
            return retorno;
        }
    }
}
