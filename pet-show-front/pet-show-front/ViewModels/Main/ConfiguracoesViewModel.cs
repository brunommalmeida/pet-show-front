using pet_show_front.Models.MainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using pet_show_front.Business.AppBusiness;

namespace pet_show_front.ViewModels.Main
{
    public class ConfiguracoesViewModel : BaseViewModel
    {
        public ICommand SalvarCommand { get; set; }
        Configuracao configuracao = null;
        public Configuracao Configuracao
        {
            get
            {
                return configuracao;
            }
            set
            {
                configuracao = value;
                OnPropertyChanged();
            }
        }
        public ConfiguracoesViewModel()
        {
            SalvarCommand = new Command(Salvar);
            Inicializa();
        }

        private void Inicializa()
        {
            ConfiguracoesAppBusiness ConfiguracoesAppBusiness = new ConfiguracoesAppBusiness();
            Configuracao = ConfiguracoesAppBusiness.GetConfiguracao();

            if (Configuracao == null)
            {
                Configuracao = new Configuracao();
                Configuracao.Timeout = 60;
            }
        }

        private bool ValidaCampos()
        {
            if (string.IsNullOrEmpty(Configuracao.UrlApi))
            {
                App.Current.MainPage.DisplayAlert("Informação", "Informe a Url da api", "Ok");
                return false;
            }

            if (Configuracao.Timeout <= 0)
            {
                App.Current.MainPage.DisplayAlert("Informação", "Campo Timeout é obrigatório.", "Ok");
                return false;
            }
            return true;
        }

        private async void Salvar()
        {
            try
            {
                if (!ValidaCampos())
                {
                    return;
                }

                ConfiguracoesAppBusiness ConfiguracoesAppBusiness = new ConfiguracoesAppBusiness();
                if (Configuracao.Id > 0)
                {
                    ConfiguracoesAppBusiness.Alterar(Configuracao);
                }
                else
                {
                    ConfiguracoesAppBusiness.Inserir(Configuracao);

                }

                App.Configuracao = Configuracao;

                await App.Current.MainPage.Navigation.PopAsync();

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", "Erro: " + ex.Message, "Ok");
            }
        }

      


    }
}
