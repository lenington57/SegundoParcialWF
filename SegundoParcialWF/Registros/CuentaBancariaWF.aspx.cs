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
    public partial class CuentaBancariaWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            balanceTextBox.Text = "0";
        }

        private void Limpiar()
        {
            cuentaBancariaIdTextBox.Text = "0";
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            nombreTextBox.Text = " ";
            balanceTextBox.Text = "0";
        }

        private CuentaBancaria LlenaClase()
        {
            CuentaBancaria cuenta = new CuentaBancaria();

            cuenta.CuentaBancariaId = Utils.ToInt(cuentaBancariaIdTextBox.Text);
            cuenta.Fecha = Convert.ToDateTime(fechaTextBox.Text).Date;
            cuenta.Nombre = nombreTextBox.Text;
            cuenta.Balance = Utils.ToInt(balanceTextBox.Text);

            return cuenta;

        }

        protected void buscarButton_Click(object sender, EventArgs e)
        {
            Repositorio<CuentaBancaria> repositorio = new Repositorio<CuentaBancaria>();
            CuentaBancaria cuenta = repositorio.Buscar(Utils.ToInt(cuentaBancariaIdTextBox.Text));
            if (cuenta != null)
            {
                fechaTextBox.Text = cuenta.Fecha.ToString();
                nombreTextBox.Text = cuenta.Nombre;
                balanceTextBox.Text = cuenta.Balance.ToString();
                Utils.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
            }
            else
            {
                Utils.ShowToastr(this, "No Hay Resultado", "Error", "error");
            }
        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void guadarButton_Click(object sender, EventArgs e)
        {
            BLL.Repositorio<CuentaBancaria> repositorio = new BLL.Repositorio<CuentaBancaria>();
            CuentaBancaria cuenta = new CuentaBancaria();
            bool paso = false;

            //todo: validaciones adicionales
            cuenta = LlenaClase();

            if (cuenta.CuentaBancariaId == 0)
            {
                paso = repositorio.Guardar(cuenta);
                Utils.ShowToastr(this, "Guardado", "Exito", "success");
                Limpiar();
            }
            else
            {
                int id = Utils.ToInt(cuentaBancariaIdTextBox.Text);
                BLL.Repositorio<CuentaBancaria> repository = new BLL.Repositorio<CuentaBancaria>();
                cuenta = repository.Buscar(id);

                if (cuenta != null)
                {
                    paso = repositorio.Modificar(LlenaClase());
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
            BLL.Repositorio<CuentaBancaria> repositorio = new BLL.Repositorio<CuentaBancaria>();
            int id = Utils.ToInt(cuentaBancariaIdTextBox.Text);

            var cuenta = repositorio.Buscar(id);

            if (cuenta != null)
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