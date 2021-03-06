﻿using SegundoParcialWF.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SegundoParcialWF.Consultas
{
    public partial class CPrestamoWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);

            return retorno;
        }

        protected void buscarLinkButton_Click(object sender, EventArgs e)
        {
            int id = Utils.ToInt(CriterioTextBox.Text);
            int index = ToInt(FiltroDropDownList.SelectedIndex);
            DateTime desde = Utils.ToDateTime(DesdeTextBox.Text);
            DateTime hasta = Utils.ToDateTime(HastaTextBox.Text);
            UsuarioGridView.DataSource = BLL.Metodos.FiltrarPrestamos(index, CriterioTextBox.Text, desde, hasta);
            UsuarioGridView.DataBind();

            criterioLabel.Text = FiltroDropDownList.Text.ToString();
        }

        protected void ImprimirLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Reportes/ViewerPrestamos.aspx");
        }
    }
}