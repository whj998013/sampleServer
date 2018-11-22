namespace SG.Interface.Sys
{
    public interface IUserRole
    {
        int Id { get; set; }
        long RoleId { get; set; }
        string UserId { get; set; }
        string RoleName { get; set; }
        string UserName { get; set; }
    }
}