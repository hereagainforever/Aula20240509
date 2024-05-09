using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula20240509
{
    public class CCorrente : Conta
    {
        public bool especial;

        public CCorrente(string numero, double limite) : base(numero)
        {
            this.limite = limite;
        }
    }
}