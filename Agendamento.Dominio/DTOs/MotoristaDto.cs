using Agendamento.Dominio.Validacoes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento.Dominio.DTOs
{
    public class MotoristaDto
    {
        [Required]
        public string? Nome { get; set; }

        [Required]
        [CnhValidation]
        public string? CNH { get; set; }

        [Required]
        [CpfValidation]
        public string? CPF { get; set; }

        [Required]
        [RegularExpression("[a-zA-Z]{3}[0-9][0-9A-Za-z][0-9]{2}", ErrorMessage = "Número de Placa inválido")]
        public string? Placa { get; set; }
    }
}
