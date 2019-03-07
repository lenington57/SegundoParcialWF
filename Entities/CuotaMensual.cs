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

        public int CuentaId { get; set; }

        public double Interes { get; set; }

        public double Capital { get; set; }

        public double Balance { get; set; }

        [ForeignKey("CuentaId")]
        public virtual CuentaBancaria CuentaBancaria { get; set; }


        public CuotaMensual()
        {
            Id = 0;
            Fecha = DateTime.Now;
            CuentaId = 0;
            Interes = 0;
            Capital = 0;
            Balance = 0;
        }

        public CuotaMensual(int id, DateTime fecha, int cuentaId, double interes, double capital, double balance)
        {
            Id = id;
            Fecha = fecha;
            CuentaId = cuentaId;
            Interes = interes;
            Capital = capital;
            Balance = balance;
        }
    }
}
