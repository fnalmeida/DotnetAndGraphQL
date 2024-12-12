using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace AspireApp.Web
{
    public class GraphQLClient
    {
        private readonly HttpClient _httpClient;

        public GraphQLClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> ExecuteQueryAsync(string query, CancellationToken cancellationToken = default)
        {
            var requestBody = new
            {
                query = query
            };

            var requestContent = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/graphql", requestContent, cancellationToken);

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);

            return responseContent;
        }
    }
}
