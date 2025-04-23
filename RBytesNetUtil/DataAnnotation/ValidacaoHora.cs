using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace RBytesNetUtil.DataAnnotation
{
    public class ValidacaoHoraAttribute : ValidationAttribute
    {
        public ValidacaoHoraAttribute()
       : base("O Valor {0} Não é uma hora válida.") { }
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

                if (!DateTime.TryParseExact((String)value, "HH:mm",
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
