using GobGUI.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace GobGUI
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

       
        async private Task<List<Orders>> GetPeopleAsync()
        {
            string apiUrl = "https://localhost:7005/swagger/api/Orders";
            List<Orders> orders = null;
            using (HttpClient client = new HttpClient()) 
            { 
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);


                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();
                        orders = JsonConvert.DeserializeObject<List<Orders>>(jsonString);
                    }
                    else
                    {
                        Debug.WriteLine("API request failed with status code:" + response.StatusCode);
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return null;
                }
            }
            return orders;
        }

        async private void GetDataBtn_Clicked(object sender, EventArgs e)
        {
            Debug.WriteLine("GetDataBtn_Clicked");
            var orders = await GetPeopleAsync();

            MainThread.BeginInvokeOnMainThread(() =>
            {
                ordersListView.ItemsSource = orders;
            });
        }
    }

}
