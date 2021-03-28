using PizzaIllico.Mobile.Dtos;
using PizzaIllico.Mobile.Dtos.Authentications.Credentials;
using PizzaIllico.Mobile.Pages;
using PizzaIllico.Mobile.Services;
using Storm.Mvvm;
using Storm.Mvvm.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PizzaIllico.Mobile.ViewModels
{
    class ConnexionViewModel : ViewModelBase
    {

        private string _username;
        private string _password;
        private bool _areCredentialsInvalid=false;

        public ICommand AuthenticateCommand { get; set; }
        public ICommand SignInCommand { get; set; }


        public ConnexionViewModel()
        {
            AuthenticateCommand = new Command(Authenticate);
            SignInCommand = new Command(SignIn);
        }

     

        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }

        public async void  Authenticate()
        {
            await AuthenticateAsync();
        }
        private async Task AuthenticateAsync()
        {
            Console.WriteLine("ok");

            IConnexionApiService service = DependencyService.Get<IConnexionApiService>();

            Response<List<LoginWithCredentialsRequest>> response = await service.cnx();

           Console.WriteLine($"Appel HTTP : {response.IsSuccess}");
            if (response.IsSuccess)
            {
                Console.WriteLine($"Appel HTTP : {response.Data.Count}");

            }


            INavigationService navigationService = DependencyService.Get<INavigationService>();
            navigationService.PushAsync<ShopListPage>();
        }


        public void SignIn()
        {
            INavigationService navigationService = DependencyService.Get<INavigationService>();
            navigationService.PushAsync<SignInPage>();
        }
    }
}
