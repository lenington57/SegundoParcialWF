using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SegundoParcialWF.Utilitarios;

namespace SegundoParcialWF.Registros
{
    public partial class PrestamoWF : System.Web.UI.Page
    {
        List<CuotaMensual> listDetalle = new List<CuotaMensual>();

        protected void Page_Load(object sender, EventArgs e)
        {
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");

            if (!Page.IsPostBack)
            {
                Repositorio<CuentaBancaria> repositorio = new Repositorio<CuentaBancaria>();

                cuentaDropDownList.DataSource = repositorio.GetList(t => true);
                cuentaDropDownList.DataValueField = "CuentaBancariaId";
                cuentaDropDownList.DataTextField = "Nombre";
                cuentaDropDownList.DataBind();

                ViewState["Prestamo"] = new Prestamo();
            }
        }

        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);

            return retorno;
        }
        private double ToDouble(object valor)
        {
            double retorno = 0;
            double.TryParse(valor.ToString(), out retorno);

            return Convert.ToDouble(retorno);
        }

        public Prestamo LlenarClase()
        {
            Prestamo prestamo = new Prestamo();

            prestamo = (Prestamo)ViewState["Prestamo"];
            listDetalle = (List<CuotaMensual>)prestamoGridView.DataSource;

            prestamo.PrestamoId = Utils.ToInt(prestamoIdTextBox.Text);
            prestamo.Fecha = Convert.ToDateTime(fechaTextBox.Text).Date;
            prestamo.CuentaId = ToInt(cuentaDropDownList.SelectedValue);
            prestamo.Capital = ToInt(capitalTextBox.Text);
            prestamo.PctInteres = ToInt(pctIntTextBox.Text);
            prestamo.TiempoMeses = ToInt(tieMesTextBox.Text);
            prestamo.Total = ToInt(totalTextBox.Text);
            prestamo.Detalle = listDetalle;

            return prestamo;
        }

        protected void BindGrid()
        {
            prestamoGridView.DataSource = ((Prestamo)ViewState["Prestamo"]).Detalle;
            prestamoGridView.DataBind();
        }

        public void LlenarCampos(Prestamo prestamo)
        {
            Limpiar();
            prestamoIdTextBox.Text = prestamo.PrestamoId.ToString();
            fechaTextBox.Text = prestamo.Fecha.ToString("yyyy-MM-dd");
            cuentaDropDownList.SelectedValue = prestamo.CuentaId.ToString();
            capitalTextBox.Text = prestamo.Capital.ToString();
            pctIntTextBox.Text = prestamo.PctInteres.ToString();
            tieMesTextBox.Text = prestamo.TiempoMeses.ToString();
            prestamoGridView.DataSource = prestamo.Detalle.ToList();
            this.BindGrid();
            totalTextBox.Text = prestamo.Total.ToString();
        }
        protected void Limpiar()
        {
            prestamoIdTextBox.Text = "0";
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            cuentaDropDownList.SelectedIndex = 0;
            capitalTextBox.Text = "";
            pctIntTextBox.Text = "";
            tieMesTextBox.Text = "";
            totalTextBox.Text = "";
            ViewState["Prestamo"] = new Prestamo();
            this.BindGrid();
        }

        private bool HayErrores()
        {
            bool HayErrores = false;

            if (prestamoGridView.Rows.Count == 0)
            {
                Utils.ShowToastr(this, "Debe calcular su Préstamo.", "Error", "error");
                HayErrores = true;
            }
            if (ToInt(cuentaDropDownList.SelectedValue) < 1)
            {
                Utils.ShowToastr(this, "Debe Seleccionar una Cuenta que haya guardada.", "Error", "error");
                HayErrores = true;
            }
            return HayErrores;
        }

        protected void agregarButton_Click(object sender, EventArgs e)
        {
            int NumCuota = 1;
            DateTime date = DateTime.Now.Date;
            double capital = ToDouble(capitalTextBox.Text);
            int Meses = ToInt(tieMesTextBox.Text);
            double IntereAnual = ToDouble(pctIntTextBox.Text);
            IntereAnual /= 100;
            var dat = new DateTime(2019, 03, 15);

            double TotalInteres = capital * IntereAnual;
            double CapitalMensual = capital / Meses;
            double CInteres = TotalInteres / Meses;
            double Mensualidad = CapitalMensual + CInteres;
            double Balance = capital + TotalInteres;
            int CuentaId = ToInt(cuentaDropDownList.SelectedValue);

            Prestamo prestamo = new Prestamo();
            for (int i = 1; i <= Meses; i++)
            {
                Balance -= Mensualidad;
                if (Balance < 0)
                    Balance = 0;
                prestamo = (Prestamo)ViewState["Prestamo"];
                prestamo.AgregarDetalle(0, dat.AddMonths(i), prestamo.PrestamoId, NumCuota, CuentaId, 
                    CInteres, CapitalMensual, Balance);

                ViewState["Prestamo"] = prestamo;
                BindGrid();
                NumCuota++;   
            }
            double Total = TotalInteres + capital;
            totalTextBox.Text = Total.ToString();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Prestamo> repositorio = new Repositorio<Prestamo>();

            var prestamo = repositorio.Buscar(Utils.ToInt(prestamoIdTextBox.Text));
            if (prestamo != null)
            {
                LlenarCampos(prestamo);
                Utils.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
            }
            else
            {
                Limpiar();
                Utils.ShowToastr(this, "No se pudo encontrar el Préstamo especificado", "Error", "error");
            }
        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void guadarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            RepositorioPrestamo repositorio = new RepositorioPrestamo();
            Prestamo prestamo = new Prestamo();

            if (HayErrores())
            {
                return;
            }
            else
            {
                prestamo = LlenarClase();

                if (ToInt(prestamoIdTextBox.Text) == 0)
                {
                    paso = repositorio.Guardar(prestamo);
                    Utils.ShowToastr(this, "Guardado", "Exito", "success");
                    Limpiar();
                }
                else
                {
                    RepositorioPrestamo repository = new RepositorioPrestamo();
                    int id = ToInt(prestamoIdTextBox.Text);
                    prestamo = repository.Buscar(id);

                    if (prestamo != null)
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
        }

        protected void eliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioPrestamo repositorio = new RepositorioPrestamo();
            int id = ToInt(prestamoIdTextBox.Text);

            var prestamo = repositorio.Buscar(id);

            if (prestamo != null)
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