using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
	public partial class ConsultarJefatura : ContentPage

	{
        private ObservableCollection<Asistencia_Personal.MainPage.DemoAPI> _post;
        public ConsultarJefatura ()
		{
			InitializeComponent ();
            obtener();
        }
        public IEnumerable ItemsSource { get; set; }
        public async void obtener()
        {
            var url = "http://192.168.56.1/moviles/SQL/listado_jefaturas.php";
            var client = new HttpClient();
            var content = await client.GetStringAsync(url);
            List<Asistencia_Personal.MainPage.DemoAPI> posts = JsonConvert.DeserializeObject<List<Asistencia_Personal.MainPage.DemoAPI>>(content);
            _post = new ObservableCollection<Asistencia_Personal.MainPage.DemoAPI>(posts);

            MyListView.ItemsSource = _post;
        }
        public void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var mydetails = e.SelectedItem as DemoAPI;
            string jefatura = mydetails.jefatura;
            string horario = mydetails.horario;
            string observaciones = mydetails.observaciones;

           
            Navigation.PushAsync(new UpdateJefatura(jefatura, horario, observaciones));
        }
        
               private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Menu());
        }
    }
}