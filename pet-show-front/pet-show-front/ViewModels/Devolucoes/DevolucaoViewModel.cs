using pet_show_front.Business.ApiBusiness;
using pet_show_front.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace pet_show_front.ViewModels.Devolucoes
{
    public class DevolucaoViewModel : BaseViewModel
    {
        public ICommand EnviarRomaneioCommand { get; set; }
        public ICommand LimparCommand { get; set; }
        public ItemNotaFiscal ItemNotaFiscal { get; set; }
        public DevolucaoViewModel(Model.ItemNotaFiscal itemNotaFiscal)
        {
            ItemNotaFiscal = itemNotaFiscal;
            EnviarRomaneioCommand = new Command(EnviarDevolucaoAsync);
        }

        public DevolucaoViewModel()
        {

        }
        private async void EnviarDevolucaoAsync()
        {
            try
            {
                if (IsBusy)
                {
                    return;
                }

                IsBusy = true;
                if(ItemNotaFiscal.quantidadedevolvida == 0)
                {
                    await App.Current.MainPage.DisplayAlert("Atenção", "A quantidade a ser devolvida deve ser maior que 0", "Ok");
                    IsBusy = false;
                    return;
                }
                if(string.IsNullOrEmpty(ItemNotaFiscal.motivo))
                {
                    await App.Current.MainPage.DisplayAlert("Atenção", "O motivo é um campo obrigatório", "Ok");
                    IsBusy = false;
                    return;
                }

                NotasFiscaisApiBusiness notasFiscaisApiBusiness = new NotasFiscaisApiBusiness();
                await notasFiscaisApiBusiness.EnviarDevolucaoAsync(ItemNotaFiscal);
                await App.Current.MainPage.DisplayAlert("Sucesso", "Devolução enviada com sucesso", "ok");
                IsBusy = false;
                await App.Current.MainPage.Navigation.PopAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
