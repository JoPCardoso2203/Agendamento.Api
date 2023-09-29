using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento.Dominio.DTOs
{
    public class AmrTransportadoraMotoristaDto
    {
        public decimal? IdAmrTransportadoraMotorista { get; set; }

        [Required]
        public decimal? IdTransportadora { get; set; }

        [Required]
        public decimal? IdMotorista { get; set; }
    }
}
