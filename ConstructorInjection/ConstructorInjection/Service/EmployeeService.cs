using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConstructorInjection.Model;
using ConstructorInjection.Repository;

namespace ConstructorInjection.Service
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void Print(Employee employee)
        {
            _employeeRepository.Print(employee);
        }
    }
}
