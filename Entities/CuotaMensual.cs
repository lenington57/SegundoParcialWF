using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class CuotaMensual
    {
        [Key]
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public int PrestamoId { get; set; }

        public int NumeroCuota { get; set; }

        public int CuentaId { get; set; }

        public double Interes { get; set; }

        public double CapitalMensual { get; set; }

        public double Balance { get; set; }

        [ForeignKey("CuentaId")]
        public virtual CuentaBancaria CuentaBancaria { get; set; }


        public CuotaMensual()
        {
            Id = 0;
            Fecha = DateTime.Now;
            PrestamoId = 0;
            NumeroCuota = 0;
            CuentaId = 0;
            Interes = 0;
            CapitalMensual = 0;
            Balance = 0;
        }

        public CuotaMensual(int id, DateTime fecha, int prestamoId, int numeroCuota, int cuentaId, double interes, double capitalMensual, double balance)
        {
            Id = id;
            Fecha = fecha;
            PrestamoId = prestamoId;
            NumeroCuota = numeroCuota;
            CuentaId = cuentaId;
            Interes = interes;
            CapitalMensual = capitalMensual;
            Balance = balance;
        }
    }
}
