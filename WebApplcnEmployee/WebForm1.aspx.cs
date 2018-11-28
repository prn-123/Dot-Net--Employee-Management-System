using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibraryEmployeeManagement;

namespace WebApplcnEmployee
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SQLRepository Obj = new SQLRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            gvEmployee.DataSource = Obj.GetEmployee();
            DropDownList1.DataSource = Obj.GetEmployee();
            DropDownList1.DataTextField = "EmployeeName";
            DropDownList1.DataValueField = "EmployeeId";
            DataBind();

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var r = Obj.FindEmployee(Int32.Parse( DropDownList1.SelectedValue));
            txtName.Text = r.EmployeeName;
            txtLocation.Text = r.Location;
            txtDateOfJoin.Text =r.DateOfJoin.ToString();
            btnClear.Enabled = false;
        }
    }
}