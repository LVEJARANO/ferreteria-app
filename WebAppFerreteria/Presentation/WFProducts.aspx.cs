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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                //Aqui se invocan todos los metodos
                showProducts();
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
    }
}