using BLL;
using Entities;
using SegundoParcialWF.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SegundoParcialWF.Registros
{
    public partial class DepositoWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            LlenarCombo();
        }

        private void LlenarCombo()
        {
            Repositorio<CuentaBancaria> repositorio = new Repositorio<CuentaBancaria>();
            cuentaDropDownList.DataSource = repositorio.GetList(c => true);
            cuentaDropDownList.DataValueField = "CuentaBancariaId";
            cuentaDropDownList.DataTextField = "Nombre";
            cuentaDropDownList.DataBind();
        }

        public Deposito LlenarClase()
        {
            Deposito deposito = new Deposito();

            deposito.DepositoId = Utils.ToInt(depositoIdTextBox.Text);
            deposito.Fecha = Utils.ToDateTime(fechaTextBox.Text).Date;
            deposito.CuentaId = Utils.ToInt(cuentaDropDownList.SelectedValue);
            deposito.Concepto = conceptoTextBox.Text;
            deposito.Monto = Utils.ToInt(montoTextBox.Text);

            return deposito;
        }

        protected void Limpiar()
        {
            depositoIdTextBox.Text = "0";
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            cuentaDropDownList.SelectedIndex = 0;
            conceptoTextBox.Text = "";
            montoTextBox.Text = "0";
        }

        public void LlenarCampos(Deposito deposito)
        {
            Limpiar();
            depositoIdTextBox.Text = deposito.DepositoId.ToString();
            fechaTextBox.Text = deposito.Fecha.ToString("yyyy-MM-dd");
            cuentaDropDownList.SelectedIndex = deposito.CuentaId;
            conceptoTextBox.Text = deposito.Concepto;
            montoTextBox.Text = deposito.Monto.ToString();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositoDeposito repositorio = new RepositoDeposito();

            var deposito = repositorio.Buscar(Utilitarios.Utils.ToInt(depositoIdTextBox.Text));
            if (deposito != null)
            {
                LlenarCampos(deposito);
                Utils.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
            }
            else
            {
                Limpiar();
                Utils.ShowToastr(this, "No Hay Resultado", "Error", "error");
            }
        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void guadarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            RepositoDeposito repositorio = new RepositoDeposito();
            Deposito deposito = new Deposito();

            deposito = LlenarClase();

            if (deposito.DepositoId == 0)
            {
                paso = repositorio.Guardar(deposito);
                Utils.ShowToastr(this, "Guardado", "Exito", "success");
                Limpiar();
            }
            else
            {
                RepositoDeposito repository = new RepositoDeposito();
                int id = Utils.ToInt(depositoIdTextBox.Text);
                deposito = repository.Buscar(id);

                if (deposito != null)
                {
                    paso = repository.Modificar(LlenarClase());
                    Utils.ShowToastr(this, "Modificado", "Exito", "success");
                }
                else
                    Utils.ShowToastr(this, "Id no existe", "Error", "error");
            }

            if (paso)
            {
                Limpiar();
            }
            else
                Utils.ShowToastr(this, "No se pudo guardar", "Error", "error");
        }

        protected void eliminarButton_Click(object sender, EventArgs e)
        {
            RepositoDeposito repositorio = new RepositoDeposito();
            int id = Utils.ToInt(depositoIdTextBox.Text);

            var deposito = repositorio.Buscar(id);

            if (deposito != null)
            {
                if (repositorio.Eliminar(id))
                {
                    Utils.ShowToastr(this, "Eliminado", "Exito", "success");
                    Limpiar();
                }
                else
                    Utils.ShowToastr(this, "No se pudo eliminar", "Error", "error");
            }
            else
                Utils.ShowToastr(this, "No existe", "Error", "error");
        }
    }
}