using Agendamento.Dominio.Validacoes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento.Dominio.DTOs
{
    public class TransportadoraDto
    {
        public decimal? IdTransportadora { get; set; }

        [Required]
        public string? RazaoSocial { get; set; }

        [Required]
        public string? NomeFantasia { get; set; }

        [Required]
        [CnpjValidation]
        public string? CNPJ { get; set; }
    }
}
