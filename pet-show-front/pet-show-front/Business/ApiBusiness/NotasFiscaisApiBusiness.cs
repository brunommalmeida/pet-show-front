using Newtonsoft.Json;
using pet_show_front.Custom;
using pet_show_front.Model;
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
                //using (HttpClient client = new HttpClient())
                //{
                //    client.BaseAddress = new Uri(App.Configuracao.EnderecoApi);                   
                //    var response = await client.GetAsync($"api/romaneios?romaneio={numeroNotaFiscal}");
                //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                //    {
                //        var romaneios = JsonConvert.DeserializeObject<List<NotaFiscal>>(await response.Content.ReadAsStringAsync());
                //        return romaneios;
                //    }
                //    else
                //    {
                //        var erro = JsonConvert.DeserializeObject<ErrorDetails>(await response.Content.ReadAsStringAsync());

                //        if (erro != null && !string.IsNullOrEmpty(erro.Message))
                //        {
                //            throw new Exception($"Erro ao buscar romaneio: Mensagem: {erro.Message}  Trace:{erro.Trace}");
                //        }
                //        else
                //        {
                //            throw new Exception($"Erro ao buscar romaneio: Código: {response.StatusCode} Mensagem: {response.ReasonPhrase}");
                //        }
                //    }

                //}
                List<NotaFiscal> notasFiscais = new List<NotaFiscal>();
                NotaFiscal notaFiscal = new NotaFiscal
                {
                    Numero = "ASDASD",
                    DataEmissao = DateTime.Now,
                    IdRomaneio = 1
                };
                notasFiscais.Add(notaFiscal);
                return notasFiscais;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ItemNotaFiscal>> GetItensNotaFiscalAsync(string numeroRomaneio)
        {
            try
            {
                //using (CustomHttpClient client = new CustomHttpClient())
                //{
                List<ItemNotaFiscal> itensNotaFiscal = new List<ItemNotaFiscal>();
                ItemNotaFiscal itemNotaFiscal = new ItemNotaFiscal
                {
                    Item = "0001",
                    CodigoProduto = "CÓDIGO TESTE",
                    Produto = "TESTEE",
                    Quantidade = 10,
                    IdNotaFiscal = "01"               
                };
                itensNotaFiscal.Add(itemNotaFiscal);
                return itensNotaFiscal;
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
