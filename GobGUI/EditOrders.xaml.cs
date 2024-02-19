using System;
using System.Net.Http;
//using Xamarin.Forms;

namespace GobGUI
{
    public partial class EditOrders : ContentPage
    {
        private HttpClient client = new HttpClient();
        private OrderManager orderManager = new OrderManager();
        public EditOrders()
        {
            InitializeComponent();
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
        // Add other flavors here
    };

            bool orderFound = await orderManager.SearchOrder(orderId);
            if (orderFound)
            {
                bool updateSuccess = await orderManager.UpdateOrderDetails(orderId, newFirstName, newLastName, flavorQuantities);
                if (updateSuccess)
                {
                    await DisplayAlert("Success", "Data updated successfully", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "Failed to update data", "OK");
                }
            }
        }
        private async void SearchButton_Clicked(object sender, EventArgs e)
        {
            // Get OrderID from the search entry
            string orderId = SearchOrderEntry.Text;

            
            if (string.IsNullOrWhiteSpace(orderId))
            {
                await DisplayAlert("Error", "Please enter an Order ID", "OK");
                return;
            }

       
            string apiUrl = $"https://your-api-url.com/orders/{orderId}";

            try
            {
              
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                   
                    string orderDetailsJson = await response.Content.ReadAsStringAsync();
                
                }
                else
                {
                    // Order not found
                    await DisplayAlert("Error", "Order not found", "OK");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }
        private async void UpdateNameButton_Clicked(object sender, EventArgs e)
        {
            string newFirstName = FirstNameEntry.Text;
            string newLastName = LastNameEntry.Text;

            // Check if both first name and last name are provided
            if (string.IsNullOrWhiteSpace(newFirstName) || string.IsNullOrWhiteSpace(newLastName))
            {
                await DisplayAlert("Error", "Please enter both first name and last name", "OK");
                return;
            }

            

            await DisplayAlert("Success", "Name updated successfully", "OK");
        }

        private async void UpdateQuantityButton_Clicked(object sender, EventArgs e)
        {
            // Get the quantity from the entry field
            if (!int.TryParse(Flavor1Entry.Text, out int newQuantity))
            {
                await DisplayAlert("Error", "Please enter a valid quantity", "OK");
                return;
            }

            

            await DisplayAlert("Success", "Quantity updated successfully", "OK");
        }
    }

    public class OrderManager
    {
        private HttpClient client = new HttpClient();
        private string apiUrl = "https://your-api-url.com/orders/";
        private ContentPage currentPage;
        public async Task<bool> UpdateOrderDetails(string orderId, string newFirstName, string newLastName, Dictionary<string, string> flavorQuantities)
        {
            try
            {
                // Check if both first name and last name are provided
                if (string.IsNullOrWhiteSpace(newFirstName) || string.IsNullOrWhiteSpace(newLastName))
                {
                    await DisplayAlert("Error", "Please enter both first name and last name", "OK");
                    return false;
                }

                // Update fName and lName using appropriate API endpoints
                // This part is left to be implemented based on your API design

                // Update the flavors from f1 to f13
                foreach (var kvp in flavorQuantities)
                {
                    string flavorId = kvp.Key;
                    string quantity = kvp.Value;

                    // Get the quantity from the entry field
                    if (!int.TryParse(quantity, out int newQuantity))
                    {
                        await DisplayAlert("Error", $"Please enter a valid quantity for {flavorId}", "OK");
                        return false;
                    }

                    // Update the quantity for flavorId using appropriate API endpoints
                    // This part is left to be implemented based on your API design
                }

                await DisplayAlert("Success", "Data updated successfully", "OK");
                return true;
            }
            catch (Exception ex)
            {
                // Handle exceptions
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
                return false;
            }
        }

  

        public async Task<bool> SearchOrder(string orderId)
        {
            if (string.IsNullOrWhiteSpace(orderId))
            {
                await DisplayAlert("Error", "Please enter an Order ID", "OK");
                return false;
            }

            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + orderId);

                if (response.IsSuccessStatusCode)
                {
                    string orderDetailsJson = await response.Content.ReadAsStringAsync();
                    return true;
                }
                else
                {
                    // Order not found
                    await DisplayAlert("Error", "Order not found", "OK");
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
                return false;
            }
        }
    }
}
