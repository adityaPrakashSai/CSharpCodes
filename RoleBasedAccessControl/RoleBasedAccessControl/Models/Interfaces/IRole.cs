namespace RoleBasedAccessControl.Models.Interfaces
{
    public interface IRole
    {
        string RoleName { get; }
        bool IsPermittedAction(ActionType action);
    }
}