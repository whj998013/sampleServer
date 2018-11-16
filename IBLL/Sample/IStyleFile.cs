namespace IBLL.Sample
{
    public interface IStyleFile: IBaseModel
    {
        string DisplayName { get; set; }
        string FileName { get; set; }
        FileType FileType { get; set; }
        string FileUrl { get; set; }
        int Id { get; set; }
        string SytleId { get; set; }
    }

    public enum FileType
    {
        Pic = 0,
        File = 1
    }
}