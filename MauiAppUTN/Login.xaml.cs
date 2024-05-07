using MauiAppUTN.Models;

namespace MauiAppUTN;

public partial class Login : ContentPage
{
    private string ApiUrl = "https://utninicioapi.azurewebsites.net/api/Usuarios";
    public Login()
	{
		InitializeComponent();
	}

    private void cmdLogin_Clicked(object sender, EventArgs e)
    {
        var nombre = txtUsername.Text;
        var contrasena = txtPassword.Text;

        if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(contrasena))
        {
            DisplayAlert("Error", "Por favor ingrese nombre y contraseña.", "OK");
            return;
        }

        var credenciales = API.Crud<Logeo>.LeerCredenciales(ApiUrl);

        if (credenciales != null && credenciales.Any(c => c.nombre == nombre && c.contrasena == contrasena))
        {
            DisplayAlert("Éxito", "Inicio de sesión exitoso", "OK");
            Navigation.PushAsync(new Menu());
        }
        else
        {
            DisplayAlert("Error", "Credenciales incorrectas", "OK");
        }
    }
}