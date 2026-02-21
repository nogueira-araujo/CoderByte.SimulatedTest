using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CoderByte.SimulatedTest
{
    internal static class Codeland
    {
        public static string CodelandUsernameValidation(string str)
        {
            //checa tamanho da string, se sinvalido, falso
            if (str.Length < 4 || str.Length > 25)
                return "false";

            //se termina com '_', falso
            if (str[str.Length - 1] == '_')
                return "false";

            //se não começa com letra ou se tem caracteres inválidos, falso
            if (!Regex.IsMatch(str, @"^[a-zA-Z][a-zA-Z0-9_]+$"))
                return "false";


            return "true";
        }
    }
}
