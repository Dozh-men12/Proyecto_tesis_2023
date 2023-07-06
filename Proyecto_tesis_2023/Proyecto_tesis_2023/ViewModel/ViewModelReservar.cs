using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Proyecto_tesis_2023.ViewModel
{
    public class ViewModelReservar : ViewModelBase
    {
       public ICommand CambiarColor { protected set; get; }


        //
       public  ViewModelReservar() 
        {
            CambiarColor = new Command(() =>
            {


            });
        }
    }
}
