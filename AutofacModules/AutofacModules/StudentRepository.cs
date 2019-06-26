using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacModules
{
    public class StudentRepository : IStudentRepository
    {
        public void Print(Student student)
        {
            Console.WriteLine("Printing Student");
        }
    }
}
