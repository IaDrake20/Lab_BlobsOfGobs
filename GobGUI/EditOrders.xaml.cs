using API_BlobsOfGobs.Models;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
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

        async private Task<GobFlavor> GetFlavorAsync(int num)
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
                            if (num == i)
                            {
                                flavors.ToArray();
                                GobFlavor fl = flavors[0];
                                return fl;
                            }


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

                return null;
            }

        }
        private async void Button_Clicked2(object sender, EventArgs e)
        {

            string orderId = SearchOrderEntry.Text;
            bool goodId = await GetOrderAsync(orderId);
            if (goodId = true)
            {

                // string newFirstName = FirstNameEntry.Text;
                // string newLastName = LastNameEntry.Text;

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

                for (int i = 1; i <= 15; i++)
                {
                    var entry = this.FindByName<Entry>($"e{i}");
                    try
                    {
                        if (entry.Text != null)
                        {
                            OrderGob bob = await getOrderGobsAsync(orderId);
                            int ne = Int32.Parse(entry.Text);
                            await PutOrderGobsAsync(bob, ne);

                        }
                    }
                    catch (Exception te)
                    {

                    }


                }

            }
        }
        async private Task PutOrderGobsAsync(OrderGob ord, int num)
        {
            string apiUrl = "https://localhost:7005/api/OrderGobs";

            using (HttpClient client = new HttpClient())
            {
                try
                {

                    ord.Quantity = num;
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
        async private Task<OrderGob> getOrderGobsAsync(String OrderId)
        {
            OrderGob badval = null;
            string apiUrl = "https://localhost:7005/api/OrderGob";
            List<OrderGob> orders = new List<OrderGob>();
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);


                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();
                        orders = JsonConvert.DeserializeObject<List<OrderGob>>(jsonString);
                        for (int i = 1; i <= orders.Count; i++)
                        {
                            OrderGob[] newarr = orders.ToArray();
                            string temp = newarr[0].ToString();

                            if (OrderId.Equals(temp))
                                return newarr[0];
                            return badval;
                        }
                        await DisplayAlert("Error", "Please enter an Order ID", "OK");

                    }
                    else
                    {

                        return badval;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return badval;
                }


            }
            return badval;
        }
        async private Task<bool> GetOrderAsync(string orderID)
        {
            string apiUrl = "https://localhost:7005/api/Orders";
            List<Order> orders = new List<Order>();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();
                        orders = JsonConvert.DeserializeObject<List<Order>>(jsonString);

                        foreach (Order order in orders)
                        {
                            if (orderID.Equals(order.OrderId))
                                return true;
                        }

                        await DisplayAlert("Error", "Order not found", "OK");
                        return false;
                    }
                    else
                    {
                        await DisplayAlert("Error", "Failed to retrieve orders", "OK");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    await DisplayAlert("Error", "An error occurred while processing the request", "OK");
                    return false;
                }
            }
        }
    }
}
