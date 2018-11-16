namespace IBLL.Sys
{
    public interface IRole
    {
        int Id { get; set; }
        string Name { get; set; }
        string Note { get; set; }
        int RoleId { get; set; }
    }
}