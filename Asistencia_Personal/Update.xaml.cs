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
    public partial class Update : ContentPage
    {
        private ObservableCollection<Asistencia_Personal.MainPage.DemoAPI> _post;
        public Update( string codigo, string nombre, string apellido, string edad, string ubic)
        {
            InitializeComponent();
            obtener(codigo, nombre, apellido, edad, ubic);
        }
        public  void obtener(string codigo, string nombre, string apellido, string edad, string ubic)
        {
      
            txtCodigo.Text = codigo;
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtEdad.Text = edad;
            txtUbic.Text = ubic;

        }
        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Consultar());
        }

        private void btnUpdate_Clicked(object sender, EventArgs e)
        {

            try
            {
               
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("user", txtCodigo.Text);
                parametros.Add("correo", txtNombre.Text);
                parametros.Add("rol", txtApellido.Text);
                parametros.Add("observaciones", txtEdad.Text);

                cliente.UploadValues(" http://192.168.56.1/moviles/SQL/usuario.php?user=" + txtCodigo.Text + "&correo=" + txtNombre.Text + "&rol=" + txtApellido.Text + "&observaciones=" + txtEdad.Text, "PUT", parametros);

                txtCodigo.Text = txtCodigo.Text;
                txtNombre.Text = txtNombre.Text;
                txtApellido.Text = txtApellido.Text;
                txtEdad.Text = txtEdad.Text;


                DisplayAlert("ALERT", "Dato actualizado correctamente", "salir");
            }
            catch (Exception ex)
            {
                DisplayAlert("ALERTA", ex.Message, "cerrar");
            }
        }

        private void btnInsertar_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
 
                cliente.UploadValues(" http://192.168.100.71:8095/moviles/SQL/post.php?codigo=" + Int16.Parse(txtCodigo.Text), "DELETE", parametros);

                DisplayAlert("ALERT", "Dato eliminado correctamente", "salir");
            }
            catch (Exception ex)
            {
                DisplayAlert("ALERTA", ex.Message, "cerrar");
            }
        }


    }
}