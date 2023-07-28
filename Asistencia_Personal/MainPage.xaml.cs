using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Collections.ObjectModel;




using Xamarin.Forms.Xaml;


namespace Asistencia_Personal
{
    public partial class MainPage : ContentPage
    {
        public class DemoAPI
        {
            public string user { get; set; }
            public string pass { get; set; }
            public string correo { get; set; }
            public string rol { get; set; }
            public string observaciones { get; set; }
            public string lng { get; set; }
            public string jefatura { get; set; }
            public string horario { get; set; }
            public string cedula { get; set; }
            public string genero { get; set; }
            public string nombre { get; set; }
            public string apellido { get; set; }
            public string actcodigo { get; set; }
            

        }
        private ObservableCollection<Asistencia_Personal.MainPage.DemoAPI> _post;
        public MainPage()
        {
            InitializeComponent();
        }
     
        private async void Button_Clicked(object sender, EventArgs e)
        {
            /* var url = "http://192.168.56.1/moviles/post.php";
             var client = new HttpClient();
             var content = await client.GetStringAsync(url);
             List<Asistencia_Personal.MainPage.DemoAPI> posts = JsonConvert.DeserializeObject<List<Asistencia_Personal.MainPage.DemoAPI>>(content);
             _post = new ObservableCollection<Asistencia_Personal.MainPage.DemoAPI>(posts);

             MyListView.ItemsSource = _post;*/

        }

        private void btnInsertar_Clicked(object sender, EventArgs e)
        {


            Navigation.PushAsync(new Insertar());
      
        }

        private void btnConsultar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Consultar());
        }

        private void btnIniciar_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new Menu());
        }
        private void btnRegistro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }
        

    }
 
 

}
