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
	public partial class UpdateEmpleado : ContentPage
	{
        //nombre, apelldio, obsercaiones, genero, actcodigo, cedula
        public UpdateEmpleado (string nombre, string apellido, string obsercaiones, string genero, string actcodigo, string cedula)
		{
			InitializeComponent ();
            obtener(nombre, apellido, obsercaiones, genero, actcodigo, cedula);
        }
        public void obtener(string nombre, string apellido, string obsercaiones, string genero, string actcodigo, string cedula)
        {

            txtnombre.Text = nombre;
            txtapellido.Text = apellido;
            txtObservaciones.Text = obsercaiones;
            txtgenero.Text = genero;
            txtactocodigo.Text = actcodigo;
            txtcedula.Text = cedula;

        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Menu());
        }
        private void btnUpdateEmpleado_Clicked(object sender, EventArgs e)
        {
            try
            {

                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("nombre", txtnombre.Text);
                parametros.Add("apellido", txtapellido.Text);
                parametros.Add("observaciones", txtObservaciones.Text);
                parametros.Add("genero", txtgenero.Text);
                parametros.Add("atccodigo", txtactocodigo.Text);
                parametros.Add("cedula", txtcedula.Text);
         

                cliente.UploadValues(" http://192.168.56.1/moviles/SQL/empleado.php?nombre=" + txtnombre.Text + "&apellido=" + txtapellido.Text + "&cedula=" + txtcedula.Text + "&observaciones=" + txtObservaciones.Text + "&genero=" + txtgenero.Text + "&actcodigo=" + txtactocodigo.Text, "PUT", parametros);

                txtnombre.Text = txtnombre.Text;
                txtapellido.Text = txtapellido.Text;
                txtObservaciones.Text = txtObservaciones.Text;
                txtgenero.Text = txtgenero.Text;
                txtactocodigo.Text = txtactocodigo.Text;
                txtcedula.Text = txtcedula.Text;


                DisplayAlert("ALERT", "Dato actualizado correctamente", "salir");
            }
            catch (Exception ex)
            {
                DisplayAlert("ALERTA", ex.Message, "cerrar");
            }
        }
        private void btnRegresarEmpleado_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ConsultarJefatura());
        }
    }
}