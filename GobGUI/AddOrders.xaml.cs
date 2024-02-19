namespace GobGUI;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		//temporary way to show different orders
		int orderNum = 1;
		lblSubmit.Text = "Order #" + orderNum + " was successfully submitted.";
		orderNum++;
    }
}