using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_tesis_2023.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto_tesis_2023.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private readonly IGoogleManager _googleManager;
        GoogleUser GoogleUser = new GoogleUser();
        public bool IsLogedIn { get; set; }
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
            _googleManager.Login(OnLoginComplete);
        }
        private void OnLoginComplete(GoogleUser googleUser, string message)
        {
            if (googleUser != null)
            {
                GoogleUser = googleUser;
                txtName.Text = GoogleUser.Name;
                txtEmail.Text = GoogleUser.Email;
                imgProfile.Source = GoogleUser.Picture;
                IsLogedIn = true;
            }
            else
            {
                DisplayAlert("Message", message, "Ok");
            }
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