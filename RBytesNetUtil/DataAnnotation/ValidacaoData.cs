using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace RBytesNetUtil.DataAnnotation
{
    public class ValidacaoDataAttribute : ValidationAttribute
    {
        public ValidacaoDataAttribute()
       : base("O Valor {0} Não é uma data válida.") { }
        public override bool IsValid(object value)
        {
            return ValidarData(value);
        }

        protected override ValidationResult IsValid(
      object value, ValidationContext validationContext)
        {
            if (!ValidarData(value))
            {
                return new ValidationResult("A data informada não é válida.");
            }

            return ValidationResult.Success;
        }

        private bool ValidarData(object value)
        {
            try
            {
                if (value == null)
                    return true;

                DateTime DataValida;

                if (!DateTime.TryParseExact((String)value, "dd/MM/yyyy",
                                            CultureInfo.InvariantCulture,
                                            DateTimeStyles.None,
                                            out DataValida))
                {
                    return false;
                }

            }
            catch(Exception)
            {
                return false;
            }

            return true;
        }

    }
}
