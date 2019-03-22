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
        //图片
        Pic = 0,
        //文件
        File = 1,
        //用户文件
        ClientFile=2,
        //工艺文件
        TechnologyFile=3,
        //制版文件
        PlatemakingFile=4
    }
}