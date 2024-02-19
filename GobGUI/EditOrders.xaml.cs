using System;
using System.Net.Http;
//using Xamarin.Forms;

namespace GobGUI
{
    public partial class EditOrders : ContentPage
    {
        private HttpClient client = new HttpClient();

        public EditOrders()
        {
            InitializeComponent();
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
}
