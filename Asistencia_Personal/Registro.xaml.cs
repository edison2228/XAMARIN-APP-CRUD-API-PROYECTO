using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


using Xamarin.Essentials;


namespace Asistencia_Personal
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Registro : ContentPage
	{
		public Registro ()
		{
			InitializeComponent ();
		}
        private void btnGuardarUsuario(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("user", txtUser.Text);
                parametros.Add("pass", txtPass.Text);
                parametros.Add("correo", txtCorreo.Text);
                parametros.Add("rol", txtRol.Text);
                parametros.Add("observaciones", txtobservaciones.Text);
                parametros.Add("lat", resultLocation.Text);
                parametros.Add("lng", resultLocation.Text);

                cliente.UploadValues("http://192.168.56.1/moviles/SQL/usuario.php", "POST", parametros);

                DisplayAlert("ALERT", "Usuario Ingresado correctamente", "salir");
                Navigation.PushAsync(new MainPage());

            }
            catch (Exception ex)
            {
                DisplayAlert("ALERTA", ex.Message, "cerrar");
            }
        }
        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            entry.Text = "Quito";
            try
            {
                var result = await Geocoding.GetLocationsAsync(entry.Text);

                if (result.Any())
                    resultLocation.Text = $"lat: {result.FirstOrDefault()?.Latitude}, long: {result.FirstOrDefault()?.Longitude}";
            }
            catch (FeatureNotSupportedException notsupportedex)
            {
                // TODO: Do something useful
            }
            catch (Exception ex)
            {
                // TODO: Do something useful
            }
        }
    }
}