using pet_show_front.Business.ApiBusiness;
using pet_show_front.Models.MainModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pet_show_front.Custom
{
    public class CustomHttpClient : HttpClient
    {
        public TokenApi TokenAPi { get; set; }
        public CustomHttpClient() 
        {
            BaseAddress = new Uri("google.com");
            Timeout = TimeSpan.FromSeconds(60);            
        }

        public async Task RenewToken()
        {
            if (TokenAPi == null || TokenAPi.Validade <= DateTime.UtcNow)
            {
                TokenApiBusiness tokenApiBusiness = new TokenApiBusiness();
                TokenAPi = await tokenApiBusiness.GetToken();
                
                DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenAPi.Token);
            }

        }

        public async Task<HttpResponseMessage> PostWithTokenAsync(string requestUri, HttpContent content)
        {
            await RenewToken();

            return await PostAsync(requestUri, content);
        }

        public async Task<HttpResponseMessage> PostWithTokenAsync(string requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            await RenewToken();

            return await PostAsync(requestUri, content, cancellationToken);
        }

        public async Task<HttpResponseMessage> GetWithTokenAsync(string requestUri)
        {
            await RenewToken();

            return await GetAsync(requestUri);
        }

        public async Task<HttpResponseMessage> PutWithTokenAsync(string requestUri, HttpContent content)
        {
            await RenewToken();

            return await PutAsync(requestUri, content);
        }
    }
}
