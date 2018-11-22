namespace SG.Interface.Sys
{
    public interface IRole
    {
        int Id { get; set; }
        string Name { get; set; }
        string Note { get; set; }
        long RoleId { get; set; }
    }
}