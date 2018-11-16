namespace IBLL.Sys
{
    public interface IUserRole
    {
        int Id { get; set; }
        int RoleId { get; set; }
        int UserId { get; set; }
    }
}