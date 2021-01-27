using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginDemo
{
    public partial class EmployeeCRUD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetData();
            TextBox1.Visible = false;
            Button5.Visible = false;
        }

        private void GetData()
        {
            TextBox1.Visible = false;
            EmployeeDataContext e = new EmployeeDataContext();

            GridView1.DataSource = e.Employees;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GetData();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            EmployeeDataContext ed = new EmployeeDataContext();
            Employee ne = new Employee
            {
                empname = "Nithish",
                empdept = "Development",
                empsalary = 12000,

        };
            ed.Employees.InsertOnSubmit(ne);
            ed.SubmitChanges();
            GetData();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            EmployeeDataContext ed = new EmployeeDataContext();
            Employee ne = ed.Employees.Single(i => i.empid == 4);

            ne.empsalary = 20000;
            ed.SubmitChanges();

            GetData();
        }


        protected void Button4_Click(object sender, EventArgs e)
        {
            TextBox1.Visible = true;
            Button5.Visible = true;

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            DeleteData();
        }


        public void DeleteData()
        {
            int id = Convert.ToInt32(TextBox1.Text);
            EmployeeDataContext ed = new EmployeeDataContext();

            Employee ne = ed.Employees.Single(i => i.empid == id);
            ed.Employees.DeleteOnSubmit(ne);
            ed.SubmitChanges();

            GetData();
        }
    }
}