using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento.Dominio.Entidades
{
    public class Agendamento
    {
        public decimal? IdAgendamento { get; set; }
        [Required]
        public string? NumeroConteiner { get; set; }
        [Required]
        public DateTime DataJanela { get; set; }
        [Required]
        public decimal? IdAmrTransportadoraMotorista { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataCancelamento { get; set; }
    }
}
