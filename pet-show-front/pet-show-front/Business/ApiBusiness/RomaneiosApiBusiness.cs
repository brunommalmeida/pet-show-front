using Newtonsoft.Json;
using pet_show_front.Custom;
using pet_show_front.Model;
using pet_show_front.Models.MainModels;
using System;
using System.Collections.Generic;
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
                //using (CustomHttpClient client = new CustomHttpClient())
                //{
                List<Romaneio> romaneios = new List<Romaneio>();
                Romaneio romaneio = new Romaneio
                {
                    Id = 1,
                    DataCarregar = DateTime.Now,
                    DataEmissao = DateTime.Now,
                    IdVeiculo = 1
                };
                romaneios.Add(romaneio);
                return romaneios;
                //var response = await client.GetAsync($"api/romaneios?romaneio={numeroRomaneio}");

                //if (response.StatusCode == System.Net.HttpStatusCode.OK)
                //{
                //    var empenhos = JsonConvert.DeserializeObject<List<Romaneio>>(await response.Content.ReadAsStringAsync());
                //    return empenhos;
                //}
                //else
                //{
                //    var erro = JsonConvert.DeserializeObject<ErrorDetails>(await response.Content.ReadAsStringAsync());

                //    if (erro != null && !string.IsNullOrEmpty(erro.Message))
                //    {
                //        throw new Exception($"Erro ao buscar ordem de produção: Mensagem: {erro.Message}  Trace:{erro.Trace}");
                //    }
                //    else
                //    {
                //        throw new Exception($"Erro ao buscar ordem de produção: Código: {response.StatusCode} Mensagem: {response.ReasonPhrase}");
                //    }
                //}

                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ItemRomaneio>> GetItensRomaneiosAsync(string numeroRomaneio)
        {
            try
            {
                //using (CustomHttpClient client = new CustomHttpClient())
                //{
                    List<ItemRomaneio> itensRomaneio = new List<ItemRomaneio>();
                    ItemRomaneio itemRomaneio = new ItemRomaneio
                    {
                        Sequencia = 1,
                        CodigoProduto = "teste",
                        Conferido = false,
                        Lote = "lote teste",
                        Produto = "SUA IRMÃ AQUELA LOKA",
                        Quantidade = 100,
                        QuantidadeCarregada = 0
                    };
                    itensRomaneio.Add(itemRomaneio);
                    return itensRomaneio;
                    //var response = await client.GetAsync($"api/romaneios?romaneio={numeroRomaneio}");

                    //if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    //{
                    //    var empenhos = JsonConvert.DeserializeObject<List<Romaneio>>(await response.Content.ReadAsStringAsync());
                    //    return empenhos;
                    //}
                    //else
                    //{
                    //    var erro = JsonConvert.DeserializeObject<ErrorDetails>(await response.Content.ReadAsStringAsync());

                    //    if (erro != null && !string.IsNullOrEmpty(erro.Message))
                    //    {
                    //        throw new Exception($"Erro ao buscar ordem de produção: Mensagem: {erro.Message}  Trace:{erro.Trace}");
                    //    }
                    //    else
                    //    {
                    //        throw new Exception($"Erro ao buscar ordem de produção: Código: {response.StatusCode} Mensagem: {response.ReasonPhrase}");
                    //    }
                    //}

                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
