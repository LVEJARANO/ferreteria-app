<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFProducts.aspx.cs" Inherits="Presentation.WFProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--Estilos--%>
    <link href="resources/css/datatables.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card m-1">
        <div class="card-header">
            Gestión de Productos
        </div>
        <div class="card-body">
            <form id="FrmProduct" runat="server">
                <%--Id--%>
                <asp:HiddenField ID="HFProductID" runat="server" />
                <div class="row m-1">
                    <div class="col-2">
                        <%--Codigo--%>
                        <asp:Label ID="Label1" CssClass="form-label" runat="server" Text="Ingrese el Codigo"></asp:Label>
                        <asp:TextBox ID="TBCode" CssClass="form-control" runat="server"></asp:TextBox>
                        <%--Valida que el TextBox este lleno--%>
                        <asp:RequiredFieldValidator ID="RFVCode"
                            runat="server"
                            ControlToValidate="TBCode"
                            ForeColor="Red"
                            Display="Dynamic"
                            ErrorMessage="Este campo es obligatorio.">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="col-8">
                        <%--Descripcion--%>
                        <asp:Label ID="Label2" CssClass="form-label" runat="server" Text="Ingrese la Descripcion"></asp:Label>
                        <asp:TextBox ID="TBDescription" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-2">
                        <%--Cantidad--%>
                        <asp:Label ID="Label3" CssClass="form-label" runat="server" Text="Ingrese la Cantidad"></asp:Label>
                        <asp:TextBox ID="TBQuantity" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row m-1">
                    <div class="col-2">
                        <%--Precio--%>
                        <asp:Label ID="Label4" CssClass="form-label" runat="server" Text="Ingrese el Precio"></asp:Label>
                        <asp:TextBox ID="TBPrice" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-5">
                        <%--Proveedor--%>
                        <asp:Label ID="Label5" CssClass="form-label" runat="server" Text="Proveedor"></asp:Label>
                        <asp:DropDownList ID="DDLProviders" CssClass="form-select" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-5">
                        <%--Categorias--%>
                        <asp:Label ID="Label6" CssClass="form-label" runat="server" Text="Categoria"></asp:Label>
                        <asp:DropDownList ID="DDLCategory" CssClass="form-select" runat="server"></asp:DropDownList>
                        <%--Valida que el DropDownList este seleccionado con algun valor--%>
                        <asp:RequiredFieldValidator ID="RFVCategory" runat="server"
                            ControlToValidate="DDLCategory"
                            InitialValue=""
                            ErrorMessage="Debes seleccionar una Categoria."
                            ForeColor="Red">
                        </asp:RequiredFieldValidator>
                        <br />
                    </div>
                </div>
                <div class="row m-1">
                    <div class="col">
                        <%--Botones Guardar y Actualizar--%>
                        <asp:Button ID="BtnSave" CssClass="btn btn-success" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
                        <asp:Button ID="BtnUpdate" runat="server" CssClass="btn btn-primary" Text="Actualizar" OnClick="BtnUpdate_Click" />
                        <asp:Label ID="LblMsg" CssClass="form-label" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </form>
        </div>
    </div>

    <div class="card m-1">
        <%--Panel para la gestion del Administrador--%>
        <asp:Panel ID="PanelAdmin" runat="server">
            <div class="card-header">
                Lista de Proveedores
            </div>
            <div class="card-body">
                <%--Lista de Productos--%>
                <table id="productsTable" class="table table-hover display" style="width: 100%">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Codigo</th>
                            <th>Descripcion</th>
                            <th>Cantidad</th>
                            <th>Precio</th>
                            <th>FkCategoria</th>
                            <th>Categoria</th>
                            <th>FkProveedor</th>
                            <th>Proveedor</th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
            </div>
        </asp:Panel>
    </div>

    <script src="resources/js/datatables.min.js" type="text/javascript"></script>

    <%--Productos--%>
    <script type="text/javascript">
        $(document).ready(function () {
            const showEditButton = '<%= _showEditButton %>' === 'True';
            const showDeleteButton = '<%= _showDeleteButton %>' === 'True';
            $('#productsTable').DataTable({
                "processing": true,
                "serverSide": false,
                "ajax": {
                    "url": "WFProducts.aspx/ListProducts",// Se invoca el WebMethod Listar Productos
                    "type": "POST",
                    "contentType": "application/json",
                    "data": function (d) {
                        return JSON.stringify(d);// Convierte los datos a JSON
                    },
                    "dataSrc": function (json) {
                        return json.d.data;// Obtiene la lista de productos del resultado
                    }
                },
                "columns": [
                    { "data": "ProductID" },
                    { "data": "Code" },
                    { "data": "Description" },
                    { "data": "Quantity" },
                    { "data": "Price" },
                    { "data": "FkCategory", "visible": false },
                    { "data": "NameCategory" },
                    { "data": "FkProvider", "visible": false },
                    { "data": "NameProvider" },
                    {
                        "data": null,
                        "render": function (row) {
                            let buttons = '';
                            if (showEditButton) {
                                buttons += `<button class="btn btn-info edit-btn" data-id="${row.ProductID}">Editar</button>`;
                            }
                            if (showDeleteButton) {
                                buttons += `<button class="btn btn-danger delete-btn" data-id="${row.ProductID}">Eliminar</button>`;
                            }
                            return buttons;
                        }
                    }
                ],
                "language": {
                    "lengthMenu": "Mostrar _MENU_ registros por página",
                    "zeroRecords": "No se encontraron resultados",
                    "info": "Mostrando página _PAGE_ de _PAGES_",
                    "infoEmpty": "No hay registros disponibles",
                    "infoFiltered": "(filtrado de _MAX_ registros totales)",
                    "search": "Buscar:",
                    "paginate": {
                        "first": "Primero",
                        "last": "Último",
                        "next": "Siguiente",
                        "previous": "Anterior"
                    }
                }

            });

            // Editar un producto
            $('#productsTable').on('click', '.edit-btn', function () {
                //const id = $(this).data('id');
                const rowData = $('#productsTable').DataTable().row($(this).parents('tr')).data();
                //alert(JSON.stringify(rowData, null, 2));
                loadProductData(rowData);
            });

            // Eliminar un producto
            $('#productsTable').on('click', '.delete-btn', function () {
                const id = $(this).data('id');// Obtener el ID del producto
                if (confirm("¿Estás seguro de que deseas eliminar este producto?")) {
                    deleteProduct(id);// Invoca a la función para eliminar el producto
                }
            });
        });

        // Cargar los datos en los TextBox y DDL para actualizar
        function loadProductData(rowData) {
            $('#<%= HFProductID.ClientID %>').val(rowData.ProductID);
            $('#<%= TBCode.ClientID %>').val(rowData.Code);
            $('#<%= TBDescription.ClientID %>').val(rowData.Description);
            $('#<%= TBQuantity.ClientID %>').val(rowData.Quantity);
            $('#<%= TBPrice.ClientID %>').val(rowData.Price);
            $('#<%= DDLProviders.ClientID %>').val(rowData.FkProvider);
            $('#<%= DDLCategory.ClientID %>').val(rowData.FkCategory);
        }

        // Función para eliminar un producto
        function deleteProduct(id) {
            $.ajax({
                type: "POST",
                url: "WFProducts.aspx/DeleteProduct",// Se invoca el WebMethod Eliminar un Producto
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({ id: id }),
                success: function (response) {
                    $('#productsTable').DataTable().ajax.reload();// Recargar la tabla después de eliminar
                    alert("Producto eliminado exitosamente.");
                },
                error: function () {
                    alert("Error al eliminar el producto.");
                }
            });
        }
    </script>
</asp:Content>
