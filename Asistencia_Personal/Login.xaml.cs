using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Asistencia_Personal;

namespace AppMovilAMT.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        
        public Login()
        {
            InitializeComponent();
     

        }
        //metodo de validacion
     

        private void btnIniciar_Clicked(object sender, EventArgs e)
        {
            //  Navigation.PushAsync(new Error());
            
           

        }
        private void btnRegistro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }



    }
}