using Mapper.GSB.Application.GSBAPICaller.SeedWorks.RestApi;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using System.Text;

namespace Mapper.GSB.Infrastructure.RestApi
{
    /// <summary>
    /// کلاس جهت صدا زدن یک سرویس رست خارجی
    /// </summary>
    public class RestApiRepository : IRestApiRepository
    {
        private readonly string baseURl;
        private readonly ILogger<RestApiRepository> logger;

        public RestApiRepository(string baseURl, ILogger<RestApiRepository> logger)
        {
            this.baseURl = baseURl;
            this.logger = logger;
        }
        public async Task<RestApiOutputDto> PostAsync(Uri requestUrl, Dictionary<string, string>? headers, string body, string contentType, Encoding? encoding = null)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(baseURl);
            if (headers?.Count > 0)
                foreach (var header in headers)
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
            

            HttpContent content;
            if (encoding is not null)
                content = new StringContent(body, encoding, new MediaTypeHeaderValue(contentType));
            else
                content = new StringContent(body, new MediaTypeHeaderValue(contentType));

            var result = await client.PostAsync(requestUrl, content);            
            return new RestApiOutputDto()
            {
                Status = result.StatusCode,
                Data = await result.Content.ReadAsStringAsync()
            };            
        }
    }
}
