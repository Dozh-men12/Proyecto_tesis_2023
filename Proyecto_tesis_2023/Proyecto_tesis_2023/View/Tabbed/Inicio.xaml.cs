using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto_tesis_2023.View.Tabbed
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inicio : ContentPage
    {
        private List<string> gifUrls = new List<string>
        {
            "peruba3_inicio.gif",
            "peruba4_inicio.gif"
        };
        private int currentIndex = 0;

        public Inicio()
        {
            InitializeComponent();
            ChangeImageAfterDelay();
        }

        private async Task ChangeImageAfterDelay()
        {
            while (true)
            {
                await Task.Delay(3000); // Espera 3 segundos

                Device.BeginInvokeOnMainThread(() =>
                {
                    mainImage.Source = ImageSource.FromFile(gifUrls[currentIndex]); // Cambia la imagen

                    currentIndex++;
                    if (currentIndex >= gifUrls.Count)
                        currentIndex = 0;
                });
            }
        }
    }
}