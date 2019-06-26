using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using RoleBasedAccessControl.Models.Interfaces;

namespace RoleBasedAccessControl.Models
{
    public class Resource : IResource
    {
        public string Name { get; private set; }

        private HashSet<ActionType> resourceActions;
        private Dictionary<IUser, List<IRole>> userRoles;

        public Resource(string name, List<ActionType> actions)
        {
            this.Name = name;
            resourceActions = new HashSet<ActionType>();
            foreach (var entry in actions)
            {
                resourceActions.Add(entry);
            }

            userRoles = new Dictionary<IUser, List<IRole>>();
        }

        public bool AddRoleToUserForResource(IUser user, IRole role, out string message)
        {
            if (!userRoles.ContainsKey(user))
            {
                userRoles.Add(user, new List<IRole>());
            }

            for (int i = 0; i < userRoles[user].Count; i++)
            {
                if (userRoles[user][i] == role)
                {
                    message = "User:" + user.Name + "already exists with role: " 
                              + role.RoleName + "for resource: " + this.Name;
                    return false;
                }
            }
            
           userRoles[user].Add(role);
            message = "User:" + user.Name + "added with role: " + role.RoleName + "for resource: "
                      + this.Name;
            return true;
        }

        public bool RemoveUserForResource(IUser user, out string message)
        {
            bool success = false;
            if (!userRoles.ContainsKey(user))
            {
                message = "User with name: " + user.Name + "does not exist for resource: "
                          + this.Name;
            }

            else
            {
                userRoles.Remove(user);
                message = "Removed user: " + user.Name + "for resource: " + this.Name;
                success = true;
            }

            return success;
        }

        public bool RemoveUserFromRoleForResource(IUser user, IRole role, out string message)
        {
            bool success = false;
            
            if (!IsResourceSpecificUser(user))
            {
                message = "User:" + user.Name + "is not a specific user for:" + this.Name;
            }

            else
            {
                int index = -1;
                for (int i = 0; i < userRoles[user].Count; i++)
                {
                    if (userRoles[user][i] == role)
                    {
                        index = i;
                        break;
                    } 
                }

                if (index == -1)
                {
                    message = "User:" + user.Name + "does not have role:" + role.RoleName + 
                        "for resource";
                }
                else
                {
                    userRoles[user].RemoveAt(index);
                    success = true;
                    message = "User:" + user.Name + "removed from role:" + role.RoleName +
                              "for resource";
                }
            }
            return success;
        }

        public bool IsValidAction(ActionType action)
        {
            bool isValid = resourceActions.Contains(action);
            return isValid;
        }

        public bool IsResourceSpecificUser(IUser user)
        {
            //check if user has atleast one role specific to this resource
            bool isValid = userRoles.ContainsKey(user) && userRoles.Count > 0;
            return isValid;
        }

        public bool CanPerformAction(IUser user, ActionType action, out string message)
        {
            bool canPerformAction = false;

            if (!IsValidAction(action))
            {
                message = "Requested action is not valid for resource: " + this.Name;
            }
            
            else if (!IsResourceSpecificUser(user))
            {
                message = "User: " + user.Name + "is not a specific user for resource: " + this.Name;
            }

            else
            {
                var allUserRoles = this.userRoles[user];
                foreach (var entry in allUserRoles)
                {
                    //system applies most inclusive permission
                    canPerformAction = canPerformAction || entry.IsPermittedAction(action);
                }

                if (canPerformAction)
                {
                    message = "User: " + "can perform requested action on resource: " + this.Name;
                }

                else
                {
                    message = "User: " + "cannot perform requested action on resource: " + this.Name;
                }

            }

            return canPerformAction;
        }
    }
}
