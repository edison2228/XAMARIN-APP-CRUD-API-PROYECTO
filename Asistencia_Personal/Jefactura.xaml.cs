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
	public partial class Jefactura : ContentPage
	{
		public Jefactura ()
		{
			InitializeComponent ();
            pkGenero.Items.Add("Manana");
            pkGenero.Items.Add("Tarde");
            pkGenero.Items.Add("Noche");
            pkGenero.Items.Add("Refuerzo");
        }
        private void pkGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Pkgenero = pkGenero.SelectedItem.ToString();
            string TblJzNombre = txtTblJzNombre.Text;
            string TblJzObservaciones = txtTblJzObservaciones.Text;
        }
        private void btnGuardarJZ_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("jefatura", txtTblJzNombre.Text);
                parametros.Add("horario", pkGenero.SelectedItem.ToString());
                parametros.Add("observaciones", txtTblJzObservaciones.Text);
          

                cliente.UploadValues("http://192.168.56.1/moviles/SQL/jefatura.php", "POST", parametros);

                DisplayAlert("ALERT", "Jefatura Ingresado correctamente", "salir");
                Navigation.PushAsync(new Menu());

            }
            catch (Exception ex)
            {
                DisplayAlert("ALERTA", ex.Message, "cerrar");
            }
        }
        
   private void btnConsultar_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ConsultarJefatura());
        }


    }
}