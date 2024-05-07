namespace MauiAppUTN;

public partial class Menu : ContentPage
{
	public Menu()
	{
		InitializeComponent();
	}


    private void cmdNext1_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Clasificaciones());
    }

    private void cmdNext2_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Productos());
    }

    private void cmdLogout_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Login());
    }
}