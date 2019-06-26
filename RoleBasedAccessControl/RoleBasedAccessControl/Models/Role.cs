using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoleBasedAccessControl.Models.Interfaces;

namespace RoleBasedAccessControl.Models
{
    public class Role : IRole
    {
        public string RoleName { get; private set; }
        private Dictionary<ActionType, bool> _permissions;

        public bool IsPermittedAction(ActionType action)
        {
            bool isactionPermitted = _permissions.ContainsKey(action) && _permissions[action];
            return isactionPermitted;
        }

        public Role(Dictionary<ActionType, bool> permissions, string roleName)
        {
            _permissions = permissions;
            this.RoleName = roleName;

            this.ExpandFullControlRole();
        }

        private void ExpandFullControlRole()
        {
            if (_permissions.ContainsKey(ActionType.FullControl)
            && _permissions[ActionType.FullControl])
            {
                if (!_permissions.ContainsKey(ActionType.Read))
                {
                    _permissions[ActionType.Read] = true;
                }

                if (!_permissions.ContainsKey(ActionType.Write))
                {
                    _permissions[ActionType.Write] = true;
                }

                if (!_permissions.ContainsKey(ActionType.Execute))
                {
                    _permissions[ActionType.Execute] = true;
                }

                if (!_permissions.ContainsKey(ActionType.Delete))
                {
                    _permissions[ActionType.Delete] = true;
                }
            }
        }

        public Role(List<ActionType> allowedActions, string roleName)
        {
            this.RoleName = roleName;
            _permissions = new Dictionary<ActionType, bool>();
            foreach (var entry in allowedActions)
            {
                if (!_permissions.ContainsKey(entry))
                {
                    _permissions.Add(entry, true);
                }
                else
                {
                    _permissions[entry] = true;
                }
            }

            this.ExpandFullControlRole();
        }
    }
}
