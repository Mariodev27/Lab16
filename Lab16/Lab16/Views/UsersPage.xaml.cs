using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Lab16.Models;
using Xamarin.Forms.Xaml;
using Lab16.ViewModels;

namespace Lab16.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersPage : ContentPage
    {
        private const string BaseUrl = "https://laboratorio16-api.vercel.app";

        public UsersPage()
        {
            InitializeComponent();
        }

        public async Task<T> GetAsync<T>(string endpoint)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                HttpResponseMessage response = await client.GetAsync(endpoint);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    T result = JsonConvert.DeserializeObject<T>(json);
                    return result;
                }
                else
                {
                    throw new Exception($"Error en la solicitud: {response.StatusCode}");
                }
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Obtener el ViewModel
                var viewModel = (UsersViewModel)BindingContext;

                // Limpiar los usuarios existentes
                viewModel.ClearUsers();

                // Cargar los usuarios
                viewModel.LoadUsers();
            }
            catch (Exception ex)
            {
                // Manejar errores
                throw ex;
            }
        }
    }
}