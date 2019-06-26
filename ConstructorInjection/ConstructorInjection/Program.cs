using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ConstructorInjection.Model;
using ConstructorInjection.Repository;
using ConstructorInjection.Service;

namespace ConstructorInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = BuildContainer();
            var employeeService = container.Resolve<EmployeeService>();
            Employee employee = new Employee
            {
                EmployeeId = 1,
                FirstName = "Aditya",
                LastName = "Prakash",
                Designation = "Architect"
            };
            employeeService.Print(employee);
            
        }

        static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>();
            builder.RegisterType<EmployeeService>();
            return builder.Build();
        }
    }
}
