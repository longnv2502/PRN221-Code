using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIMethodInjectionPatternDemo
{
    public class Employee
    {
        public int EmployeeId;
        public string EmployeeName;
        private IDepartment EmployeeDept;
        public Employee() { }
        public Employee(int id, string name)
        {
            EmployeeId = id;
            EmployeeName = name;
        }
        public void AssignDepartment(IDepartment dept)
        {
            EmployeeDept = dept ?? throw new ArgumentNullException("Null");
            // Other business logic if required.

        }

        public override string ToString()
        {
            return $"EmpID: {EmployeeId},Emp Name:{EmployeeName},"
                + $"Department : {EmployeeDept.DeptName}"
                ;
        }
    }
}
