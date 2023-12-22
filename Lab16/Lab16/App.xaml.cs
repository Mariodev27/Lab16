using Xamarin.Forms;
using Lab16.ViewModels;
using Lab16.Views;

namespace Lab16
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Crear una instancia del ViewModel
            var viewModel = new UsersViewModel();

            // Crear una instancia de la página de usuarios y asignarle el ViewModel
            var usersPage = new UsersPage
            {
                BindingContext = viewModel
            };

            // Asignar la página de usuarios como la página principal de la aplicación
            MainPage = new NavigationPage(usersPage);

            // Cargar los usuarios
            viewModel.LoadUsers();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}