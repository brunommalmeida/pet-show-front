using pet_show_front.Custom;
using pet_show_front.Models.MainModels;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace pet_show_front.Business.ApiBusiness
{
    public class TokenApiBusiness
    {
        public async Task<TokenApi> GetToken()
        {
            try
            {
                TokenApi token = null;
                
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.BaseAddress = new Uri("google.com");
                    client.Timeout = TimeSpan.FromSeconds(50);

                    ApiUser user = new ApiUser();
                    user.Username = "administrador";
                    user.Password = "mes@@8715#api@@";
                    user.Role = "admin";

                    var result = await client.PostAsync("/api/auth/login", user.GetStringContentSerialized());

                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        token = JsonConvert.DeserializeObject<TokenApi>(await result.Content.ReadAsStringAsync());
                    }
                    else
                    {
                        throw new Exception("Erro ao atualizar token: " + result.RequestMessage);
                    }

                }

                return token;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
