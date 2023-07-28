using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Asistencia_Personal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();
            
        }

        private void btnRegistrojz_Clicked(object sender, EventArgs e)
        {
        
             Navigation.PushAsync(new Jefactura());
        }
        private void btnRegistroAct_Clicked(object sender, EventArgs e)
        {
       
             Navigation.PushAsync(new Empleado());
        }
        private void btnConsuktaUser_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Insertar());
            // Navigation.PushAsync(new Registro());
        }
        private void btnRgusuario_Clicked(object sender, EventArgs e)
        {
         
            Navigation.PushAsync(new Registro());
        }
     
        private void btnConsultar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Consultar());
        }
       /* private void btnConsultarUSer_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Consultar());
        }*/
        

    }
}