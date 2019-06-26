using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConstructorInjection.Model;

namespace ConstructorInjection.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public void Print(Employee employee)
        {
            Console.WriteLine("Printing Employee");
            Console.WriteLine("Employee Id : {0}", employee.EmployeeId);
            Console.WriteLine("First Name : {0}", employee.FirstName);
            Console.WriteLine("Last Name: {0}", employee.LastName);
            Console.WriteLine("Designation : {0}", employee.Designation);
        }
    }
}
