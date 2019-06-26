using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoleBasedAccessControl.Models;
using RoleBasedAccessControl.Models.Interfaces;
using RoleBasedAccessControl.Services.Interfaces;

namespace RoleBasedAccessControl.Services
{
    public class RoleBasedAccessControlService : IRoleBasedAccessControlService
    {
        private Dictionary<string, IRole> _roles;
        private Dictionary<string, IUser> _users;
        private Dictionary<IUser, List<IRole>> _systemWideRoles;
        private Dictionary<string, IResource> _resources;
        public RoleBasedAccessControlService()
        {
            _roles = new Dictionary<string, IRole>();
            _users = new Dictionary<string, IUser>();
            _systemWideRoles = new Dictionary<IUser, List<IRole>>();
            _resources = new Dictionary<string, IResource>();
        }

        public bool AddResourceToSytem(IResource resource, out string message)
        {
            bool success = false;
            message = "Resource: " + resource.Name + "already exists in system";

            if (!_resources.ContainsKey(resource.Name))
            {
                _resources.Add(resource.Name, resource);
                success = true;
                message = "Resource: " + resource.Name + "added to system";
            }

            return success;
        }

        public bool AddRoleToSystem(IRole role, out string message)
        {
            bool success = false;
            message = "Role: " + role.RoleName + "already exists in system";

            if (!_roles.ContainsKey(role.RoleName))
            {
                _roles.Add(role.RoleName, role);
                success = true;
                message = "Role: " + role.RoleName + "added to system";
            }

            return success;
        }

        public bool AddUserToSystem(IUser user, out string message)
        {
            bool success = false;
            message = "User: " + user.Name + "already exists in system";
            if (!_users.ContainsKey(user.Name))
            {
                _users.Add(user.Name, user);
                success = true;
                message = "User: " + user.Name + "added to system";
            }

            return success;
        }

        public bool AssignRoleToUser(IUser user, IRole role, out string message)
        {
            if (!_systemWideRoles.ContainsKey(user))
            {
                _systemWideRoles.Add(user, new List<IRole>());
            }

            for (int i = 0; i < _systemWideRoles[user].Count; i++)
            {
                if (_systemWideRoles[user][i] == role)
                {
                    message = "User: " + user.Name + "already has role: " + role.RoleName;
                    return false;
                }
            }

            _systemWideRoles[user].Add(role);
            message = "User: " + user.Name + "has been added to role: " + role.RoleName;

            return true;
        }

        public bool RemoveUserFromRole(IUser user, IRole role, out string message)
        {
            bool success = false;
            if (!_systemWideRoles.ContainsKey(user))
            {
                message = "User" + user.Name + "doesn't have any roles";
            }

            else
            {
                int index = -1;
                for (int i = 0; i < _systemWideRoles[user].Count; i++)
                {
                    if (_systemWideRoles[user][i] == role)
                    { index = i;
                        break;
                    }
                }

                if (index == -1)
                {
                    message = "User: " + user.Name + "doesn't have role: " + role.RoleName;
                }

                else
                {
                    _systemWideRoles[user].RemoveAt(index);
                    success = true;
                    message = "Remove role: " + role.RoleName + "for user: " + user.Name;
                }
            }

            return success;
        }

        public bool AssignRoleToUserForResource(IUser user, IRole role,
            IResource resource, out string message)
        {
            bool success = false;

            if (!_resources.ContainsKey(resource.Name))
            {
                message = "Resource: " + resource.Name + "doesn't exist";
            }
            else
            {
                success = resource.AddRoleToUserForResource(user, role, out message);
            }

            return success;
        }

        public bool RemoveUserForResource(IUser user, IResource resource, out string message)
        {
            bool success = false;

            if (!_resources.ContainsKey(resource.Name))
            {
                message = "Resource: " + resource.Name + "doesn't exist";
            }
            else
            {
                success = resource.RemoveUserForResource(user, out message);
            }

            return success;
        }

        public bool RemoveUserFromRoleForResource(IUser user, IRole role,
            IResource resource, out string message)
        {
            bool success = false;

            if (!_resources.ContainsKey(resource.Name))
            {
                message = "Resource: " + resource.Name + "doesn't exist";
            }
            else
            {
                success = resource.RemoveUserFromRoleForResource(user, role, out message);
            }

            return success;
        }

        public bool CanPerformActionOnResource(IUser user, IResource resource, 
            ActionType action,
            out string message)
        {
            bool canPerformAction = false;

            if (!_resources.ContainsKey(resource.Name))
            {
                message = "Resource: " + resource.Name + "doesn't exist";
            }

            else if(!resource.IsValidAction(action))
            {
                message = "Invalid action for resource: " + resource.Name;
            }

            else if (resource.IsResourceSpecificUser(user))
            {
                canPerformAction = resource.CanPerformAction(user, action, out message);
            }

            //user is not a specific resource user
            //system wide roles will be used to 
            //check if action can be performed
            else
            {
                if (!_systemWideRoles.ContainsKey(user))
                {
                    message = "User: " + user.Name + "doesn't have required permission";
                }

                else
                {
                    var allUserRoles = this._systemWideRoles[user];
                    foreach (var entry in allUserRoles)
                    {
                        //system applies most inclusive permission
                        canPerformAction = canPerformAction || entry.IsPermittedAction(action);
                    }

                    if (canPerformAction)
                    {
                        message = "User: " + "can perform requested action on resource: " + resource.Name;
                    }

                    else
                    {
                        message = "User: " + "cannot perform requested action on resource: " + resource.Name;
                    }
                }
            }

            return canPerformAction;
        }
    }
}
