using Acr.UserDialogs;
using Proyecto_tesis_2023.Model;
using Proyecto_tesis_2023.ViewModel;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        //-------------------------- A P I ----------------------------------------------
        protected override async void OnAppearing()
        {
            base.OnAppearing();

        // Llama a la función RefreshDataAsync para obtener los datos al iniciar la vista
        var data = await RefreshDataAsync();

         lvreservasdispo.ItemsSource = data.ToList();

            var campos = await LoadCampos();
            lvcampos.ItemsSource = campos.ToList();

            var dias = await LoadDias();
            lvdias.ItemsSource = dias.ToList();
            // Realiza cualquier lógica adicional con los datos obtenidos
            // Por ejemplo, puedes asignarlos a una propiedad del ViewModel o actualizar la interfaz de usuario
            // ...
        }

        //---------------------DATA PICKER ---------------------
        public async Task<List<Campo>> LoadCampos()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://192.168.18.32:3000/campos");
            var campos = JsonConvert.DeserializeObject<List<Campo>>(response);

            return campos;
        }

        public async Task<List<Dia>> LoadDias()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://192.168.18.32:3000/dias");
            var dias = JsonConvert.DeserializeObject<List<Dia>>(response);

            return dias;
        }
        public async Task<List<ReservaDisponible>> RefreshDataAsync()
        {
            Console.WriteLine("entro ala funcion");
            HttpClient client = new HttpClient();
            List<ReservaDisponible> reservadisponible = new List<ReservaDisponible>();

            Uri uri = new Uri("http://192.168.18.32:3000/reservas");

  
            HttpResponseMessage response = await client.GetAsync(uri);
            Console.WriteLine(response);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                reservadisponible = JsonConvert.DeserializeObject<List<ReservaDisponible>>(content);
                Console.WriteLine(reservadisponible);

            }
            return reservadisponible;

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