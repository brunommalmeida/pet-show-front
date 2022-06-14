using Newtonsoft.Json;
using pet_show_front.Custom;
using pet_show_front.Model;
using pet_show_front.Model.MainModels;
using pet_show_front.Models.MainModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace pet_show_front.Business.ApiBusiness
{
    public class NotasFiscaisApiBusiness
    {
        public async Task<List<NotaFiscal>> GetNotasFiscaisAsync(string numeroNotaFiscal)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(App.Configuracao.EnderecoApi);
                    client.Timeout = TimeSpan.FromSeconds(120);
                    var response = await client.GetAsync($"/api/v1/notasFiscais");
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var retorno = JsonConvert.DeserializeObject<ReceiveApi<List<NotaFiscal>>>(await response.Content.ReadAsStringAsync());
                        return retorno.value;
                    }
                    else
                    {
                        var erro = JsonConvert.DeserializeObject<ErrorDetails>(await response.Content.ReadAsStringAsync());

                        if (erro != null && !string.IsNullOrEmpty(erro.message))
                        {
                            throw new Exception($"Erro ao buscar romaneio: Mensagem: {erro.message}");
                        }
                        else
                        {
                            throw new Exception($"Erro ao buscar romaneio: Código: {response.StatusCode} Mensagem: {response.ReasonPhrase}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task EnviarDevolucaoAsync(ItemNotaFiscal itemNotaFiscal)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(App.Configuracao.EnderecoApi);
                client.Timeout = TimeSpan.FromSeconds(120);
                var response = await client.PostAsync($"/api/v1/devolucao", itemNotaFiscal.GetStringContentSerialized());
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    var erro = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());

                }

            }
        }

        public async Task<List<ItemNotaFiscal>> GetItensNotaFiscalAsync(string numeroNf)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(App.Configuracao.EnderecoApi);
                    var response = await client.GetAsync($"/api/v1/itensNotaFiscal?numero={numeroNf}");
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var retorno = JsonConvert.DeserializeObject<ReceiveApi<List<ItemNotaFiscal>>>(await response.Content.ReadAsStringAsync());
                        return retorno.value;
                    }
                    else
                    {
                        var erro = JsonConvert.DeserializeObject<ErrorDetails>(await response.Content.ReadAsStringAsync());

                        if (erro != null && !string.IsNullOrEmpty(erro.message))
                        {
                            throw new Exception($"Erro ao buscar romaneio: Mensagem: {erro.message}");
                        }
                        else
                        {
                            throw new Exception($"Erro ao buscar romaneio: Código: {response.StatusCode} Mensagem: {response.ReasonPhrase}");
                        }
                    }

                }                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
