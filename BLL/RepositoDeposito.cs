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
    public class RepositoDeposito : Repositorio<Deposito>
    {
        public override bool Guardar(Deposito deposito)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Deposito.Add(deposito);
                contexto.CuentaBancaria.Find(deposito.CuentaId).Balance += deposito.Monto;
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
                Deposito deposito = contexto.Deposito.Find(id);
                contexto.CuentaBancaria.Find(deposito.CuentaId).Balance -= deposito.Monto;
                contexto.Deposito.Remove(deposito);
                contexto.SaveChanges();
                paso = true;
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public static void CambiarBalances(Deposito deposito, Deposito depositoAnt)
        {
            Repositorio<CuentaBancaria> repositorio = new Repositorio<CuentaBancaria>();
            Repositorio<CuentaBancaria> repository = new Repositorio<CuentaBancaria>();
            Contexto contexto = new Contexto();
            var Cuenta = contexto.CuentaBancaria.Find(deposito.CuentaId);
            var CuentaAnt = contexto.CuentaBancaria.Find(depositoAnt.CuentaId);

            Cuenta.Balance += deposito.Monto;
            CuentaAnt.Balance -= depositoAnt.Monto;
            repositorio.Modificar(Cuenta);
            repository.Modificar(CuentaAnt);
        }

        public override bool Modificar(Deposito deposito)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                Deposito DepAnt = contexto.Deposito.Find(deposito.DepositoId);

                var cuenta = contexto.CuentaBancaria.Find(deposito.CuentaId);

                if (deposito.CuentaId != DepAnt.CuentaId)
                {
                    CambiarBalances(deposito, DepAnt);
                }
                else
                {
                    int diferencia = deposito.Monto - DepAnt.Monto;
                    cuenta.Balance += diferencia;
                }
                contexto = new Contexto();
                contexto.Entry(deposito).State = EntityState.Modified;

                contexto.SaveChanges();
                paso = true;

            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

    }
}
