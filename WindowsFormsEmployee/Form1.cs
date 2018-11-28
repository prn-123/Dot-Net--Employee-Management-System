using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibraryEmployeeManagement;
using System.Data.SqlClient;
namespace WindowsFormsEmployee
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SQLRepository Obj1 = new SQLRepository();
        SqlConnection cn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=EmployeeManagement;Integrated Security=True");

        public object DateOfJoin { get; private set; }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            FillGrid();
            cn.Open();
            SqlCommand cmd = new SqlCommand("Select EmployeeName from Employee", cn);
            SqlDataReader DR = cmd.ExecuteReader();
            while (DR.Read())
            {
                cbEmployee.Items.Add(DR[0]);

            }
            cbEmployee.ValueMember = "EmployeeId";
            cn.Close();
            //Drop down list in case of windows form --
            //dropdownlist1.datasource=obj.getemployees();
            //databind()
        }

        private void FillGrid()
        {
            dgvEmployee.DataSource = Obj1.GetEmployee();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SQLRepository Obj = new SQLRepository();
            Employee emp = new Employee
            {
                EmployeeName = txtName.Text,
                Location = txtLocation.Text,
                DateOfJoin = DateTime.Parse(txtDatOfJoin.Text)
            };
            Obj.Insert(emp);
            MessageBox.Show("Svaed");
            FillGrid();
        }

        private void cbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int v = cbEmployee.SelectedIndex;
            int t = v + 1;
            var b = Obj1.FindEmployee(t);
            txtName.Text = b.EmployeeName.ToString();
            txtLocation.Text = b.Location.ToString();
            txtDatOfJoin.Text = b.DateOfJoin.ToString();

        }
    }
}
