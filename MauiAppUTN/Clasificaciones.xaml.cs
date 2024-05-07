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
        if (string.IsNullOrWhiteSpace(txtClasificacion.Text))
        {
            DisplayAlert("Error", "Por favor complete todos los campos.", "OK");
            return;
        }

        var resultado = API.Crud<Clasificacion>.Create(ApiUrl, new Clasificacion
        {
            Id = 0,
            Publicacion = txtClasificacion.Text
        });

        if (resultado != null)
        {
            DisplayAlert("Éxito", "Clasificación creada con éxito.", "OK");
            txtId.Text = resultado.Id.ToString();
        }
    }

    private void cmdLeer_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtId.Text))
        {
            DisplayAlert("Error", "Ingrese el ID de la clasificación que desea buscar.", "OK");
            return;
        }

        var (resultado, found) = API.Crud<Clasificacion>.Read_ById(ApiUrl, int.Parse(txtId.Text));
        if (found)
        {
            txtId.Text = resultado.Id.ToString();
            txtClasificacion.Text = resultado.Publicacion;
            DisplayAlert("Éxito", "Clasificación leída con éxito.", "OK");
        }
        else
        {
            DisplayAlert("Error", "No existe la clasificación", "OK");
        }
    }


    private void cmdUpdate_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtId.Text) ||
            string.IsNullOrWhiteSpace(txtClasificacion.Text))
        {
            DisplayAlert("Error", "Campos incompletos, por favor complete todos los campos.", "OK");
            return;
        }

        bool success = API.Crud<Clasificacion>.Update(ApiUrl, int.Parse(txtId.Text), new Clasificacion
        {
            Id = int.Parse(txtId.Text),
            Publicacion = txtClasificacion.Text
        });

        if (!success)
        {
            DisplayAlert("Error", "Actualización fallida. La clasificación no existe.", "OK");
        }
        else
        {
            DisplayAlert("Éxito", "Clasificación actualizada correctamente.", "OK");
        }
    }

    private void cmdDelete_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtId.Text))
        {
            DisplayAlert("Error", "Ingrese el ID de la clasificación que desea eliminar.", "OK");
            return;
        }

        bool success = API.Crud<Clasificacion>.Delete(ApiUrl, int.Parse(txtId.Text));
        if (!success)
        {
            DisplayAlert("Error", "Clasificación no encontrada para eliminar.", "OK");
        }
        else
        {
            DisplayAlert("Éxito", "Clasificación eliminada correctamente.", "OK");
            txtId.Text = "";
            txtClasificacion.Text = "";
        }
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