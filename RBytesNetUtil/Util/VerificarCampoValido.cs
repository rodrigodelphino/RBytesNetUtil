using System;
using System.Collections.Generic;
using System.Text;

namespace RBytesNetUtil;

public static class RBytesUtil
{
    public static bool ValorComboValido(string valor, string valorInvalido = "0")
    {
        if (string.IsNullOrEmpty(valor))
            return false;

        if (valor.Equals(valorInvalido))
            return false;

        return true;
    }
}