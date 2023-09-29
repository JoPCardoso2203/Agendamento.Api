using Agendamento.Dominio.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento.Dominio.Entidades
{
    public class Transportadora
    {
        public decimal? IdTransportadora { get; set; }
        public string? RazaoSocial { get; set; }
        public string? NomeFantasia { get; set; }
        [CnpjValidation]
        public string? Cnpj { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataCancelamento { get; set; }
    }
}
