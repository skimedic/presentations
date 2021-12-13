namespace AutoLot.Services.Logging.Settings;

public class AppLoggingSettings
{
    public GeneralSettings General { get; set; }
    public FileSettings File { get; set; }
    public SqlServerSettings MSSqlServer { get; set; }

    public class GeneralSettings
    {
        public string RestrictedToMinimumLevel { get; set; }
    }
    public class SqlServerSettings
    {
        public string TableName { get; set; }
        public string Schema { get; set; }
        public string ConnectionStringName { get; set; }
    }

    public class FileSettings
    {
        public string Drive { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string FullLogPathAndFileName =>
            $"{Drive}{Path.VolumeSeparatorChar}{Path.DirectorySeparatorChar}{FilePath}{Path.DirectorySeparatorChar}{FileName}";
    }

}