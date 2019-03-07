using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Prestamo
    {
        [Key]
        public int PrestamoId { get; set; }

        public DateTime Fecha { get; set; }

        public int CuentaId { get; set; }

        public double PctInteres { get; set; }

        public int TiempoMeses { get; set; }

        public int Monto { get; set; }

        public virtual List<CuotaMensual> Detalle { get; set; }


        public Prestamo()
        {
            this.Detalle = new List<CuotaMensual>();
        }

        public void AgregarDetalle(int Id, DateTime Fecha, int CuentaId, double Interes, double Capital, double Balance)
        {
            this.Detalle.Add(new CuotaMensual(Id, Fecha, CuentaId, Interes, Capital, Balance));
        }

    }
}
