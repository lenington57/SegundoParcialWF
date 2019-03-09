<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CuentaBancariaWF.aspx.cs" Inherits="SegundoParcialWF.Registros.CuentaBancariaWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br>
    <div class="form-row justify-content-center">
        <aside class="col-sm-6">
            <div class="card">
                <div class="card-header text-uppercase text-center">Cuenta Bancaria</div>
                <article class="card-body">
                    <form>
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label3" runat="server" Text="Id"></asp:Label>
                                    <asp:Button class="btn btn-info btn-sm" ID="buscarButton" runat="server" Text="Buscar" OnClick="buscarButton_Click" />
                                    <asp:TextBox class="form-control" ID="cuentaBancariaIdTextBox" type="number" Text="0" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="IdRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="cuentaBancariaIdTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="IdREV" runat="server" ErrorMessage="Solo Números" ForeColor="Red" ValidationExpression="^[0-9]*$" ControlToValidate="cuentaBancariaIdTextBox" ValidationGroup="Guardar">Solo Números</asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                        <asp:Image ID="CategoriasImage" runat="server" Height="215px" ImageUrl="~/Resources/cuenta-bancaria.png" runat="server" Width="222px" AlternateText="Imagen no disponible" ImageAlign="right" />
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label10" runat="server" Text="Fecha"></asp:Label>
                                    <asp:TextBox class="form-control" ID="fechaTextBox" type="date" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <br>
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label4" runat="server" Text="Nombre"></asp:Label>
                                    <asp:TextBox class="form-control" ID="nombreTextBox" placeholder="Nombre" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="NombreRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="nombreTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="NombreREV" runat="server" ErrorMessage="Solo Letras" ControlToValidate="nombreTextBox" ForeColor="Red" ValidationExpression="^[a-z &amp; A-Z]*$" ValidationGroup="Guardar">Solo Letras</asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label1" runat="server" Text="Balance Pendiente"></asp:Label>
                                    <asp:TextBox class="form-control" ID="balanceTextBox" type="number" Text="0" runat="server" ReadOnly="True"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="BalanceRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="balanceTextBox" ForeColor="Red" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="BalanceREV" runat="server" ErrorMessage="Solo Números" ForeColor="Red" ValidationExpression="^[0-9]*$" ControlToValidate="balanceTextBox" ValidationGroup="Guardar">Solo Números</asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                        <asp:ValidationSummary ID="CuentaVS" runat="server" />
                        <div class="panel-footer">
                            <div class="text-center">
                                <div class="form-group" style="display: inline-block">
                                    <asp:Button Text="Nuevo" class="btn btn-dark btn-sm" runat="server" ID="nuevoButton" OnClick="nuevoButton_Click" />
                                    <asp:Button Text="Guardar" class="btn btn-success btn-sm" runat="server" ID="guadarButton" OnClick="guadarButton_Click" ValidationGroup="Guardar" />
                                    <asp:Button Text="Eliminar" class="btn btn-danger btn-sm" runat="server" ID="eliminarButton" OnClick="eliminarButton_Click" />
                                </div>
                            </div>
                        </div>
                    </form>
                </article>
            </div>
            <!-- card.// -->
            <br>
    </div>
<br>
</asp:Content>
