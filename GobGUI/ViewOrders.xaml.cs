namespace GobGUI;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.Json.Serialization;
using API_BlobsOfGobs;
using API_BlobsOfGobs.Models;

public partial class ViewOrders : ContentPage
{
	public ViewOrders()
	{
		InitializeComponent();
	}

    async private Task<List<Order>> GetPeopleAsync()
    {
        string apiUrl = "https://localhost:7005/api/Orders";
        List<Order> orders = null;
        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);


                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    orders = JsonConvert.DeserializeObject<List<Order>>(jsonString);
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

    private void GetBtn_Clicked(object sender, EventArgs e)
    {

    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}