using Acr.UserDialogs;
using Proyecto_tesis_2023.ViewModel;
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
    public partial class Reservar : ContentPage
    {

        public Reservar()
        {
            InitializeComponent();
            this.BindingContext = new ViewModelReservar();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            //Pantalla de carga para la reserva y al finalizar con una ventana emergente
            //UserDialogs.Instance.ShowLoading(title: "Reservando");
            //await Task.Delay(5000);
            //UserDialogs.Instance.HideLoading();
            //await DisplayAlert(title:"aña", message:"aña", cancel:"ok");

            //Pantalla de carga para la reserva pero de manera progresiva y con boton de cancelar
            bool cancelar = false;
            using (var dialog = UserDialogs.Instance.Progress(title: "Procesando", onCancel: () => cancelar = true, cancelText: "Cancelar"))
            {
                for (int i = 1; i <= 10; i++)
                {
                    await Task.Delay(400);
                    if (!cancelar)
                    {
                        dialog.PercentComplete = i * 10;
                    }
                    else
                    {
                        break; // Salir del bucle si se ha cancelado
                    }
                }
            }

            if (cancelar)
            {
                // Acción cancelada, puedes agregar aquí el código que deseas ejecutar al cancelar
                await DisplayAlert("Acción cancelada", "La acción ha sido cancelada.", "Aceptar");
            }
            else
            {
                // La acción se completó sin cancelación, redirigir a Mis_Reservas
                await Navigation.PushAsync(new Mis_reservas());
                await Task.Delay(800);
                await Navigation.PushAsync(new Reservar());
            }
        }
    }
}