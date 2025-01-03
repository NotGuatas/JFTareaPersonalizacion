﻿using JFAppMaui.Models;
using Newtonsoft.Json;

namespace JFAppMaui
{
    public partial class JFMainPage : ContentPage
    {

        public JFMainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7212/api/");
            var response = client.GetAsync("jfsuplementos").Result;

            if (response.IsSuccessStatusCode)
            {
                var JFsuplementois = response.Content.ReadAsStringAsync().Result;
                var JFsuplementoisList = JsonConvert.DeserializeObject<List<JFsuplementos>>(JFsuplementois);
                listView.ItemsSource = JFsuplementoisList;
            }

        }
    }

}
