using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace mobileLaba
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
            var client = new WebClient();
            var respose = client.DownloadString("http://10.0.2.2:51192/api/Charities");
            LstMain.ItemsSource = JsonConvert.DeserializeObject<List<Charity>>(respose);
        }

        private void LstMain_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new RegistrationPage(LstMain.SelectedItem as Charity));
        }
    }
}
