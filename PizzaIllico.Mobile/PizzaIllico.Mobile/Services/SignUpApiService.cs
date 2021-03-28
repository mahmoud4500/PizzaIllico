using PizzaIllico.Mobile.Dtos;
using PizzaIllico.Mobile.Dtos.Accounts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PizzaIllico.Mobile.Services
{
    public interface ISignUpApiService
    {
        Task<Response> SignUp(CreateUserRequest user);

        
    }
    class SignUpApiService : ISignUpApiService
    {

  
            private readonly IApiService _apiService;

            public SignUpApiService()
            {
                _apiService = DependencyService.Get<IApiService>();
            }

            public async Task<Response> SignUp(CreateUserRequest user)
            {
                return await _apiService.Post<Response>(user ,Urls.CREATE_USER);
            }

          
    }
}
