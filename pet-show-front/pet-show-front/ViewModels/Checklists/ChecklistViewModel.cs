using pet_show_front.Business.ApiBusiness;
using pet_show_front.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace pet_show_front.ViewModels.Checklists
{
    public class ChecklistViewModel : BaseViewModel
    {
        public ICommand EnviarChecklistCommand { get; set; }
        public ICommand LimparCommand { get; set; }
        public Romaneio Romaneio { get; set; }
        public Checklist Checklist { get; set; }
        public string observacoes = "";
        public string Observacoes
        {
            get
            {
                return observacoes;
            }
            set
            {
                observacoes = value;
            }
        }
        public ChecklistViewModel(Model.Romaneio romaneio)
        {
            Romaneio = romaneio;
            Checklist = new Checklist();
            EnviarChecklistCommand = new Command(EnviarChecklistAsync);
        }

        private async void EnviarChecklistAsync()
        {
            try
            {
                if (IsBusy)
                {
                    return;
                }

                IsBusy = true;

                if (string.IsNullOrEmpty(Checklist.observacoes))
                {
                    await App.Current.MainPage.DisplayAlert("Atenção", "Preencha uma observação para o checklist", "Ok");
                    IsBusy = false;
                    return;
                }
                Checklist.codromaneio = Romaneio.codromaneio;
                RomaneiosApiBusiness romaneiosApiBusiness = new RomaneiosApiBusiness();
                await romaneiosApiBusiness.EnviarChecklistAsync(Checklist);
                await App.Current.MainPage.DisplayAlert("Sucesso", "Checklist enviado com sucesso", "ok");
                IsBusy = false;
                await App.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
                throw ex;
            }

            IsBusy = false;
        }

        public ChecklistViewModel()
        {

        }



    }
}
