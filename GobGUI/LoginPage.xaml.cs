using System.Diagnostics;

namespace GobGUI;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private void LogInBtn_Clicked(object sender, EventArgs e)
    {
        LogInBtn.Text = "yes";
    }

    private void onEntryCompleted()
    {

    }
}