using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto_tesis_2023.View.Tabbed
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mis_reservas : ContentPage
    {
        public Mis_reservas()
        {
            InitializeComponent();
        }

        private async void Button_alert(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("¡Atención!", "¿Esta seguro que desea eliminar esta reserva?", "Confirmar", "Cancelar");

            //if (result)
            //{
            //    // Acción al confirmar
            //    // ...
            //}
            //else
            //{
            //    // Acción al cancelar
            //    // ...
            //}
        }

        public Mis_reservas(string NameValue, ImageSource ImageValue)
        {
            InitializeComponent();

            lblName.Text = NameValue;
            imgProfile.Source = ImageValue;

        }

        public void UpdateData(string NameValue, ImageSource ImageValue)
        {
            InitializeComponent();

            lblName.Text = NameValue;
            imgProfile.Source = ImageValue;

        }

    }
}