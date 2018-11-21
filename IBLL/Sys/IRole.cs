namespace IBLL.Sys
{
    public interface IRole:IBaseModel
    {
        int Id { get; set; }
        string Name { get; set; }
        string Note { get; set; }
        long RoleId { get; set; }
    }
}