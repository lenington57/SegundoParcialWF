using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class CuentaBancaria
    {
        [Key]
        public int CuentaBancariaId { get; set; }

        public DateTime Fecha { get; set; }

        public string Nombre { get; set; }

        public int Balance { get; set; }


        public CuentaBancaria()
        {
            CuentaBancariaId = 0;
            Fecha = DateTime.Now;
            Nombre = string.Empty;
            Balance = 0;
        }

        public void AgregarDetalle(int cuentaBancariaId, DateTime fecha, string nombre, int balance)
        {
            CuentaBancariaId = cuentaBancariaId;
            Fecha = fecha;
            Nombre = nombre;
            Balance = balance;
        }

    }
}
