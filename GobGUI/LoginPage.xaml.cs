using GobGUI.WinUI;
using System.Diagnostics;

namespace GobGUI
{

    public partial class LoginPage : ContentPage
    {
        private readonly App _app;
        public LoginPage(App app)
        {
            InitializeComponent();
            _app = app;
        }

        private void LogInBtn_Clicked(object sender, EventArgs e)
        {
            _app.GoToMainPage();
        }

        private void onEntryCompleted()
        {

        }
    }
}