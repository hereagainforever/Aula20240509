﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula20240509
{
    public class Transacao
    {
        public double valor;
        public char tipo;
        public Transacao duplicata;
        public Transacao(double valor, char tipo)
        {
            this.valor = valor;
            this.tipo = tipo;
        }
    }
}