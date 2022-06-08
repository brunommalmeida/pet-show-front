using pet_show_front.Business.ApiBusiness;
using pet_show_front.Model;
using pet_show_front.Views.Checklists;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace pet_show_front.ViewModels.Checklists
{
    public class ListaChecklistsViewModel : BaseViewModel
    {
        public ICommand PesquisarCommand { get; private set; }
        public ICommand SepararCommand { get; private set; }

        ObservableCollection<Romaneio> romaneios = null;
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

        public ObservableCollection<Romaneio> Romaneios
        {
            get
            {
                return romaneios;
            }
            set
            {
                romaneios = value;
                OnPropertyChanged();
            }
        }

        public ListaChecklistsViewModel()
        {
            PesquisarCommand = new Command(FiltrarRomaneiosAsync);

            SepararCommand = new Command<Romaneio>(SepararRomaneioAsync);

            Task.Run(async () => await GetRomaneiosAsync());
        }

        private async void FiltrarRomaneiosAsync()
        {
            await GetRomaneiosAsync();
        }

        private async Task GetRomaneiosAsync()
        {
            try
            {
                if (IsBusy)
                {
                    return;
                }

                IsBusy = true;

                RomaneiosApiBusiness romaneiosApiBusiness = new RomaneiosApiBusiness();
                Romaneios = new
                     ObservableCollection<Romaneio>(await romaneiosApiBusiness.GetRomaneiosAsync(textoPesquisaRomaneio));
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
                throw ex;
            }

            IsBusy = false;
        }

        private async void SepararRomaneioAsync(Romaneio romaneio)
        {
            try
            {
                if (IsBusy)
                {
                    return;
                }

                IsBusy = true;
                await App.Current.MainPage.Navigation.PushAsync(new pgChecklists(romaneio));

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
