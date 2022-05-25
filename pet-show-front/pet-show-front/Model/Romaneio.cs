using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace pet_show_front.Model
{
    public class Romaneio
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataCarregar { get; set; }
        public int IdVeiculo { get; set; }
    }
}
