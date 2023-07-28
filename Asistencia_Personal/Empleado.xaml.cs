using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace Asistencia_Personal
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Empleado : ContentPage
	{
		public Empleado ()
		{
			InitializeComponent ();
            pkGenero.Items.Add("Masculino");
            pkGenero.Items.Add("Femenino");
        }
        private void pkGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Pkgenero = pkGenero.SelectedItem.ToString();
       
        }
        private void btnGuardarJZ_Clicked(object sender, EventArgs e)
        {
           
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("nombre", txtTblActANombres.Text);
                parametros.Add("apellido", txtTblActApellido.Text);
                parametros.Add("cedula", txtTblActCedula.Text.ToString());
                parametros.Add("actcodigo", txtTblActCodigo.Text);
                parametros.Add("genero", pkGenero.SelectedItem.ToString());
                parametros.Add("observaciones", txtTblActObservacines.Text);

               
                cliente.UploadValues("http://192.168.56.1/moviles/SQL/empleado.php", "POST", parametros);

                DisplayAlert("ALERT", "Empleado Ingresado correctamente", "salir");
                Navigation.PushAsync(new Menu());

            }
            catch (Exception ex)
            {
                DisplayAlert("ALERTA", ex.Message, "cerrar");
            }
        }
        
        private void btnConsultar_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ConsultarEmpleado());
        }
    
    }
}