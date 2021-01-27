using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginDemo
{
    public partial class LinqToSqlDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductsDataContext p = new ProductsDataContext();

            var d = from Department in p.GetTable<Department>() select Department;
            GridView1.DataSource = d;
            GridView1.DataBind();
        }
    }
}