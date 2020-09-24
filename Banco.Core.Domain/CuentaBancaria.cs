using System;
using System.Collections.Generic;
using System.Linq;

namespace Banco.Core.Domain
{
    public abstract class CuentaBancaria : IServicioFinanciero
    {
        protected CuentaBancaria(string numero, string nombre, string ciudad)
        {
            Numero = numero;
            Nombre = nombre;
            Ciudad = ciudad;
            Saldo = 0;
            _movimientos = new List<CuentaBancariaMovimiento>();
        }

        public string Numero { get; }
        public string Nombre { get; }
        public string Ciudad { get; }
        public decimal Saldo { get; private set; }

        public string Consignar(decimal valorConsignacion)
        {
            if (valorConsignacion <= 0)
                return "El valor a consignar es incorrecto";

            if (valorConsignacion<50000 && NoTieneConsignacion())
                return "El valor mínimo de la primera consignación debe ser de $50.000 mil pesos. Su nuevo saldo es $0 pesos";
            var saldoAnterior = Saldo;
            Saldo += valorConsignacion;

            _movimientos.Add(new CuentaBancariaMovimiento(saldoAnterior, valorConsignacion, 0, "CONSIGNACION"));


            return $"Su Nuevo Saldo es de ${Saldo:n2} pesos m/c";
        }

        private bool NoTieneConsignacion() 
        {
            return !_movimientos.Any(t => t.Tipo == "CONSIGNACION");
        }

        private readonly List<CuentaBancariaMovimiento> _movimientos;
    }


    public class CuentaBancariaMovimiento 
    {
        public CuentaBancariaMovimiento(decimal saldoAnterior, decimal valorCredito, decimal valorDebito, string tipo)
        {
            SaldoAnterior = saldoAnterior;
            ValorCredito = valorCredito;
            ValorDebito = valorDebito;
            Tipo = tipo;
        }

        public decimal SaldoAnterior { get; private set; }
        public decimal ValorCredito { get; private set; }
        public decimal ValorDebito { get; private set; }
        public string Tipo { get; private set; }
    }
}
