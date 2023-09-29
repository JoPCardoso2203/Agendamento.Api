using Agendamento.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento.Dominio.DTOs
{
    public class AgendamentoDto
    {
        public decimal? IdAgendamento { get; set; }
        public string? NumeroConteiner { get; set; }
        public DateTime? DataInicioJanela { get; set; }
        public DateTime? DataFimJanela
        {
            get
            {
                if (DataInicioJanela != null)
                    return DataInicioJanela.Value.AddHours(1);

                return null;
            }
        }
        public decimal? IdMotorista { get; set; }
        public string? NomeMotorista { get; set; }
        public string? Placa { get; set; }
        public decimal? IdTransportadora { get; set; }
        public string? Transportadora { get; set; }
        public string? Cnpj { get; set; }
    }
}
