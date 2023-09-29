using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento.Dominio.Validacoes
{
    public class CnhValidationAttribute : ValidationAttribute
    {
        public CnhValidationAttribute() { }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            bool isValid = false;

            var cnh = value?.ToString() ?? "";

            if (cnh.Length == 11 && cnh != new string(cnh[0], 11))
            {
                var dsc = 0;
                var v = 0;
                for (int i = 0, j = 9; i < 9; i++, j--)
                {
                    v += (Convert.ToInt32(cnh[i].ToString()) * j);
                }

                var digito1 = v % 11;
                if (digito1 >= 10)
                {
                    digito1 = 0;
                    dsc = 2;
                }

                v = 0;
                for (int i = 0, j = 1; i < 9; ++i, ++j)
                {
                    v += (Convert.ToInt32(cnh[i].ToString()) * j);
                }

                var x = v % 11;
                var digito2 = (x >= 10) ? 0 : x - dsc;

                isValid = cnh.EndsWith(digito1.ToString() + digito2.ToString());
            }

            if (isValid)
                return ValidationResult.Success;

            return new ValidationResult("Número de CNH inválido");
        }
    }
}
