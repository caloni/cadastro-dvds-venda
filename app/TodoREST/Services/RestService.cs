﻿using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.Json;
using TodoREST;

namespace TodoREST.Services
{
    public class RestService : IRestService
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;
        IHttpsClientHandlerService _httpsClientHandlerService;

        public List<Models.DvdItem> Items { get; private set; }
        public List<Models.MovieSearchResult> MovieSearchResults { get; private set; }

        public RestService(IHttpsClientHandlerService service)
        {
#if DEBUG
            _httpsClientHandlerService = service;
            HttpMessageHandler handler = _httpsClientHandlerService.GetPlatformMessageHandler();
            if (handler != null)
                _client = new HttpClient(handler);
            else
                _client = new HttpClient();
#else
            _client = new HttpClient();
#endif
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<Models.DvdItem>> RefreshDataAsync()
        {
            Items = new List<Models.DvdItem>();

            Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Items = JsonSerializer.Deserialize<List<Models.DvdItem>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Items;
        }

        public async Task SaveTodoItemAsync(Models.DvdItem item, bool isNewItem = false)
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            try
            {
                string json = JsonSerializer.Serialize<Models.DvdItem>(item, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                    response = await _client.PostAsync(uri, content);
                else
                    response = await _client.PutAsync(uri, content);

                if (response.IsSuccessStatusCode)
                    Debug.WriteLine(@"\tTodoItem successfully saved.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task DeleteTodoItemAsync(string id)
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl, id));

            try
            {
                HttpResponseMessage response = await _client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                    Debug.WriteLine(@"\tTodoItem successfully deleted.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task<List<Models.MovieSearchResult>> SearchMoviesAsync(Models.MovieSearch search)
        {
            MovieSearchResults = new List<Models.MovieSearchResult>();

            Uri uri = new Uri(string.Format(Constants.MoviesSearchRestUrl, search));
            try
            {
                string json = JsonSerializer.Serialize<Models.MovieSearch>(search, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.PostAsync(uri, content);
                string result = await response.Content.ReadAsStringAsync();
                MovieSearchResults = JsonSerializer.Deserialize<List<Models.MovieSearchResult>>(result, _serializerOptions);

                if (response.IsSuccessStatusCode)
                    Debug.WriteLine(@"\tTodoItem successfully saved.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return MovieSearchResults;
        }

        public async Task<Models.ImageUploadResult> SaveImageToCloud(Stream image)
        {
            string ApiKey = "PUT_AN_API_KEY_HERE";
            Uri uri = new Uri(string.Format(Constants.ImageUploadRestUrl, ApiKey));

            try
            {
                HttpContent fileStreamContent = new StreamContent(image);
                var formData = new MultipartFormDataContent();
                formData.Add(fileStreamContent, "image", "dvd.jpg");

                HttpResponseMessage response = await _client.PostAsync(uri, formData);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tImage successfully saved.");
                    string sresult = await response.Content.ReadAsStringAsync();
                    Models.ImageUploadResult result = JsonSerializer.Deserialize<Models.ImageUploadResult>(sresult, _serializerOptions);
                    return result;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return null;
        }

    }
}
