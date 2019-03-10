<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewerCuentas.aspx.cs" Inherits="SegundoParcialWF.Reportes.ViewerCuentas" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="div1">
            <%--ScriptManager--%>
            <asp:ScriptManager runat="server"></asp:ScriptManager> 
            
            <%--Viewer--%>
            <rsweb:ReportViewer ID="MyCuentasReportViewer" runat="server" ProcessingMode="Remote" Height="718px" Width="1000px">
                <ServerReport ReportPath="" ReportServerUrl="" />
            </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
