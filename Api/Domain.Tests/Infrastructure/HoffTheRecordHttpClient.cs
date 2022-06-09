using System.Text;
using System.Text.Json;

namespace HoffTheRecord.Acceptance.Tests.Infrastructure
{
    public class HoffTheRecordHttpClient
    {
        private readonly HttpClient _client;

        public HoffTheRecordHttpClient(HttpClient client)
        {
            _client = client;
        }

        internal async Task<HttpResponseMessage> Post<T>(string path, T body, CancellationToken cancellationToken = default)
        {
            var serializedBody = JsonSerializer.Serialize(body);
            var requestContent = new StringContent(serializedBody, Encoding.UTF8, "application/json");
            return await _client.PostAsync(path, requestContent, cancellationToken);
        }

        internal async Task<HttpResponseMessage> Get(string uri, CancellationToken cancellationToken = default)
        {
            return await _client.GetAsync(uri, cancellationToken);
        }

        internal async Task<HttpResponseMessage> Delete(string uri, CancellationToken cancellationToken = default)
        {
            return await _client.DeleteAsync(uri, cancellationToken);
        }

        internal async Task<HttpResponseMessage> Put<T>(string path, T body, CancellationToken cancellationToken = default)
        {
            var company = JsonSerializer.Serialize(body);
            var requestContent = new StringContent(company, Encoding.UTF8, "application/json");
            return await _client.PutAsync(path, requestContent, cancellationToken);
        }
    }
}
