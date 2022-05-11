using SQLite;

namespace pet_show_front.Models.MainModels
{
    public class Configuracao 
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string UrlApi { get; set; }        
        public int Timeout { get; set; }
        [Ignore]
        public string EnderecoApi =>  UrlApi;
    }
}
