using Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFProducts : System.Web.UI.Page
    {
        //Crear los objetos
        ProductsLog objProd = new ProductsLog();
        ProvidersLog objPro = new ProvidersLog();
        CategoryLog objCat = new CategoryLog();

        private int _id, _quantity, _fkCategory, _fkProvider;
        private string _code, _description;
        private double _price;
        private bool executed = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                //Aqui se invocan todos los metodos
                //showProducts();
                showProvidersDDL();
                showCategoriesDDL();
            }
        }
        //Metodo para mostrar todos los productos
        /*
      * Atributo [WebMethod] en ASP.NET, permite que el método sea expuesto como 
      * parte de un servicio web, lo que significa que puede ser invocado de manera
      * remota a través de HTTP.
      */
        [WebMethod]
        public static object ListProducts()
        {
            ProductsLog objProd = new ProductsLog();

            // Se obtiene un DataSet que contiene la lista de productos desde la base de datos.
            var dataSet = objProd.showProducts();

            // Se crea una lista para almacenar los productos que se van a devolver.
            var productsList = new List<object>();

            // Se itera sobre cada fila del DataSet (que representa un producto).
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                productsList.Add(new
                {
                    ProductID = row["pro_id"],
                    Code = row["pro_codigo"],
                    Description = row["pro_descripcion"],
                    Quantity = row["pro_cantidad"],
                    Price = row["pro_precio"],
                    FkCategory = row["tbl_categoria_cat_id"],
                    NameCategory = row["cat_descripcion"],
                    FkProvider = row["tbl_proveedor_prov_id"],
                    NameProvider = row["prov_nombre"]
                });
            }

            // Devuelve un objeto en formato JSON que contiene la lista de productos.
            return new { data = productsList };
        }

        [WebMethod]
        public static bool DeleteProduct(int id)
        {
            // Crear una instancia de la clase de lógica de productos
            ProductsLog objProd = new ProductsLog();

            // Invocar al método para eliminar el producto y devolver el resultado
            return objProd.deleteProducts(id);
        }

        //Metodo para mostrar los proveedores en el DDL
        private void showProvidersDDL()
        {
            DDLProviders.DataSource = objPro.showProvidersDDL();
            DDLProviders.DataValueField = "prov_id";//Nombre de la llave primaria
            DDLProviders.DataTextField = "prov_nombre";
            DDLProviders.DataBind();
            DDLProviders.Items.Insert(0, "Seleccione");
        }
        //Metodo para mostrar las categorias en el DDL
        private void showCategoriesDDL()
        {
            DDLCategory.DataSource = objCat.showCategoriesDDL();
            DDLCategory.DataValueField = "cat_id";//Nombre de la llave primaria
            DDLCategory.DataTextField = "cat_descripcion";
            DDLCategory.DataBind();
            DDLCategory.Items.Insert(0, "Seleccione");
        }
        //Metodo para limpiar los TextBox y los DDL
        private void clear()
        {
            HFProductID.Value = "";
            TBCode.Text = "";
            TBDescription.Text = "";
            TBQuantity.Text = "";
            TBPrice.Text = "";
            DDLCategory.SelectedIndex = 0;
            DDLProviders.SelectedIndex = 0;
        }
        //Eventos que se ejecutan cuando se da clic en los botones
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _code = TBCode.Text;
            _description = TBDescription.Text;
            _quantity = Convert.ToInt32(TBQuantity.Text);
            _price = Convert.ToDouble(TBPrice.Text);
            _fkProvider = Convert.ToInt32(DDLProviders.SelectedValue);
            _fkCategory = Convert.ToInt32(DDLCategory.SelectedValue);

            executed = objProd.saveProducts(_code, _description, _quantity, _price, _fkProvider, _fkCategory);

            if (executed)
            {
                LblMsg.Text = "El producto se guardo exitosamente!";
                
            }
            else
            {
                LblMsg.Text = "Error al guardar";
            }
        }
        // Evento del boton actualizar
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            // Verifica si se ha seleccionado un producto para actualizar
            if (string.IsNullOrEmpty(HFProductID.Value))
            {
                LblMsg.Text = "No se ha seleccionado un producto para actualizar.";
                return;
            }
            _id = Convert.ToInt32(HFProductID.Value);
            _code = TBCode.Text;
            _description = TBDescription.Text;
            _quantity = Convert.ToInt32(TBQuantity.Text);
            _price = Convert.ToDouble(TBPrice.Text);
            _fkProvider = Convert.ToInt32(DDLProviders.SelectedValue);
            _fkCategory = Convert.ToInt32(DDLCategory.SelectedValue);

            executed = objProd.updateProducts(_id, _code, _description, _quantity, _price, _fkProvider, _fkCategory);

            if (executed)
            {
                LblMsg.Text = "El producto se actualizo exitosamente!";
                clear(); //Se invoca el metodo para limpiar los campos 
            }
            else
            {
                LblMsg.Text = "Error al actualizar";
            }
        }
    }
}