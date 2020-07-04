namespace SG.Interface.Sys
{
    public interface IPermission: IDataQuery
    {
        string CnName { get; set; }
        string Name { get; set; }
        string Key { get; set; }
        string UpKey { get; set; }
    }
}