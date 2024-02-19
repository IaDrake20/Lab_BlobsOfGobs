using API_BlobsOfGobs.Models;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
//using Xamarin.Forms;

namespace GobGUI
{
    public partial class EditOrders : ContentPage
    {
        private string orderid;
        private HttpClient client = new HttpClient();

        public EditOrders()
        {
            InitializeComponent();
            GetFlavorsAsync();
        }
        async private Task<List<GobFlavor>> GetFlavorsAsync()
        {
            string apiUrl = "https://localhost:7005/api/GobFlavors";
            List<GobFlavor> flavors = null;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);


                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();
                        flavors = JsonConvert.DeserializeObject<List<GobFlavor>>(jsonString);

                        for (int i = 1; i <= 15; i++)
                        {
                            var label = this.FindByName<Label>($"f{i}");
                            label.Text = flavors.ElementAt(i - 1).FlavorName;
                        }
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

                return flavors;
            }

        }
        private async void SearchButton_Clicked(object sender, EventArgs e)
        {
        }
            private async void Button_Clicked2(object sender, EventArgs e)
        {
            string orderId = SearchOrderEntry.Text;
            string newFirstName = FirstNameEntry.Text;
            string newLastName = LastNameEntry.Text;

            Dictionary<string, string> flavorQuantities = new Dictionary<string, string>
    {
        { "f1", f1.Text },
        { "f2", f2.Text },
        { "f3", f3.Text },
        { "f4", f4.Text },
        { "f5", f5.Text },
        { "f6", f6.Text },
        { "f7", f7.Text },
        { "f8", f8.Text },
        { "f9", f9.Text },
        { "f10", f10.Text },
        { "f11", f11.Text },
        { "f12", f12.Text },
        { "f13", f13.Text },

    };


        }
        async private Task PutQuantityAsync(OrderGob ord)
        {
            string apiUrl = "https://localhost:7005/api/OrderGobs";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string jsonString = JsonConvert.SerializeObject(ord);
                    HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync(apiUrl, content);

                }

                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                }

            }
        }

        async private Task GetOrderAsync()
        {
            string apiUrl = "https://localhost:7005/api/Order";
            List<GobFlavor> flavors = null;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);


                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();
                        flavors = JsonConvert.DeserializeObject<List<GobFlavor>>(jsonString);

                        for (int i = 1; i <= 15; i++)
                        {
                            var label = this.FindByName<Label>($"f{i}");
                            label.Text = flavors.ElementAt(i - 1).FlavorName;
                        }
                    }
                    else
                    {
                        Debug.WriteLine("API request failed with status code:" + response.StatusCode);
                        
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    
                }

                
            }
        }
    }
}
