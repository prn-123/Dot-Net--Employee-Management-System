using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEmployeeManagement
{
    interface IEmployeeRepository
    {
        List<Employee> GetEmployee();
        Employee FindEmployee(int EmployeeId);
        void Insert(Employee e);
    }
}
