using Entities;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SegundoParcialWF.Reportes
{
    public partial class ViewerCuentas : System.Web.UI.Page
    {
        Expression<Func<CuentaBancaria, bool>> filtro = p => true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MyCuentasReportViewer.ProcessingMode = ProcessingMode.Local;
                MyCuentasReportViewer.Reset();
                MyCuentasReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListadoCuentas.rdlc");
                MyCuentasReportViewer.LocalReport.DataSources.Clear();
                MyCuentasReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DepositosDS", BLL.Metodos.FCuentas(filtro)));
                MyCuentasReportViewer.LocalReport.Refresh();
            }
        }
    }
}