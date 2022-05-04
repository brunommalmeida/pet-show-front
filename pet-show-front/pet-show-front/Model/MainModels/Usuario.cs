using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace pet_show_front.Models.MainModels
{
    public class Usuario
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UsuarioLogin { get; set; }
        public string Senha { get; set; }
        public bool AcessoAdministrador { get; set; }

    }
}
