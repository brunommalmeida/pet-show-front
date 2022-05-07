
using pet_show_front.Models.MainModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using pet_show_front.Custom;

namespace pet_show_front.Business.ApiBusiness
{
    public class UsuariosApiBusiness
    {
        public async Task<Usuario> LoginApp(Usuario usuario)
        {
            try
            {
                //using(CustomHttpClient client = new CustomHttpClient())
                //{
                    usuario.Id = 1;
                    usuario.Nome = "Bruno";
                    usuario.UsuarioLogin = "bruno";
                    usuario.Senha = "12345";
                    usuario.AcessoAdministrador = false;

                    //var response = await client.PostWithTokenAsync($"api/usuarios/login", usuario.GetStringContentSerialized());
                    //if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    //{
                    //    return null;
                    //}
                    //else if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    //{
                    //    var usuarioLogin = JsonConvert.DeserializeObject<Usuario>(await response.Content.ReadAsStringAsync());
                    //    return usuarioLogin;
                    //}
                    //else
                    //{
                    //    var erro = JsonConvert.DeserializeObject<ErrorDetails>(await response.Content.ReadAsStringAsync());

                    //    if (erro != null && !string.IsNullOrEmpty(erro.Message))
                    //    {
                    //        throw new Exception($"Erro ao buscar usuário: Mensagem: {erro.Message}  Trace:{erro.Trace}");
                    //    }
                    //    else
                    //    {
                    //        throw new Exception($"Erro ao buscar usuário: Código: {response.StatusCode} Mensagem: {response.ReasonPhrase}");
                    //    }
                    //}

                    return usuario;

                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
