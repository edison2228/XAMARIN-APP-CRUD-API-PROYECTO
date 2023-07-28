using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Asistencia_Personal.MainPage;

namespace Asistencia_Personal
{
   
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Consultar : ContentPage
    {
  

        private ObservableCollection<Asistencia_Personal.MainPage.DemoAPI> _post;

        public Consultar()
        {
            InitializeComponent();

            obtener();
   
        }
        public IEnumerable ItemsSource { get; set; }
        public async void obtener()
        {
            var url = "http://192.168.56.1/moviles/SQL/post.php";
            var client = new HttpClient();
            var content = await client.GetStringAsync(url);
            List<Asistencia_Personal.MainPage.DemoAPI> posts = JsonConvert.DeserializeObject<List<Asistencia_Personal.MainPage.DemoAPI>>(content);
            _post = new ObservableCollection<Asistencia_Personal.MainPage.DemoAPI>(posts);

            MyListView.ItemsSource = _post;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var url = "http://192.168.100.71:8013/moviles/SQL/post.php";
            var client = new HttpClient();
            var content = await client.GetStringAsync(url);
            List<Asistencia_Personal.MainPage.DemoAPI> posts = JsonConvert.DeserializeObject<List<Asistencia_Personal.MainPage.DemoAPI>>(content);
            _post = new ObservableCollection<Asistencia_Personal.MainPage.DemoAPI>(posts);

            MyListView.ItemsSource = _post; 
        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Menu());
        }

        public  void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var mydetails = e.SelectedItem as DemoAPI;
            string codigo = mydetails.user.ToString();
            string nombre = mydetails.correo;
            string apellido = mydetails.rol;
            string edad = mydetails.observaciones;
            string ubic = mydetails.lng;
        


              DisplayAlert("ALERT", mydetails.lng, "ok");
            Navigation.PushAsync(new Update(codigo, nombre, apellido, edad, ubic));
        }

    }
}