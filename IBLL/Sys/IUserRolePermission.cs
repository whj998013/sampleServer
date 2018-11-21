namespace SG.Interface.Sys
{
    public interface IUserRolePermission
    {
        int Id { get; set; }
        int PermissionId { get; set; }
        int RoleId { get; set; }
        int UserId { get; set; }
    }
}