﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ConstructorInjection.Model;

namespace ConstructorInjection.Repository
{
    public interface IEmployeeRepository
    {
        void Print(Employee employee);
    }
}
