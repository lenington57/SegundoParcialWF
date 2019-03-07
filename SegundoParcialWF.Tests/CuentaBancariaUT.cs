using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BLL;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SegundoParcialWF.Tests
{
    [TestClass]
    public class CuentaBancariaUT
    {
        [TestMethod]
        public void Guardar()
        {
            Repositorio<CuentaBancaria> repositorio = new Repositorio<CuentaBancaria>();
            CuentaBancaria cuenta = new CuentaBancaria();
            bool paso = false;

            cuenta.CuentaBancariaId = 4;
            cuenta.Fecha = DateTime.Now;
            cuenta.Nombre = "Juan";
            cuenta.Balance = 0;

            paso = repositorio.Guardar(cuenta);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Modificar()
        {
            var cuenta = BuscarM();
            Repositorio<CuentaBancaria> repositorio = new Repositorio<CuentaBancaria>();

            bool paso = false;
            cuenta.Nombre = "Alfredo";
            paso = repositorio.Modificar(cuenta);
            Assert.AreEqual(true, paso);
        }

        public CuentaBancaria BuscarM()
        {
            int id = 3;
            Repositorio<CuentaBancaria> repositorio = new Repositorio<CuentaBancaria>();
            CuentaBancaria cuenta = new CuentaBancaria();
            cuenta = repositorio.Buscar(id);
            return cuenta;
        }

        [TestMethod]
        public void Eliminar()
        {
            Repositorio<CuentaBancaria> repositorio = new Repositorio<CuentaBancaria>();
            int id = 4;
            bool paso = false;
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Buscar()
        {
            int id = 3;
            Repositorio<CuentaBancaria> repositorio = new Repositorio<CuentaBancaria>();
            CuentaBancaria cuenta = new CuentaBancaria();
            cuenta = repositorio.Buscar(id);
            Assert.IsNotNull(cuenta);
        }

        [TestMethod()]
        public void GetList()
        {
            Repositorio<CuentaBancaria> repositorio = new Repositorio<CuentaBancaria>();
            List<CuentaBancaria> lista = new List<CuentaBancaria>();
            Expression<Func<CuentaBancaria, bool>> resultados = p => true;
            lista = repositorio.GetList(resultados);
            Assert.IsNotNull(lista);
        }
    }
}
