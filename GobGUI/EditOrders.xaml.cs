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

    }
}
