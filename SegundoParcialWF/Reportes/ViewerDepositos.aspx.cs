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
    public partial class ViewerDepositos : System.Web.UI.Page
    {
        Expression<Func<Deposito, bool>> filtro = p => true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MyDepositosReportViewer.ProcessingMode = ProcessingMode.Local;
                MyDepositosReportViewer.Reset();
                MyDepositosReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListadoDepositos.rdlc");
                MyDepositosReportViewer.LocalReport.DataSources.Clear();
                MyDepositosReportViewer.LocalReport.DataSources.Add(new ReportDataSource("CuentasDS", BLL.Metodos.FDepositos(filtro)));
                MyDepositosReportViewer.LocalReport.Refresh();
            }
        }
    }
}