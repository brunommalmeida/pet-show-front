using pet_show_front.Business.ApiBusiness;
using pet_show_front.Model;
using pet_show_front.Views.Devolucoes;
using pet_show_front.Views.Romaneios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace pet_show_front.ViewModels.Devolucoes
{
    public class ListaItensNotasFiscaisViewModel : BaseViewModel
    {
        public ICommand PesquisarCommand { get; private set; }
        public ICommand DevolverItemCommand { get; private set; }

        ObservableCollection<ItemNotaFiscal> itensNotaFiscal = null;
        string textoPesquisaRomaneio = "";
        public string TextoPesquisaRomaneio
        {
            get
            {
                return textoPesquisaRomaneio;
            }
            set
            {
                textoPesquisaRomaneio = value;

                if (string.IsNullOrEmpty(TextoPesquisaRomaneio) || string.IsNullOrWhiteSpace(TextoPesquisaRomaneio))
                {
                    PesquisarCommand.Execute(null);
                }
            }
        }

        public ObservableCollection<ItemNotaFiscal> ItensNotaFiscal
        {
            get
            {
                return itensNotaFiscal
;
            }
            set
            {
                itensNotaFiscal = value;
                OnPropertyChanged();
            }
        }

        public ListaItensNotasFiscaisViewModel(Model.NotaFiscal notaFiscal)
        {
            DevolverItemCommand = new Command<ItemNotaFiscal>(SepararItemNotaFiscalAsync);

            Task.Run(async () => await GetItensNotaFiscalAsync(notaFiscal.Numero));
        }

        public ListaItensNotasFiscaisViewModel()
        {

        }

        private async Task GetItensNotaFiscalAsync(string numeroNota)
        {
            try
            {
                if (IsBusy)
                {
                    return;
                }

                IsBusy = true;

                NotasFiscaisApiBusiness notasFiscaisApiBusiness = new NotasFiscaisApiBusiness();
                ItensNotaFiscal = new
                     ObservableCollection<ItemNotaFiscal>(await notasFiscaisApiBusiness.GetItensNotaFiscalAsync(numeroNota));
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
                throw ex;
            }

            IsBusy = false;
        }

        private async void SepararItemNotaFiscalAsync(ItemNotaFiscal itemNotaFiscal)
        {
            try
            {
                if (IsBusy)
                {
                    return;
                }

                IsBusy = true;
                //talvez possa usar a própria instância de romaneio para manipular a tela seguinte
                await App.Current.MainPage.Navigation.PushAsync(new pgDevolucao(itemNotaFiscal));

            }
            catch (Exception ex)
            {
                App.ConexaoSqlite.Rollback();
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }

            IsBusy = false;
        }
    }
}
