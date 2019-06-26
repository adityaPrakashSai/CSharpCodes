using RoleBasedAccessControl.Models;
using RoleBasedAccessControl.Models.Interfaces;

namespace RoleBasedAccessControl.Services.Interfaces
{
    public interface IRoleBasedAccessControlService
    {
        bool AddResourceToSytem(IResource resource, out string message);
        bool AddRoleToSystem(IRole role, out string message);
        bool AddUserToSystem(IUser user, out string message);
        bool AssignRoleToUser(IUser user, IRole role, out string message);
        bool RemoveUserFromRole(IUser user, IRole role, out string message);

        bool AssignRoleToUserForResource(IUser user, IRole role,
            IResource resource, out string message);

        bool RemoveUserForResource(IUser user, IResource resource, out string message);

        bool RemoveUserFromRoleForResource(IUser user, IRole role,
            IResource resource, out string message);

        bool CanPerformActionOnResource(IUser user, IResource resource, 
            ActionType action,
            out string message);
    }
}