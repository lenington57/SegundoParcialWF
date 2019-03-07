using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Metodos
    {
        public static int ToInt(string valor)
        {
            int retorno = 0;
            int.TryParse(valor, out retorno);

            return retorno;
        }

        public static List<CuentaBancaria> FiltrarCuentas(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<CuentaBancaria, bool>> filtro = p => true;
            Repositorio<CuentaBancaria> repositorio = new Repositorio<CuentaBancaria>();
            List<CuentaBancaria> list = new List<CuentaBancaria>();

            int id = ToInt(criterio);
            switch (index)
            {
                case 0://Todo
                    break;

                case 1://Todo por fecha
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://CuentaId
                    filtro = p => p.CuentaBancariaId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 3://Nombre
                    filtro = p => p.Nombre.Contains(criterio) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<Deposito> FiltrarDepositos(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<Deposito, bool>> filtro = p => true;
            Repositorio<Deposito> repositorio = new Repositorio<Deposito>();
            List<Deposito> list = new List<Deposito>();

            int id = ToInt(criterio);
            switch (index)
            {
                case 0://Todo
                    break;

                case 1://Todo por fecha
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://DepositoId
                    filtro = p => p.DepositoId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 3://CuentaId
                    filtro = p => p.CuentaId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 4://Nombre
                    filtro = p => p.Concepto.Contains(criterio) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }

            list = repositorio.GetList(filtro);

            return list;
        }

    }
}
