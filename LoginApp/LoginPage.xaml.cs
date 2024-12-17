using LoginApp.Models;
using LoginApp.Repository;

namespace LoginApp;

public partial class LoginPage : ContentPage
{
	readonly IUserRepository userServer = new UserService();
	public LoginPage()
	{
		InitializeComponent();
	}

	private async void Login_Btn_Clicked(object sender, EventArgs e)
	{
		try
		{
            string email = Entry_Email.Text;
            string password = Entry_Password.Text;
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                await Shell.Current.DisplayAlert("Error", "All fields required", "Ok");
                return;
            }

            User user = await userServer.Login(email, password);
            if (user == null)
            {
                await DisplayAlert("Error", "Credentials are incorrect", "Ok");
                return;
            }
            await Navigation.PushAsync(new MainPage());
            await DisplayAlert("Login", "Successfully logged in", "Ok");
        }
        catch(Exception ex)
        {
            await DisplayAlert("Login", ex.Message, "Ok");
        }
	}
}