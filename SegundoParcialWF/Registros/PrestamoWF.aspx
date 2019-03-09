<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PrestamoWF.aspx.cs" Inherits="SegundoParcialWF.Registros.PrestamoWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br>
    <div class="form-row justify-content-center">
        <aside class="col-sm-8">
            <div class="card">
                <div class="card-header text-uppercase text-center text-primary">Préstamo</div>
                <article class="card-body">
                    <form>
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label3" runat="server" Text="Id"></asp:Label>
                                    <asp:Button class="btn btn-info btn-sm" ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                                    <asp:TextBox class="form-control" ID="prestamoIdTextBox" Text="0" type="number" runat="server" Width="100px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="IdRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="prestamoIdTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*No puede estar vacío</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="IdREV" runat="server" ErrorMessage="Solo Números" ForeColor="Red" ValidationExpression="^[0-9]*$" ControlToValidate="prestamoIdTextBox" ValidationGroup="Guardar">Solo Números</asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                        <asp:Image ID="Image" runat="server" Height="288px" ImageUrl="~/Resources/depositphotos_56006431-stock-photo-loan-approved-means-lending-passed.jpg" runat="server" Width="289px" AlternateText="Imagen no disponible" ImageAlign="right" />
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label10" runat="server" Text="Fecha"></asp:Label>
                                    <asp:TextBox class="form-control" ID="fechaTextBox" type="date" runat="server" Width="200px"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <br>
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label7" runat="server" Text="Cuenta"></asp:Label>
                                    <asp:DropDownList class="form-control" ID="cuentaDropDownList" runat="server" Width="200px">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <br>
                        <!-- form-group// -->
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label4" runat="server" Text="Capital"></asp:Label>
                                    <asp:TextBox class="form-control" ID="capitalTextBox" runat="server" Width="200px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="CRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="capitalTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*No puede estar vacío</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="CREV" runat="server" ErrorMessage="Solo Números" ForeColor="Red" ValidationExpression="^[0-9]*$" ControlToValidate="capitalTextBox" ValidationGroup="Guardar">Solo Números</asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label2" runat="server" Text="Pociento de Interés"></asp:Label>
                                    <asp:TextBox class="form-control" ID="pctIntTextBox" runat="server" Width="200px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PIRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="pctIntTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*No puede estar vacío</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="PIREV" runat="server" ErrorMessage="Solo Números" ForeColor="Red" ValidationExpression="^[0-9]*$" ControlToValidate="pctIntTextBox" ValidationGroup="Guardar">Solo Números</asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label6" runat="server" Text="Tiempo en Meses"></asp:Label>
                                    <asp:TextBox class="form-control" ID="tieMesTextBox" runat="server" Width="200px"></asp:TextBox>
                                    <asp:Button Text="Calcular" class="btn btn-warning btn-sm" runat="server" ID="agregarButton" OnClick="agregarButton_Click" />
                                    <asp:RequiredFieldValidator ID="TMRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="tieMesTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*No puede estar vacío</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="TMREV" runat="server" ErrorMessage="Solo Números" ForeColor="Red" ValidationExpression="^[0-9]*$" ControlToValidate="tieMesTextBox" ValidationGroup="Guardar">Solo Números</asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                        <asp:GridView ID="prestamoGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="Black" GridLines="None" BackColor="White">
                            <AlternatingRowStyle BackColor="#999999" />
                            <Columns>
                                <asp:BoundField DataField="NumeroCuota" HeaderText="Cuota" />
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                <asp:BoundField DataField="Interes" HeaderText="Interes" />
                                <asp:BoundField DataField="CapitalMensual" HeaderText="Capital" />
                                <asp:BoundField DataField="Balance" HeaderText="Balance" />
                            </Columns>
                            <HeaderStyle BackColor="#999999" Font-Bold="True" />
                        </asp:GridView>
                        <!-- form-group// -->
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label1" runat="server" Text="Total"></asp:Label>
                                    <asp:TextBox class="form-control" ID="totalTextBox" Text="0" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <asp:ValidationSummary ID="VS" runat="server" />
                        <!-- form-group// -->
                        <div class="panel-footer">
                            <div class="text-center">
                                <div class="form-group" style="display: inline-block">
                                    <asp:Button Text="Nuevo" class="btn btn-dark btn-sm" runat="server" ID="nuevoButton" OnClick="nuevoButton_Click" />
                                    <asp:Button Text="Guardar" class="btn btn-success btn-sm" runat="server" ID="guadarButton" OnClick="guadarButton_Click" ValidationGroup="Guardar" />
                                    <asp:Button Text="Eliminar" class="btn btn-danger btn-sm" runat="server" ID="eliminarButton" OnClick="eliminarButton_Click" />
                                </div>
                            </div>
                        </div>
                        <!-- form-group// -->
                    </form>
                </article>
            </div>
            <!-- card.// -->
    </div>
    <br>
</asp:Content>
