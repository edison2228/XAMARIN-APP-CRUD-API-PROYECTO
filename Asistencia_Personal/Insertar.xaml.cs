using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


using System.ComponentModel;

using System.Net.Http;
using System.Net;

using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Asistencia_Personal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Insertar : ContentPage
    {
      
        public Insertar()
        {
            InitializeComponent();
        }

        private void btnRegisto_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Insertar());
        }

        private void btnInsertar_Clicked(object sender, EventArgs e)
        {
              try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("codigo", txtCodigo.Text);
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);

            cliente.UploadValues("http://192.168.56.1/moviles/SQL/post.php", "POST", parametros);
           
                DisplayAlert("ALERT", "Dato ingresado", "salir");

        }
        catch(Exception ex)
        {
            DisplayAlert("ALERTA", ex.Message, "cerrar");
        }
        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Menu());
        }
    }
}