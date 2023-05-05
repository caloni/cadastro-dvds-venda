namespace TodoREST
{
    public static class Constants
    {
        // URL of REST service
        //public static string RestUrl = "https://dotnetmauitodorest.azurewebsites.net/api/todoitems/{0}";

        // URL of REST service (Android does not use localhost)
        // Use http cleartext for local deployment. Change to https for production
        public static string LocalhostUrl = DeviceInfo.Platform == DevicePlatform.Android ? "10.0.2.2" : "localhost";
        public static string Scheme = "http"; // or https
        public static string Port = "5000";
        public static string RestUrl = $"{Scheme}://{LocalhostUrl}:{Port}/api/dvds/{{0}}";
        public static string MoviesSearchRestUrl = $"{Scheme}://{LocalhostUrl}:{Port}/api/movies/searches/";
        public static string ImageUploadRestUrl = $"https://api.imgbb.com/1/upload?expiration=600&key={{0}}";
    }
}
