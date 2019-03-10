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
    public partial class ViewerPrestamos : System.Web.UI.Page
    {
        Expression<Func<Prestamo, bool>> filtro = p => true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MyPrestamosReportViewer.ProcessingMode = ProcessingMode.Local;
                MyPrestamosReportViewer.Reset();
                MyPrestamosReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListadoPrestamos.rdlc");
                MyPrestamosReportViewer.LocalReport.DataSources.Clear();
                MyPrestamosReportViewer.LocalReport.DataSources.Add(new ReportDataSource("PrestamosDS", BLL.Metodos.FPrestamos(filtro)));
                MyPrestamosReportViewer.LocalReport.Refresh();
            }
        }
    }
}