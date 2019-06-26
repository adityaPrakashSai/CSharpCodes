using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBasedAccessControl.Models
{
    /// <summary>
    /// provides definition of all action types currently supported
    /// </summary>
    public enum ActionType
    {
        Read,
        Write,
        Delete,
        Execute,
        FullControl
    }
}
