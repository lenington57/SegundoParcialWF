using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BLL;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SegundoParcialWF.Tests
{
    [TestClass]
    public class DepositoUT
    {
        [TestMethod]
        public void Guardar()
        {
            RepositoDeposito repositorio = new RepositoDeposito();
            Deposito deposito = new Deposito();
            bool paso = false;

            deposito.DepositoId = 3;
            deposito.Fecha = DateTime.Now;
            deposito.CuentaId = 3;
            deposito.Concepto = "Pago de Lenington";
            deposito.Monto = 200;

            paso = repositorio.Guardar(deposito);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Modificar()
        {
            var deposito = BuscarM();
            RepositoDeposito repositorio = new RepositoDeposito();

            bool paso = false;
            deposito.Concepto = "Pago de Alfredo";
            paso = repositorio.Modificar(deposito);
            Assert.AreEqual(true, paso);
        }

        public Deposito BuscarM()
        {
            int id = 2;
            RepositoDeposito repositorio = new RepositoDeposito();
            Deposito deposito = new Deposito();
            deposito = repositorio.Buscar(id);
            return deposito;
        }

        [TestMethod]
        public void Eliminar()
        {
            RepositoDeposito repositorio = new RepositoDeposito();
            int id = 3;
            bool paso = false;
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Buscar()
        {
            int id = 1;
            Repositorio<Deposito> repositorio = new Repositorio<Deposito>();
            Deposito deposito = new Deposito();
            deposito = repositorio.Buscar(id);
            Assert.IsNotNull(deposito);
        }

        [TestMethod()]
        public void GetList()
        {
            Repositorio<Deposito> repositorio = new Repositorio<Deposito>();
            List<Deposito> lista = new List<Deposito>();
            Expression<Func<Deposito, bool>> resultados = p => true;
            lista = repositorio.GetList(resultados);
            Assert.IsNotNull(lista);
        }
    }
}
