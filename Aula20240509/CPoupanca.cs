using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula20240509
{
    public class CPoupanca : Conta
    {
        public CPoupanca(string numero) : base(numero)
        {
            this.limite = 0;
        }
    }
}