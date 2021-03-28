using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PizzaIllico.Mobile.Dtos.Accounts;
using Xamarin.Forms;

namespace PizzaIllico.Mobile.Services
{
    public interface IApiService
    {
        Task<TResponse> Get<TResponse>(string url);
        Task<TResponse> Post<TResponse>(string mdp , string us, string url);
        Task<TResponse> Post<TResponse>(CreateUserRequest user,  string url);
    }
    
    public class ApiService : IApiService
    {
	    private const string HOST = "https://pizza.julienmialon.ovh/";
        private readonly HttpClient _client = new HttpClient();
        
        public async Task<TResponse> Get<TResponse>(string url)
        {
	        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, HOST + url);

	        HttpResponseMessage response = await _client.SendAsync(request);

	        string content = await response.Content.ReadAsStringAsync();

	        return JsonConvert.DeserializeObject<TResponse>(content);
        }

        public async Task<TResponse> Post<TResponse>(string mdp, string us, string url)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, HOST + url);
            request.Content = new StringContent("{ test : test , test2 : test2 }", Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TResponse>(content);
        }

        public async Task<TResponse> Post<TResponse>(CreateUserRequest user, string url)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, HOST + url);
            request.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            

            HttpResponseMessage response = await _client.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TResponse>(content);
        }
    }
}