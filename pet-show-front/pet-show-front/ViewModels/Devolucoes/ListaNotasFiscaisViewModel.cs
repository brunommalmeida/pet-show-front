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
    public class ListaNotasFiscaisViewModel : BaseViewModel
    {
        public ICommand PesquisarCommand { get; private set; }
        public ICommand SepararCommand { get; private set; }

        ObservableCollection<NotaFiscal> notasFiscais = null;
        string textoPesquisaNotaFiscal = "";
        public string TextoPesquisaNotaFiscal
        {
            get
            {
                return textoPesquisaNotaFiscal;
            }
            set
            {
                textoPesquisaNotaFiscal = value;

                if (string.IsNullOrEmpty(TextoPesquisaNotaFiscal) || string.IsNullOrWhiteSpace(TextoPesquisaNotaFiscal))
                {
                    PesquisarCommand.Execute(null);
                }
            }
        }

        public ObservableCollection<NotaFiscal> NotasFiscais
        {
            get
            {
                return notasFiscais;
            }
            set
            {
                notasFiscais = value;
                OnPropertyChanged();
            }
        }

        public ListaNotasFiscaisViewModel()
        {
            PesquisarCommand = new Command(FiltrarNotasFiscaisAsync);
            SepararCommand = new Command<NotaFiscal>(DevolverNotaFiscalAsync);

            Task.Run(async () => await GetNotasFiscaisAsync());
        }

        private async void FiltrarNotasFiscaisAsync()
        {
            await GetNotasFiscaisAsync();
        }

        private async Task GetNotasFiscaisAsync()
        {
            try
            {
                if (IsBusy)
                {
                    return;
                }

                IsBusy = true;

                NotasFiscaisApiBusiness notasFiscaisApiBusiness = new NotasFiscaisApiBusiness();
                NotasFiscais = new
                     ObservableCollection<NotaFiscal>(await notasFiscaisApiBusiness.GetNotasFiscaisAsync(textoPesquisaNotaFiscal));
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
                throw ex;
            }

            IsBusy = false;
        }

        private async void DevolverNotaFiscalAsync(NotaFiscal notaFiscal)
        {
            try
            {
                if (IsBusy)
                {
                    return;
                }

                IsBusy = true;
                await App.Current.MainPage.Navigation.PushAsync(new pgListaItensNotasFiscais(notaFiscal));

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
