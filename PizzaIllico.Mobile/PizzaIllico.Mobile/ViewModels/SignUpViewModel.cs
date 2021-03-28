using PizzaIllico.Mobile.Dtos;
using PizzaIllico.Mobile.Dtos.Accounts;
using PizzaIllico.Mobile.Services;
using Storm.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PizzaIllico.Mobile.ViewModels
{
    class SignUpViewModel : ViewModelBase
    {

        private string _username;
        private string _password;
        private string _secret;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phoneNumber;

        private bool _formInvalid = true;

        public SignUpViewModel()
        {
            FormInvalid = true;
            SignUpCommand = new Command(SignUp);
        }

        private void SignUp()
        {
            if (Username != null && !Username.Equals("") && Password != null && !Password.Equals("") &&
                FirstName != null && !FirstName.Equals("") && LastName != null && !LastName.Equals("") &&
                Email != null && !Email.Equals("") && PhoneNumber != null && !PhoneNumber.Equals("")
                && Secret != null && !Secret.Equals("")
                  )
            {
                FormInvalid = false;
            }

            if (!FormInvalid)

            {

                CreateUserRequest user = new CreateUserRequest();
                user.ClientId = Username;
                user.Password = Password;
                user.ClientSecret = Secret;
                user.LastName = LastName;
                user.FirstName = FirstName;
                user.Email = Email;
                user.PhoneNumber = PhoneNumber;


                SignUpAsync(user);
            }
            
        }

        public async System.Threading.Tasks.Task SignUpAsync(CreateUserRequest user)
        {
            ISignUpApiService service = DependencyService.Get<ISignUpApiService>();

            Response response = await service.SignUp(user);

            Console.WriteLine($"Appel HTTP : {response.IsSuccess}");
            if (response.IsSuccess)
            {
                Console.WriteLine($"Appel HTTP : {response}");
                ;
            }
        }

        public ICommand SignUpCommand { get; set; }
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string Email { get => _email; set => _email = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public bool FormInvalid { get => _formInvalid; set => _formInvalid = value; }
        public string Secret { get => _secret; set => _secret = value; }
    }
}
