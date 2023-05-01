namespace TodoREST
{
    public static class Constants
    {
        // URL of REST service
        //public static string RestUrl = "https://dotnetmauitodorest.azurewebsites.net/api/todoitems/{0}";

        // URL of REST service (Android does not use localhost)
        // Use http cleartext for local deployment. Change to https for production

        public const string DatabaseFilename = "TodoSQLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        //public static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
        public static string DatabasePath => DatabaseFilename;

        public static string LocalhostUrl = DeviceInfo.Platform == DevicePlatform.Android ? "10.0.2.2" : "localhost";
        public static string Scheme = "http"; // or https
        public static string Port = "5000";
        public static string RestUrl = $"{Scheme}://{LocalhostUrl}:{Port}/api/dvds/{{0}}";
        public static string MoviesSearchRestUrl = $"{Scheme}://{LocalhostUrl}:{Port}/api/movies/searches/";
        public static string ImageUploadRestUrl = $"https://api.imgbb.com/1/upload?expiration=600&key={{0}}";
    }
}
