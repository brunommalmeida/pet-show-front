using System;
using System.Collections.Generic;
using System.Text;

namespace pet_show_front.Model
{
    public class ItemRomaneio
    {
        public int iditemnotafiscal { get; set; }
        public int idnotafiscal { get; set; }
        public int sequencia { get; set; }
        public int codromaneio { get; set; }
        public string codproduto { get; set; } 
        public string descricao { get; set; }
        public double quantidade { get; set; }
        public double quantidadecarregada { get; set; }
        public string lote { get; set; }
        public bool conferido { get; set; }

    }
}
