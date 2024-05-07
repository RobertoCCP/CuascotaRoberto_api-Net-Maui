using MauiAppUTN.Models;

namespace MauiAppUTN;

public partial class Productos : ContentPage
{
    private string ApiUrlProd = "https://appwebutn17.azurewebsites.net/api/Productos";
    public Productos()
	{
		InitializeComponent();
	}

    private void cmdCreateProd_Clicked(object sender, EventArgs e)
    {
        var prod = API.Crud<Producto>.Create(ApiUrlProd, new Producto
        {
            Id = 0,
            Nombre = txtNombreProducto.Text,
            Existencia = double.Parse(txtExistencia.Text),
            PrecioUnitario = double.Parse(txtPrecioUnitario.Text),
            IVA = double.Parse(txtIVA.Text),
            ClasificacionId = int.Parse(txtClasificacionID.Text)
        });
        if (prod != null)
        {
            txtIdProducto.Text = prod.Id.ToString();
        }
    }
    private void cmdLeerProd_Clicked(object sender, EventArgs e)
    {
        var prod = API.Crud<Producto>.Read_ById(ApiUrlProd, int.Parse(txtIdProducto.Text));
        if (prod != null)
        {
            txtIdProducto.Text = prod.Id.ToString();
            txtNombreProducto.Text = prod.Nombre.ToString();
            txtExistencia.Text = prod.Existencia.ToString();
            txtPrecioUnitario.Text = prod.PrecioUnitario.ToString();
            txtIVA.Text = prod.IVA.ToString();
            txtClasificacionID.Text = prod.ClasificacionId.ToString();
        }
    }

    private void cmdUpdateProd_Clicked(object sender, EventArgs e)
    {
        API.Crud<Producto>.Update(ApiUrlProd, int.Parse(txtIdProducto.Text), new Producto
        {
            Id = int.Parse(txtIdProducto.Text),
            Nombre = txtNombreProducto.Text,
            Existencia = double.Parse(txtExistencia.Text),
            PrecioUnitario = double.Parse(txtPrecioUnitario.Text),
            IVA = double.Parse(txtIVA.Text),
            ClasificacionId = int.Parse(txtClasificacionID.Text)
        });
    }

    private void cmdDeleteProd_Clicked(object sender, EventArgs e)
    {
        API.Crud<Producto>.Delete(ApiUrlProd, int.Parse(txtIdProducto.Text));
        txtIdProducto.Text = "";
        txtNombreProducto.Text = "";
        txtExistencia.Text = "";
        txtPrecioUnitario.Text = "";
        txtIVA.Text = "";
        txtClasificacionID.Text = "";
    }

    // Manejador de evento para el botón de regresar
    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Menu());
    }

    // Manejador de evento para el botón de ir a otra página
    private async void OnNextPageButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Clasificaciones());
    }
}