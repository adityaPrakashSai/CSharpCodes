using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace AutofacModules
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student
            {
                StudentId = 1,
                FirstName = "Aditya",
                LastName = "Prakash",
                Department = "Information Technology"
            };

            Teacher teacher = new Teacher
            {
                TeacherId = 1,
                FirstName = "Sai",
                LastName = "Baba",
                Subject = "Philosophy"
            };

            var container = BuildContainer();

            var studentRepository = container.Resolve<IStudentRepository>();
            studentRepository.Print(student);

            var teacherRepository = container.Resolve<ITeacherRepository>();
            teacherRepository.Print(teacher);
        }

        static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            //Registering Modules
            builder.RegisterModule<StudentModule>();
            builder.RegisterModule<TeacherModule>();

            return builder.Build();
        }
    }
}
