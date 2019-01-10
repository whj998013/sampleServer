namespace SG.Interface.Sys
{
    public interface IStyleFile
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
        File = 1,
        ClientFile=2,
        TechnologyFile=3,
        PlatemakingFile=4
    }
}