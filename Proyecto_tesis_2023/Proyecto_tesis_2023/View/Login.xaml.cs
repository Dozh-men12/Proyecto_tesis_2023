using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_tesis_2023.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Proyecto_tesis_2023.View.Tabbed;

namespace Proyecto_tesis_2023.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private readonly IGoogleManager _googleManager;
        GoogleUser GoogleUser = new GoogleUser();
        public bool IsLogedIn { get; set; }
        public string NameValue { get; set; }
        public ImageSource ImageValue { get; set; }
        public Login()
        {
            _googleManager = DependencyService.Get<IGoogleManager>();
            CheckUserLoggedIn();
            InitializeComponent();
        }

        private void CheckUserLoggedIn()
        {
            _googleManager.Login(OnLoginComplete);
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
           _googleManager.Logout();
           _googleManager.Login(OnLoginComplete);
        }

        private async void OnLoginComplete(GoogleUser googleUser, string message)
        {
            if (googleUser != null)
            {
                if (IsValidEmail(googleUser.Email))
                {
                    GoogleUser = googleUser;
                    NameValue = GoogleUser.Name;
                    ImageValue = ImageSource.FromUri(new Uri(GoogleUser.Picture.ToString()));

                    Constante.Nombre = GoogleUser.Name;
                    Constante.Imagen = ImageSource.FromUri(new Uri(GoogleUser.Picture.ToString()));

                    var containerTabbedPage = new ContainerTabbedPage();

                    await Navigation.PushAsync(containerTabbedPage);
                }
                else
                {
                    DisplayAlert("Message", "Solo se permiten correos de dominio @tecsup.edu.pe", "Ok");
                }
            }
            else
            {
                DisplayAlert("Message", message, "Ok");
            }
        }

        private bool IsValidEmail(string email)
        {
            return email.EndsWith("@tecsup.edu.pe", StringComparison.OrdinalIgnoreCase);
        }

        private void GoogleLogout()
        {
            _googleManager.Logout();
            IsLogedIn = false;
        }

        private void btnLogout_Clicked(object sender, EventArgs e)
        {
            _googleManager.Logout();

            txtName.Text = "Name :";
            txtEmail.Text = "Email: ";
            imgProfile.Source = "";
        }
    }
}
