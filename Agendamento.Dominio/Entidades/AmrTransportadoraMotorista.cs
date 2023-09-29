using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento.Dominio.Entidades
{
    public class AmrTransportadoraMotorista
    {
        public decimal? IdAmrTransportadoraMotorista { get; set; }
        public decimal? IdTransportadora { get; set; }
        public decimal? IdMotorista { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataCancelamento { get; set; }
    }
}
