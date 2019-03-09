using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioPrestamo : Repositorio<Prestamo>
    {
        public override bool Guardar(Prestamo prestamo)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Prestamo.Add(prestamo);
                contexto.CuentaBancaria.Find(prestamo.CuentaId).Balance += prestamo.Total;
                contexto.SaveChanges();
                paso = true;

            }
            catch (Exception)
            {
                throw;
            }


            return paso;
        }

        public override bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                Prestamo prestamo = contexto.Prestamo.Find(id);
                contexto.CuentaBancaria.Find(prestamo.CuentaId).Balance -= prestamo.Total;
                contexto.Prestamo.Remove(prestamo);
                contexto.SaveChanges();
                paso = true;
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public static void CambiarBalances(Prestamo prestamo, Prestamo prestamoAnt)
        {
            Repositorio<CuentaBancaria> repositorio = new Repositorio<CuentaBancaria>();
            Repositorio<CuentaBancaria> repository = new Repositorio<CuentaBancaria>();
            Contexto contexto = new Contexto();
            var Cuenta = contexto.CuentaBancaria.Find(prestamo.CuentaId);
            var CuentaAnt = contexto.CuentaBancaria.Find(prestamoAnt.CuentaId);

            Cuenta.Balance += prestamo.Total;
            CuentaAnt.Balance -= prestamoAnt.Total;
            repositorio.Modificar(Cuenta);
            repository.Modificar(CuentaAnt);
        }

        public override bool Modificar(Prestamo prestamo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                Prestamo PreAnt = contexto.Prestamo.Find(prestamo.PrestamoId);

                var cuenta = contexto.CuentaBancaria.Find(prestamo.CuentaId);

                if (prestamo.CuentaId != PreAnt.CuentaId)
                {
                    CambiarBalances(prestamo, PreAnt);
                }
                else
                {
                    int diferencia = prestamo.Total - PreAnt.Total;
                    cuenta.Balance += diferencia;
                }
                contexto = new Contexto();
                contexto.Entry(prestamo).State = EntityState.Modified;

                contexto.SaveChanges();
                paso = true;

            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public override Prestamo Buscar(int id)
        {
            Prestamo prestamo = new Prestamo();
            try
            {
                prestamo = _contexto.Prestamo.Find(id);
                prestamo.Detalle.Count();

                foreach (var item in prestamo.Detalle)
                {
                    string s = item.CuentaBancaria.Nombre;
                }

            }
            catch (Exception)
            {

                throw;
            }
            return prestamo;
        }

    }
}
