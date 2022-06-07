using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HoffTheRecord.Integration.Tests
{
    public class HoffTheRecordHttpClient
    {
        private readonly HttpClient _client;

        public HoffTheRecordHttpClient(HttpClient client)
        {
            _client = client;
        }

        internal async Task<HttpResponseMessage> Post<T>(string path, T body)
        {
            var serializedBody = JsonSerializer.Serialize(body);
            var requestContent = new StringContent(serializedBody, Encoding.UTF8, "application/json");
            return await _client.PostAsync(path, requestContent);
        }

        internal async Task<HttpResponseMessage> Get(string uri)
        {
            return await _client.GetAsync(uri);
        }

        internal async Task<HttpResponseMessage> Delete(string uri)
        {
            return await _client.DeleteAsync(uri);
        }

        internal async Task<HttpResponseMessage> Put<T>(string path, T body)
        {
            var company = JsonSerializer.Serialize(body);
            var requestContent = new StringContent(company, Encoding.UTF8, "application/json");
            return await _client.PutAsync(path, requestContent);
        }
    }
}
