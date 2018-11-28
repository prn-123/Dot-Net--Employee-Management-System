using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibraryEmployeeManagement;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SQLRepository Obj = new SQLRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            DropDownList1.DataSource = Obj.GetEmployee();
            DropDownList1.DataTextField = "EmployeeName";
            DropDownList1.DataValueField = "EmployeeId";
            DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var t = Obj.FindEmployee(DropDownList1.SelectedIndex);
            TextBox1.Text = t.Location;
        }
    }
}