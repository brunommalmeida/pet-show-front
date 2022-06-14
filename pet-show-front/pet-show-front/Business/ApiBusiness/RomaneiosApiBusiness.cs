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
    public class RomaneiosApiBusiness
    {
        public async Task<List<Romaneio>> GetRomaneiosAsync(string numeroRomaneio)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(App.Configuracao.EnderecoApi);
                    client.Timeout = TimeSpan.FromSeconds(120);
                    var response = await client.GetAsync($"/api/v1/romaneio");
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var retorno = JsonConvert.DeserializeObject<ReceiveApi<List<Romaneio>>>(await response.Content.ReadAsStringAsync());
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


                //List<Romaneio> romaneios = new List<Romaneio>();
                //Romaneio romaneio = new Romaneio
                //{
                //    codromaneio = 1,
                //    datacarregar = DateTime.Now,
                //    dataemissao = DateTime.Now,
                //    idveiculo = 1,
                //    placa = "TST-2332"
                //};
                //romaneios.Add(romaneio);
                //return romaneios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ItemRomaneio>> GetItensRomaneiosAsync(string codRomaneio)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(App.Configuracao.EnderecoApi);
                    client.Timeout = TimeSpan.FromSeconds(120);
                    var response = await client.GetAsync($"/api/v1/itensRomaneio?codRomaneio={codRomaneio}");
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var retorno = JsonConvert.DeserializeObject<ReceiveApi<List<ItemRomaneio>>>(await response.Content.ReadAsStringAsync());
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

        public async Task EnviarRomaneioAsync(ItemRomaneio itemRomaneio)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(App.Configuracao.EnderecoApi);
                client.Timeout = TimeSpan.FromSeconds(120);
                var response = await client.PutAsync($"/api/v1/enviaRomaneio", itemRomaneio.GetStringContentSerialized());
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
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
    }
}
