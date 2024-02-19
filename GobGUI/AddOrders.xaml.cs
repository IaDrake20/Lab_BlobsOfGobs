
using API_BlobsOfGobs.Models;
using Microsoft.Maui.Graphics.Text;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace GobGUI;

public partial class NewPage1 : ContentPage
{
    private string orderid;
    public NewPage1()
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

    async private void SubmitBtn_Clicked(object sender, EventArgs e)
    {
        Customer newCust = new Customer();
        newCust.CustomerId = Guid.NewGuid().ToString();
        newCust.Fname = FirstNameEntry.Text;
        newCust.Lname = LastNameEntry.Text;
        await PostCustomersAsync(newCust);

        Order newOrder = new Order();
        newOrder.OrderId = Guid.NewGuid().ToString();
        orderid = newOrder.OrderId;
        newOrder.CustomerId = newCust.CustomerId;
        newOrder.IsPaid = true;
        await PostOrdersAsync(newOrder);

        List<GobFlavor> flavors = null;

        string apiUrl = "https://localhost:7005/api/GobFlavors";

        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);


                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    flavors = JsonConvert.DeserializeObject<List<GobFlavor>>(jsonString);

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

        for (int i = 1; i <= 15; i++)
        {
            var entry = this.FindByName<Entry>($"e{i}");
            if (entry.Text != null)
            {
                string flavName = this.FindByName<Label>($"f{i}").Text;
                foreach (GobFlavor flav in flavors)
                {
                    if (flav.FlavorName == flavName)
                    {
                        OrderGob og = new OrderGob();
                        og.OrderGobId = Guid.NewGuid().ToString();
                        og.OrderId = newOrder.OrderId;
                        og.FlavorId = flav.FlavorId;
                        og.Quantity = int.Parse(entry.Text);
                        await PostOrderGobsAsync(og);
                    }
                }
            }
        }

        
        lblSubmit.Text = "Order #" + newOrder.OrderId + " was successfully submitted.";

        btnCopy.IsVisible = true;

    }

    async private Task PostCustomersAsync(Customer cust)
    {
        string apiUrl = "https://localhost:7005/api/Customers";
        using (HttpClient client = new HttpClient())
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(cust);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

            }

            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }

        }
    }

    async private Task PostOrdersAsync(Order ord)
    {
        string apiUrl = "https://localhost:7005/api/Orders";
        using (HttpClient client = new HttpClient())
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(ord);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

            }

            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }

        }
    }
    async private Task PostOrderGobsAsync(OrderGob ord)
    {
        string apiUrl = "https://localhost:7005/api/OrderGobs";
        using (HttpClient client = new HttpClient())
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(ord);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

            }

            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }

        }

    }

    private async void Button_Clicked2(object sender, EventArgs e)
    {
        String valueToCopy = "" + orderid;

        await Clipboard.SetTextAsync(valueToCopy);

        // Optionally, show a confirmation to the user
        lblSubmit.Text = "Order #" + orderid + " was copied to the clipboard.";
    }

}