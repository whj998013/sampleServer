namespace SG.Interface.Sys
{
    public interface IPermission
    {
        string CnName { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        string Note { get; set; }
        int PermissionId { get; set; }
        int UpId { get; set; }
    }
}