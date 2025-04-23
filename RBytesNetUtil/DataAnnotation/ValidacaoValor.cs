using System;
using System.ComponentModel.DataAnnotations;

namespace RBytesNetUtil.DataAnnotation
{
    public class ValidacaoValorAttribute : ValidationAttribute
    {
        public ValidacaoValorAttribute()
       : base("O Valor {0}. Não é um valor válido.") { }

        public ValidacaoValorAttribute(bool permitirNulo)
      : base("O Valor {0}. Não é um valor válido.") { }


        public override bool IsValid(object value)
        {
            return ValidarValor(value);
        }

        protected override ValidationResult IsValid(
      object value, ValidationContext validationContext)
        {
            if (!ValidarValor(value))
            {
                return new ValidationResult("O valor informado não é válido.");
            }

            return ValidationResult.Success;
        }

        private bool ValidarValor(object value)
        {
            try
            {
                if (value == null)
                    return true;

                decimal valor;

                if (!decimal.TryParse((String)value, 
                                            out valor))
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
