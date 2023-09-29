using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento.Infraestrutura.Servicos
{
    public class ServicoConnection
    {
        public static MySqlConnection ObterConexao(IConfiguration configuracao)
        {
            var connectionString = configuracao["ConnectionStrings:ConnectionDB"];
            MySqlConnection conexao = new MySqlConnection(connectionString);
            return conexao;
        }
    }
}
