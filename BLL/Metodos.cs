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

        public static List<CuentaBancaria> FCuentas(Expression<Func<CuentaBancaria, bool>> filtro)
        {
            filtro = p => true;
            Repositorio<CuentaBancaria> repositorio = new Repositorio<CuentaBancaria>();
            List<CuentaBancaria> list = new List<CuentaBancaria>();

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<Deposito> FDepositos(Expression<Func<Deposito, bool>> filtro)
        {
            filtro = p => true;
            Repositorio<Deposito> repositorio = new Repositorio<Deposito>();
            List<Deposito> list = new List<Deposito>();

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<Prestamo> FPrestamos(Expression<Func<Prestamo, bool>> filtro)
        {
            filtro = p => true;
            Repositorio<Prestamo> repositorio = new Repositorio<Prestamo>();
            List<Prestamo> list = new List<Prestamo>();

            list = repositorio.GetList(filtro);

            return list;
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

        public static List<Prestamo> FiltrarPrestamos(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<Prestamo, bool>> filtro = p => true;
            Repositorio<Prestamo> repositorio = new Repositorio<Prestamo>();
            List<Prestamo> list = new List<Prestamo>();

            int id = ToInt(criterio);
            switch (index)
            {
                case 0://Todo
                    break;

                case 1://Todo por fecha
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://PrestamoId
                    filtro = p => p.PrestamoId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 3://CuentaId
                    filtro = p => p.CuentaId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;                    
            }

            list = repositorio.GetList(filtro);

            return list;
        }


        //Lista para el Detalle.
        public static List<CuotaMensual> ListaDetalle(int IdLista)
        {
            Repositorio<CuotaMensual> repositorio = new Repositorio<CuotaMensual>();
            List<CuotaMensual> list = new List<CuotaMensual>();
            int id = IdLista;
            list = repositorio.GetList(c => c.PrestamoId == id);

            return list;
        }
    }
}
