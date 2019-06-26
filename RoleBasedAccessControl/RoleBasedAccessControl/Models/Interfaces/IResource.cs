namespace RoleBasedAccessControl.Models.Interfaces
{
    public interface IResource
    {
        string Name { get; }
        bool AddRoleToUserForResource(IUser user, IRole role, out string message);
        bool RemoveUserForResource(IUser user, out string message);
        bool RemoveUserFromRoleForResource(IUser user, IRole role, out string message);
        bool IsValidAction(ActionType action);
        bool IsResourceSpecificUser(IUser user);
        bool CanPerformAction(IUser user, ActionType action, out string message);
    }
}