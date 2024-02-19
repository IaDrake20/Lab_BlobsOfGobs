namespace GobGUI
{
    using Microsoft.Maui;
    using Microsoft.Maui.Controls;
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage(this);
        }


        public void GoToMainPage()
        {
            if (MainPage is NavigationPage navigationPage)
            {
                // If MainPage is already a NavigationPage, navigate to MainPage
                navigationPage.Navigation.PushAsync(new MainPage());
            }
            else
            {
                // If MainPage is not a NavigationPage, create a new NavigationPage
                MainPage = new NavigationPage(new MainPage());
            }
        }
        protected override Window CreateWindow(IActivationState activationState)
        {
            
            MainPage = new LoginPage(this);

            return new Window(MainPage);
        }

    }
}
