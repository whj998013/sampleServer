namespace SG.Interface.Sys
{
    public interface IUserRole:IBaseModel
    {
        int Id { get; set; }
        long RoleId { get; set; }
        int UserId { get; set; }
    }
}