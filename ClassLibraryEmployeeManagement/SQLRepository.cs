using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ClassLibraryEmployeeManagement
{
    public class SQLRepository : IEmployeeRepository
    {
        SqlConnection cn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=EmployeeManagement;Integrated Security=True");
        public Employee FindEmployee(int EmployeeId)
        {
            var t = (from p in glEmployee where p.EmployeeId == EmployeeId select p).SingleOrDefault();
            return t;
        }
        List<Employee> glEmployee = new List<Employee>();
        public List<Employee> GetEmployee()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("spEmployeeCRUD", cn);
            cmd.Parameters.AddWithValue("@pOperation", "SELECT");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                Employee e = new Employee
                {
                    EmployeeId = Int32.Parse(dr["EmployeeId"].ToString()),
                    EmployeeName = dr["EmployeeName"].ToString(),
                    Location = dr["Location"].ToString(),
                    DateOfJoin = DateTime.Parse( dr["DateOfJoin"].ToString())
                };
                glEmployee.Add(e);
            }
            cn.Close();
            return glEmployee;
        }

        public void Insert(Employee e)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("spEmployeeCRUD", cn);
            cmd.Parameters.AddWithValue("@pOperation", "INSERT");
            cmd.Parameters.AddWithValue("@pEmployeeName", e.EmployeeName);
            cmd.Parameters.AddWithValue("@pLocation", e.Location);
            cmd.Parameters.AddWithValue("@pDateOfJoin", e.DateOfJoin);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            cn.Close();

        }
        public List<string> GetemployeeName()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from Employee", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            List<string> str = new List<string>();
            while (dr.Read())
            {
                string t = dr["EmployeeName"].ToString();
                str.Add(t);
            }
            cn.Close();
            return str;
        }
    }    
}
