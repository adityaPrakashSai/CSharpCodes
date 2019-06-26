using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace AutofacModules
{
    public class TeacherModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TeacherRepository>().As<ITeacherRepository>();
            base.Load(builder);
        }
    }
}
