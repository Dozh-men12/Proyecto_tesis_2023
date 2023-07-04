using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto_tesis_2023.View.Tabbed
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Reglamentos : ContentPage
    {
        private bool isExpanded = false;
        private bool isSecondExpanded = false;
        private bool isTercerExpanded = false;
        private bool isCuartoExpanded = false;
        private bool isQuintoExpanded = false;
        public Reglamentos()
        {
            InitializeComponent();
        }
        private void ToggleAccordion(object sender, EventArgs e)
        {
            if (isExpanded)
            {
                AlumnoLabel.IsVisible = false;
                ArrowLabel.Text = "▼";

                // Animación de encogimiento del cuadro
                var animation = new Animation(v => AccordionFrame.HeightRequest = v, 70, 70);
                animation.Commit(this, "ShrinkAnimation", length: 200, finished: (v, c) => AccordionFrame.HeightRequest = 70);
            }
            else
            {
                AlumnoLabel.IsVisible = true;
                ArrowLabel.Text = "▼";

                // Animación de agrandamiento del cuadro
                var animation = new Animation(v => AccordionFrame.HeightRequest = v, 70, 300);
                animation.Commit(this, "ExpandAnimation", length: 200);
            }

            isExpanded = !isExpanded;
        }

        private void ToggleSecondFrame(object sender, EventArgs e)
        {
            if (isSecondExpanded)
            {
                AlumnoLabel2.IsVisible = false;
                ArrowLabel2.Text = "▼";

                // Animación de encogimiento del segundo frame
                var animation = new Animation(v => SecondFrame.HeightRequest = v, 70, 70);
                animation.Commit(this, "ShrinkSecondAnimation", length: 200, finished: (v, c) => SecondFrame.HeightRequest = 70);
            }
            else
            {
                AlumnoLabel2.IsVisible = true;
                ArrowLabel2.Text = "▼";

                // Animación de agrandamiento del segundo frame
                var animation = new Animation(v => SecondFrame.HeightRequest = v, 70, 300);
                animation.Commit(this, "ExpandSecondAnimation", length: 200);
            }

            isSecondExpanded = !isSecondExpanded;
        }

        private void ToggleTercerFrame(object sender, EventArgs e)
        {
            if (isTercerExpanded)
            {
                AlumnoLabel3.IsVisible = false;
                ArrowLabel3.Text = "▼";
                var animation = new Animation(v => TercerFrame.HeightRequest = v, 70, 70);
                animation.Commit(this, "ShrinkSecondAnimation", length: 200, finished: (v, c) => TercerFrame.HeightRequest = 70);
            }
            else
            {
                AlumnoLabel3.IsVisible = true;
                ArrowLabel3.Text = "▼";
                var animation = new Animation(v => TercerFrame.HeightRequest = v, 70, 300);
                animation.Commit(this, "ExpandSecondAnimation", length: 200);
            }

            isTercerExpanded = !isTercerExpanded;
        }

        private void ToggleCuartoFrame(object sender, EventArgs e)
        {
            if (isCuartoExpanded)
            {
                AlumnoLabel4.IsVisible = false;
                ArrowLabel4.Text = "▼";
                var animation = new Animation(v => CuartoFrame.HeightRequest = v, 70, 70);
                animation.Commit(this, "ShrinkSecondAnimation", length: 200, finished: (v, c) => CuartoFrame.HeightRequest = 70);
            }
            else
            {
                AlumnoLabel4.IsVisible = true;
                ArrowLabel4.Text = "▼";
                var animation = new Animation(v => CuartoFrame.HeightRequest = v, 70, 300);
                animation.Commit(this, "ExpandSecondAnimation", length: 200);
            }

            isCuartoExpanded = !isCuartoExpanded;
        }

        private void ToggleQuintoFrame(object sender, EventArgs e)
        {
            if (isQuintoExpanded)
            {
                AlumnoLabel5.IsVisible = false;
                ArrowLabel5.Text = "▶";
                var animation = new Animation(v => QuintoFrame.HeightRequest = v, 70, 70);
                animation.Commit(this, "ShrinkSecondAnimation", length: 200, finished: (v, c) => QuintoFrame.HeightRequest = 70);
            }
            else
            {
                AlumnoLabel5.IsVisible = true;
                ArrowLabel5.Text = "▼";
                var animation = new Animation(v => QuintoFrame.HeightRequest = v, 70, 300);
                animation.Commit(this, "ExpandSecondAnimation", length: 200);
            }

            isQuintoExpanded = !isQuintoExpanded;
        }
    }
}