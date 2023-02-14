namespace OnlineApplicationSystem.Infrastructure.Files;
public class SftpStorageSettings
{
    public const string SettingName = "SFTPStorageSettings";

    public string? ConnectionString { get; set; }
}