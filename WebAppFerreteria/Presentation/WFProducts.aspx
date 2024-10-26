<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFProducts.aspx.cs" Inherits="Presentation.WFProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="TBId" runat="server"></asp:TextBox>
    <%--Codigo--%>
    <asp:Label ID="Label1" runat="server" Text="Ingrese el Codigo"></asp:Label>
    <asp:TextBox ID="TBCode" runat="server"></asp:TextBox>
    <br />
    <%--Descripcion--%>
    <asp:Label ID="Label2" runat="server" Text="Ingrese la Descripcion"></asp:Label>
    <asp:TextBox ID="TBDescription" runat="server"></asp:TextBox>
    <br />
    <%--Cantidad--%>
    <asp:Label ID="Label3" runat="server" Text="Ingrese la Cantidad"></asp:Label>
    <asp:TextBox ID="TBQuantity" runat="server"></asp:TextBox>
    <br />
    <%--Precio--%>
    <asp:Label ID="Label4" runat="server" Text="Ingrese el Precio"></asp:Label>
    <asp:TextBox ID="TBPrice" runat="server"></asp:TextBox>
    <br />
    <%--Proveedor--%>
    <asp:Label ID="Label5" runat="server" Text="Seleccione el Proveedor"></asp:Label>
    <asp:DropDownList ID="DDLProviders" runat="server"></asp:DropDownList>
    <br />
    <%--Categorias--%>
    <asp:Label ID="Label6" runat="server" Text="Seleccione la Categoria"></asp:Label>
    <asp:DropDownList ID="DDLCategory" runat="server"></asp:DropDownList>
    <br />
    <%--Botones Guardar y Actualizar--%>
    <div>
        <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
        <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />
        <asp:Label ID="LblMsg" runat="server" Text=""></asp:Label>
    </div>
    <br />
    <%--Lista de Productos--%>
    <div>
        <asp:GridView ID="GVProducts" runat="server"></asp:GridView>
    </div>
</asp:Content>
