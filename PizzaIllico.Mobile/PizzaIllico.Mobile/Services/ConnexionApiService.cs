using PizzaIllico.Mobile.Dtos;
using PizzaIllico.Mobile.Dtos.Authentications;
using PizzaIllico.Mobile.Dtos.Authentications.Credentials;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PizzaIllico.Mobile.Services
{
    public interface IConnexionApiService
    {
        Task<Response<List<LoginWithCredentialsRequest>>> cnx();

 
    }

    class ConnexionApiService : IConnexionApiService
    {

        private readonly IApiService _apiService;

        public ConnexionApiService()
        {
            _apiService = DependencyService.Get<IApiService>();
        }

        public async Task<Response<List<LoginWithCredentialsRequest>>> cnx()
        {
            return await _apiService.Post<Response<List<LoginWithCredentialsRequest>>>("","",Urls.LOGIN_WITH_CREDENTIALS);
        }

      
    }
}
