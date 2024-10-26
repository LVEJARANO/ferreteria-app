using Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
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
                showProducts();
                showProvidersDDL();
                showCategoriesDDL();
            }
        }
        //Metodo para mostrar todos los productos
        private void showProducts()
        {
            DataSet ds = new DataSet();
            ds = objProd.showProducts();
            GVProducts.DataSource = ds;
            GVProducts.DataBind();
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
                showProducts();
            }
            else
            {
                LblMsg.Text = "Error al guardar";
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}