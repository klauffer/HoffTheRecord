using System.Text.Json;

namespace HoffTheRecord.Integration.Tests.Infrastructure
{
    internal static class HttpHelpers
    {
        public static async Task<T> GetResponse<T>(this HttpResponseMessage httpResponseMessage)
            where T : class
        {
            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var content = await httpResponseMessage.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<T>(content, options);
            if (response == null)
            {
                throw new Exception($"Could not get the response for type {nameof(T)}");
            }
            return response;
        }
    }
}
