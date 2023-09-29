using Agendamento.Dominio.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento.Dominio.Entidades
{
    public class Motorista
    {
        public decimal? IdMotorista { get; set; }
        public string? Nome { get; set; }
        [CnhValidation]
        public string? Cnh { get; set; }
        [CpfValidation]
        public string? Cpf { get; set; }
        public string? Placa { get; set;}
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataCancelamento { get; set; }
    }
}
