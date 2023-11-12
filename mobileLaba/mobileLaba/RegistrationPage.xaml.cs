using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobileLaba
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public Charity CurrentCharity { get; set; }
        public Registration CurrentRegistration { get; set; } = new Registration();
        public RegistrationPage(Charity currentCharity)
        {
            InitializeComponent();

            CurrentCharity = currentCharity;
            CurrentRegistration.CharityId = currentCharity.CharityId;
            BindingContext = this;
            UpdateRegistrations();
        }

        private void UpdateRegistrations()
        {
            var client = new WebClient();
            var response = client.DownloadString("http://10.0.2.2:51192/api/Registrations");
            LViewRegistration.ItemsSource = JsonConvert.DeserializeObject<List<Registration>>(response);
        }

        private void ButtonSend_Clicked(object sender, EventArgs e)
        {
            var client = new WebClient();
            client.Headers.Add(HttpRequestHeader.ContentType, "aplication/json");
            var result = client.UploadString("http://10.0.2.2:51192/api/Registrations", JsonConvert.SerializeObject(CurrentRegistration));
            UpdateRegistrations();
        }
    }
}