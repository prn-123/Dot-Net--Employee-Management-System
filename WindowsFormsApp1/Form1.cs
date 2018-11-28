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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SQLRepository Obj = new SQLRepository();
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = Obj.GetEmployee();
            comboBox1.DisplayMember = "EmployeeName";
        }
    }
}
