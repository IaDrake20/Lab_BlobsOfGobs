namespace GobGUI;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.Json.Serialization;
using API_BlobsOfGobs;
using API_BlobsOfGobs.Models;
using System.ComponentModel;
using System.Collections.ObjectModel;

public partial class ViewOrders : ContentPage
{
    public ObservableCollection<orderForTable> MasterList {get; set;}
    
    public ViewOrders()
	{
		InitializeComponent();
        MasterList = new ObservableCollection<orderForTable>();
        GetOrdersAsync();
        this.BindingContext = this;
	}


    public class orderForTable
    {
        public string firstName = "";
        public string lastName = "";
        public string orderid = "";
        public Dictionary<string, int> gobs = new Dictionary<string, int>();

        public string DisplayGobs
        {
            get
            {
                return string.Join(", ", gobs.Select(kv => $"{kv.Key.ToString()}: {kv.Value}")) + "\t";
            }
        }

        public string DisplayName
        {
            get
            {
                return "Customer: " + firstName + " " + lastName + "\t";
            }
        }

        public string DisplayOrderId
        {
            get
            {
                return "Order Number: " + orderid + "\t";
            }
        }
    }

    async private Task GetOrdersAsync()
    {
        MasterList = new ObservableCollection<orderForTable>();
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

                    foreach (Order ord in orders)
                    {

                        List<OrderGob> ordgoblist = await GetOrderGobsAsync(ord.OrderId);
                        Customer ordCust = await GetCustomersAsync(ord.CustomerId);

                        orderForTable newEntry = new orderForTable();
                        newEntry.firstName = ordCust.Fname;
                        newEntry.lastName = ordCust.Lname;
                        newEntry.orderid = ord.OrderId;
                        foreach (OrderGob gob in ordgoblist)
                        {
                            GobFlavor gf = await GetFlavorsAsync(gob.FlavorId);
                            newEntry.gobs.Add(gf.FlavorName,gob.Quantity);
                        }
                        MainThread.BeginInvokeOnMainThread(() =>
                        {
                            MasterList.Add(newEntry);
                        });
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

    
    async private Task<List<OrderGob>> GetOrderGobsAsync(string ordId)
    {
        string apiUrl = "https://localhost:7005/api/OrderGobs";
        List<OrderGob> orders = null;
        List<OrderGob> matching = new List<OrderGob>();
        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);


                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    orders = JsonConvert.DeserializeObject<List<OrderGob>>(jsonString);

                    foreach (OrderGob og in orders)
                    {
                        if(og.OrderId == ordId)
                        {
                            matching.Add(og);
                        }
                    }
                    return matching;
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


    async private Task<Customer> GetCustomersAsync(string custid)
    {
        string apiUrl = "https://localhost:7005/api/Customers";
        List<Customer> customers = null;
        Customer matching = new Customer();

        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);


                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    customers = JsonConvert.DeserializeObject<List<Customer>>(jsonString);

                    foreach (Customer cust in customers)
                    {
                        if (cust.CustomerId == custid)
                        {
                            matching = cust;
                        }
                    }
                    return matching;
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
    }
    async private Task<GobFlavor> GetFlavorsAsync(string flavId)
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
                    foreach(GobFlavor flav in flavors)
                    {
                        if(flav.FlavorId == flavId)
                        {
                            return flav;
                        }
                    }
                    return null;
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

    }
}