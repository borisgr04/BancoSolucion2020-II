using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Core.Domain
{
    public class CuentaAhorro : CuentaBancaria
    {
        public CuentaAhorro(string numero, string nombre, string ciudad) : base(numero, nombre, ciudad)
        {
        }
    }
}
