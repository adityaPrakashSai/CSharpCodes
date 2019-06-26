using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace AutoFacBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<PrintService>().As<IPrintService>();

            var container = builder.Build();
            var printService = container.Resolve<IPrintService>();
            printService.PrintSomething("HelloWorld");
            Console.ReadKey();
        }
    }
}
