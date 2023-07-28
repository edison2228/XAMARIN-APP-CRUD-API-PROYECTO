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
	public partial class UpdateJefatura : ContentPage
	{
		public UpdateJefatura (string jefatura, string horario, string observaciones)
		{
			InitializeComponent ();
            obtener(jefatura, horario, observaciones);
        }
        public void obtener(string jefatura, string horario, string observaciones)
        {

            txtJefatura.Text = jefatura;
            txtHorario.Text = horario;
            txtObservaciones.Text = observaciones;

        }
        
              private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Menu());
        }
        private void btnUpdateJefatura_Clicked(object sender, EventArgs e)
        {
            try
            {

                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("user", txtJefatura.Text);
                parametros.Add("correo", txtHorario.Text);
                parametros.Add("observaciones", txtObservaciones.Text);

                cliente.UploadValues(" http://192.168.56.1/moviles/SQL/jefatura.php?jefatura=" + txtJefatura.Text + "&horario=" + txtHorario.Text +"&observaciones=" + txtObservaciones.Text, "PUT", parametros);

                txtJefatura.Text = txtJefatura.Text;
                txtHorario.Text = txtHorario.Text;
                txtObservaciones.Text = txtObservaciones.Text;


                DisplayAlert("ALERT", "Dato actualizado correctamente", "salir");
            }
            catch (Exception ex)
            {
                DisplayAlert("ALERTA", ex.Message, "cerrar");
            }
        }
        private void btnRegresarJefatura_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ConsultarJefatura());
        }

    }
}