using JFAppMaui.Models;
using Newtonsoft.Json;

namespace JFAppMaui
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7212/api");
            var response = client.GetAsync("JFsuplementos").Result;

            if (response.IsSuccessStatusCode)
            {
                var JFsuplementos = response.Content.ReadAsStringAsync().Result;
                var JFsuplementosList = JsonConvert.DeserializeObject<List<JFsuplementos>>(JFsuplementos);
                listView.ItemsSource = JFsuplementosList;
            }

        }
    }

}
