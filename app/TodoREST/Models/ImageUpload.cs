namespace TodoREST.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Globalization;

    public partial class ImageUploadResult
    {
        [JsonPropertyName("data")]
        public Data Data { get; set; }

        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("status")]
        public long Status { get; set; }
    }

    public partial class Data
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("url_viewer")]
        public Uri UrlViewer { get; set; }

        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        [JsonPropertyName("display_url")]
        public Uri DisplayUrl { get; set; }

        [JsonPropertyName("width")]
        public long Width { get; set; }

        [JsonPropertyName("height")]
        public long Height { get; set; }

        [JsonPropertyName("size")]
        public long Size { get; set; }

        [JsonPropertyName("time")]
        public long Time { get; set; }

        [JsonPropertyName("expiration")]
        public long Expiration { get; set; }

        [JsonPropertyName("image")]
        public Image Image { get; set; }

        [JsonPropertyName("thumb")]
        public Image Thumb { get; set; }

        [JsonPropertyName("medium")]
        public Image Medium { get; set; }

        [JsonPropertyName("delete_url")]
        public Uri DeleteUrl { get; set; }
    }

    public partial class Image
    {
        [JsonPropertyName("filename")]
        public string Filename { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("mime")]
        public string Mime { get; set; }

        [JsonPropertyName("extension")]
        public string Extension { get; set; }

        [JsonPropertyName("url")]
        public Uri Url { get; set; }
    }
}
