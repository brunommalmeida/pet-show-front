using pet_show_front.Models.MainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace pet_show_front.Business.AppBusiness
{
    public class ConfiguracoesAppBusiness
    {
        public void Inserir(Configuracao configuracao)
        {
            App.ConexaoSqlite.Insert(configuracao);
        }

        public void Alterar(Configuracao configuracao)
        {
            App.ConexaoSqlite.Update(configuracao);
        }

        public Configuracao GetConfiguracao()
        {
            return App.ConexaoSqlite.Table<Configuracao>().FirstOrDefault();
        }
    }
}
