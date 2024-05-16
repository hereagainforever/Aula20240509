using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula20240509
{
    public class CCorrente : Conta
    {
        private bool especial;

        
        public bool Especial { get => this.especial; }


        public CCorrente(string numero, double limite) : base(numero)
        {
            this.limite = limite;
        }
    }
}