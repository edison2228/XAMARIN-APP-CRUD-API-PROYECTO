using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Asistencia_Personal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Eliminar : ContentPage
    {
        private ObservableCollection<Asistencia_Personal.MainPage.DemoAPI> _post;
        public Eliminar(int id, string modo)
        {
            InitializeComponent();
            string myString = id.ToString();

            if (modo == "editar")
            {
               //Navigation.PushAsync(new Update(2));
        
                DisplayAlert("ALERT", "Personal actualizado correctamente", "salir");
            }
            else
            {
                eliminar();
                DisplayAlert("ALERT", "Personal borrado correctamente", "salir");
            }

          
          
        }
        public async void eliminar()
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("codigo", "2");
      

            cliente.UploadValues("http://192.168.56.1/moviles/1/post.php?codigo="+2, "DELETE", parametros);
           

        }
    }
}