using MauiAppUTN.Models;

namespace MauiAppUTN;

public partial class Clasificaciones : ContentPage
{
    private string ApiUrl = "https://appwebutn17.azurewebsites.net/api/Clasificaciones";
    public Clasificaciones()
	{
		InitializeComponent();
	}

    private void cmdCreate_Clicked(object sender, EventArgs e)
    {
        var resultado = API.Crud<Clasificacion>.Create(ApiUrl, new Clasificacion
        {
            Id = 0,
            Publicacion = txtClasificacion.Text
        });

        if (resultado != null)
        {
            txtId.Text = resultado.Id.ToString();
        }
    }
    private void cmdLeer_Clicked(object sender, EventArgs e)
    {
        var resultado = API.Crud<Clasificacion>.Read_ById(ApiUrl, int.Parse(txtId.Text));
        txtId.Text = resultado.Id.ToString();
        txtClasificacion.Text = resultado.Publicacion;

    }
    private void cmdUpdate_Clicked(object sender, EventArgs e)
    {
        API.Crud<Clasificacion>.Update(ApiUrl, int.Parse(txtId.Text), new Clasificacion
        {
            Id = int.Parse(txtId.Text),
            Publicacion = txtClasificacion.Text
        });
    }
    private void cmdDelete_Clicked(object sender, EventArgs e)
    {
        API.Crud<Clasificacion>.Delete(ApiUrl, int.Parse(txtId.Text));
        txtId.Text = "";
        txtClasificacion.Text = "";
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Menu());
    }

    // Manejador de evento para el botón de ir a otra página
    private async void OnNextPageButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Productos());
    }
}