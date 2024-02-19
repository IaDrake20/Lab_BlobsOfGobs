
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
        orderNum++;		
		lblSubmit.Text = "Order #" + orderNum + " was successfully submitted.";
		
        btnCopy.IsVisible = true;
    }

    private async void Button_Clicked2(object sender, EventArgs e)
    {
        String valueToCopy = "" + orderNum;

        await Clipboard.SetTextAsync(valueToCopy);

        // Optionally, show a confirmation to the user
        lblSubmit.Text = "Order #" + orderNum + " was copied to the clipboard.";
    }

    public int orderNum = 0;
}