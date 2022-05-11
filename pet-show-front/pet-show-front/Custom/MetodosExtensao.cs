using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace pet_show_front.Custom
{
    public static class MetodosExtensao
    {
        /// <summary>
        /// Retorna um objeto do tipo StringContent a partir de uma objeto json
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public static StringContent GetStringContentSerialized(this object objeto)
        {
            string json = JsonConvert.SerializeObject(objeto);

            return new StringContent(json, UnicodeEncoding.UTF8, "application/json");
        }
    }
}
