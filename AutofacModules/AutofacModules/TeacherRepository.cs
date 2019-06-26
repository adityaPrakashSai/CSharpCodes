using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacModules
{
    public class TeacherRepository : ITeacherRepository
    {
        public void Print(Teacher teacher)
        {
            Console.WriteLine("Printing Teacher");
        }
    }
}
