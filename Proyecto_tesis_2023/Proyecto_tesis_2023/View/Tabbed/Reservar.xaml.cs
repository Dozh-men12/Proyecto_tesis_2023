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
using System.ComponentModel;

using System.Windows.Input;
using Xamarin.Forms;


using Xamarin.Forms.Xaml;
using Acr.UserDialogs.Infrastructure;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using System.Diagnostics;

namespace Proyecto_tesis_2023.View.Tabbed
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Reservar : ContentPage
    {

        public string campoName {get; set;}
        public string diaName {get; set;}



        public Reservar()
        {

            InitializeComponent();
            this.BindingContext = new ViewModelReservar();
            BtnSearch.Clicked += Button_LoadFilter;


        }

        async void Button_LoadFilter(Object sender, EventArgs e)
        {
            Debug.WriteLine(campoName, diaName);
            var reservas = await filterDataReservas();
            stackReservasDispo.Children.Clear();
            foreach (var reserva in reservas)
            {
                var imageStackLayout = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Margin = new Thickness(20),
                    Children =
    {
        new Image
        {
            Source = "hour",
            Aspect = Aspect.AspectFit,
            WidthRequest = 20
        },
        new Label
        {
            Text = reserva.inicio.Substring(0, reserva.inicio.Length - 3),
        },
        new Label
        {
            Text = reserva.fin.Substring(0, reserva.fin.Length - 3),
        }
    }
                };

                var campoStackLayout = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Margin = new Thickness(20, 0, 20, 20),
                    Children =
    {
        new Image
        {
            Source = "campofut1",
            WidthRequest = 20
        },
        new Label
        {
            Text = reserva.campo
        }
    }
                };


                var buttonStackLayout = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    HorizontalOptions = LayoutOptions.EndAndExpand,
                    Children =
    {
        new Xamarin.Forms.Button
        {
            Text = "Reservar",
            Margin = new Thickness(0, 0, 10, 0),
            BackgroundColor = reserva.fecha_reservada == null ? Color.Green : Color.Gray,
            TextColor = Color.Black,
            CornerRadius = 10
        }
    }
                };

                var frameContentStackLayout = new StackLayout
                {
                    BackgroundColor = Color.FromHex("#D9D9D9"),
                    HeightRequest = 100,
                    Children = { imageStackLayout, campoStackLayout, buttonStackLayout }
                };

                var frame = new Frame
                {
                    BorderColor = Color.Black,
                    Padding = new Thickness(2),
                    Margin = new Thickness(20, 0, 20, 0),
                    HeightRequest = 165,
                    Content = frameContentStackLayout
                };

                stackReservasDispo.Children.Add(frame);
            }
            //lvreservasdispo.ItemsSource = data.ToList();
        }

        //-------------------------- A P I ----------------------------------------------
        protected override async void OnAppearing()
        {
            base.OnAppearing();

        // Llama a la función RefreshDataAsync para obtener los datos al iniciar la vista
            var reservas = await RefreshDataAsync();
            foreach (var reserva in reservas)
            {
                var imageStackLayout = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Margin = new Thickness(20),
                    Children =
    {
        new Image
        {
            Source = "hour",
            Aspect = Aspect.AspectFit,
            WidthRequest = 20
        },
        new Label
        {
            Text = reserva.inicio.Substring(0, reserva.inicio.Length - 3),
        },
        new Label
        {
            Text = reserva.fin.Substring(0, reserva.fin.Length - 3),
        }
    }
                };

                var campoStackLayout = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Margin = new Thickness(20, 0, 20, 20),
                    Children =
    {
        new Image
        {
            Source = "campofut1",
            WidthRequest = 20
        },
        new Label
        {
            Text = reserva.campo
        }
    }
                };
                

                var buttonStackLayout = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    HorizontalOptions = LayoutOptions.EndAndExpand,
                    Children =
    {
        new Xamarin.Forms.Button
        {
            Text = "Reservar",
            Margin = new Thickness(0, 0, 10, 0),
            BackgroundColor = reserva.fecha_reservada == null ? Color.Green : Color.Gray,
            TextColor = Color.Black,
            CornerRadius = 10
        }
    }
                };

                var frameContentStackLayout = new StackLayout
                {
                    BackgroundColor = Color.FromHex("#D9D9D9"),
                    HeightRequest = 100,
                    Children = { imageStackLayout, campoStackLayout, buttonStackLayout }
                };

                var frame = new Frame
                {
                    BorderColor = Color.Black,
                    Padding = new Thickness(2),
                    Margin = new Thickness(20, 0, 20, 0),
                    HeightRequest = 165,
                    Content = frameContentStackLayout
                };

                stackReservasDispo.Children.Add(frame);
            }


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

        //ip  Oscar http://192.168.18.32:3000/campos
        //ip Carlos http://192.168.1.4:3000/campos

        public async Task<List<Dia>> LoadDias()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://192.168.18.32:3000/dias");
            var dias = JsonConvert.DeserializeObject<List<Dia>>(response);

            return dias;
        }

        private void lvcampos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var selectedCampo = (Campo)picker.SelectedItem;

            campoName = selectedCampo.nombre;
        }

        private void lvdias_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var selectedDias = (Dia)picker.SelectedItem;

            diaName = selectedDias.nombre;
        }


        public async Task<List<ReservaDisponible>> filterDataReservas()
        {

            HttpClient client = new HttpClient();
            List<ReservaDisponible> reservadisponible = new List<ReservaDisponible>();

            Uri uri = new Uri("http://192.168.18.32:3000/reservas/" + diaName + "/" + campoName);

            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                reservadisponible = JsonConvert.DeserializeObject<List<ReservaDisponible>>(content);
            }

            return reservadisponible;
        }

        public async Task<List<ReservaDisponible>> RefreshDataAsync()
        {
  
            HttpClient client = new HttpClient();
            List<ReservaDisponible> reservadisponible = new List<ReservaDisponible>();

            Uri uri = new Uri("http://192.168.18.32:3000/reservas");

  
            HttpResponseMessage response = await client.GetAsync(uri);
            Console.WriteLine(response);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                reservadisponible = JsonConvert.DeserializeObject<List<ReservaDisponible>>(content);


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