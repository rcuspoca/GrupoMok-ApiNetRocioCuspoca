using Newtonsoft.Json;

namespace APINetMok.Helper.HttpClientHelper
{
    /// <summary>
    /// Método Genérico que realiza la conexión con el cliente a través de la Url y EndPoint
    /// </summary>
    public static class ClientConnection
    {
        public static async Task<T> GetAsync<T>(string url)
        {
            T data;

            using (HttpClient client = new())
            {                
                using HttpResponseMessage response = await client.GetAsync(url);
                using HttpContent content = response.Content;
                string d = await content.ReadAsStringAsync();
                if (d != null)
                {
                    data = JsonConvert.DeserializeObject<T>(d);
                    return data;
                }
            }
            object o = new();
            return (T)o;
        }
    }
}
