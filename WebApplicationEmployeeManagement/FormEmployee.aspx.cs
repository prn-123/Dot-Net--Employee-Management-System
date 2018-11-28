using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibraryEmployeeManagement;

namespace WebApplicationEmployeeManagement 
{
    public partial class Employee : System.Web.UI.Page
    {
        SQLRepository Obj = new SQLRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLRepository Obj = new SQLRepository();
            Obj.GetEmployee();
            ddlEmployee.DataSource = Obj
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee
            {
                Em
                EmployeeName = txtName.Text,
                Location = txtLocation.Text,
                DateOfJoin = DateTime.Parse(txtDateOfJoin.Text)
            };
            Obj.Insert(employee);
        }
    }
}