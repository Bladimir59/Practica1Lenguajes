using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace practicaLenguajes1
{
    class Digito
    {
        public Boolean VerificarDigito(char dato)
        {
            Regex numero = new Regex("[0-9]");
            string digito = "" + dato;
            Boolean esDigito = false;
            if(numero.IsMatch(input: digito))
            {
                esDigito = true;
            }
            return esDigito;
        }
    }
}
