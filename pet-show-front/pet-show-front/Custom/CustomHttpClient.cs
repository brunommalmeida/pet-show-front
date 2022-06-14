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
        public CustomHttpClient() 
        {
            BaseAddress = new Uri(App.Configuracao.EnderecoApi);
            Timeout = TimeSpan.FromSeconds(19);            
        }

        public async Task<HttpResponseMessage> PostWithTokenAsync(string requestUri, HttpContent content)
        {
            return await PostAsync(requestUri, content);
        }

        public async Task<HttpResponseMessage> PostWithTokenAsync(string requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            return await PostAsync(requestUri, content, cancellationToken);
        }

        public async Task<HttpResponseMessage> GetWithTokenAsync(string requestUri)
        {
            return await GetAsync(requestUri);
        }

        public async Task<HttpResponseMessage> PutWithTokenAsync(string requestUri, HttpContent content)
        {
            return await PutAsync(requestUri, content);
        }
    }
}
