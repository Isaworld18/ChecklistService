namespace ChecklistService_Application.Managers
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http.Headers;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    public static class CallAPIManager
    {
        public static async Task<List<T>?> GetBanksData<T>(string apiSource, string path, T resultDataType)
                                                           where T : IConvertible
        {
            HttpClient client = new()
            {
                BaseAddress = new Uri(apiSource)
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            List<T>? data = [];

            HttpResponseMessage response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                data = await response.Content.ReadFromJsonAsync<List<T>>();
            }

            return data;
        }
    }
}
