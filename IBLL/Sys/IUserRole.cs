namespace SG.Interface.Sys
{
    public interface IUserRole: INameId
    {
        long RoleId { get; set; }
        string RoleName { get; set; }
   

    }
}