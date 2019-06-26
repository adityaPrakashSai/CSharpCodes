using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoleBasedAccessControl.Models.Interfaces;

namespace RoleBasedAccessControl.Models
{
    public class User : IUser
    {
        public string Name { get; private set; }
        private string _password;

        public User(string name, string password)
        {
            this.Name = name;
            this._password = password;
        }

    }
}
