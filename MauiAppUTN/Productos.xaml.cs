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
        if (string.IsNullOrWhiteSpace(txtNombreProducto.Text) ||
            string.IsNullOrWhiteSpace(txtExistencia.Text) ||
            string.IsNullOrWhiteSpace(txtPrecioUnitario.Text) ||
            string.IsNullOrWhiteSpace(txtIVA.Text) ||
            string.IsNullOrWhiteSpace(txtClasificacionID.Text))
        {
            DisplayAlert("Error", "Campos incompletos, por favor complete todos los campos.", "OK");
            return;
        }
        var prod = API.Crud<Producto>.Create(ApiUrlProd, new Producto
        {
            Id = 0,
            Nombre = txtNombreProducto.Text,
            Existencia = double.Parse(txtExistencia.Text),
            Precio_Unitario = double.Parse(txtPrecioUnitario.Text),
            IVA = double.Parse(txtIVA.Text),
            ClasificacionId = int.Parse(txtClasificacionID.Text)
        });
        if (prod != null)
        {
            DisplayAlert("�xito", "Producto Creado con exito", "OK");
            txtIdProducto.Text = prod.Id.ToString();
        }
    }
    private void cmdLeerProd_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtIdProducto.Text))
        {
            DisplayAlert("Error", "Ingrese el ID del producto que desea buscar.", "OK");
            return;
        }
        var (prod, found) = API.Crud<Producto>.Read_ById(ApiUrlProd, int.Parse(txtIdProducto.Text));
        if (found)
        {
            txtIdProducto.Text = prod.Id.ToString();
            txtNombreProducto.Text = prod.Nombre.ToString();
            txtExistencia.Text = prod.Existencia.ToString();
            txtPrecioUnitario.Text = prod.Precio_Unitario.ToString();
            txtIVA.Text = prod.IVA.ToString();
            txtClasificacionID.Text = prod.ClasificacionId.ToString();
            DisplayAlert("�xito", "Producto le�do con �xito.", "OK");
        }
        else
        {
            DisplayAlert("Error", "No existe el producto", "OK");
        }
    }


    private void cmdUpdateProd_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtIdProducto.Text) ||
            string.IsNullOrWhiteSpace(txtNombreProducto.Text) ||
            string.IsNullOrWhiteSpace(txtExistencia.Text) ||
            string.IsNullOrWhiteSpace(txtPrecioUnitario.Text) ||
            string.IsNullOrWhiteSpace(txtIVA.Text) ||
            string.IsNullOrWhiteSpace(txtClasificacionID.Text))
        {
            DisplayAlert("Error", "Campos incompletos, por favor complete todos los campos.", "OK");
            return;
        }
        bool success = API.Crud<Producto>.Update(ApiUrlProd, int.Parse(txtIdProducto.Text), new Producto
        {
            Id = int.Parse(txtIdProducto.Text),
            Nombre = txtNombreProducto.Text,
            Existencia = double.Parse(txtExistencia.Text),
            Precio_Unitario = double.Parse(txtPrecioUnitario.Text),
            IVA = double.Parse(txtIVA.Text),
            ClasificacionId = int.Parse(txtClasificacionID.Text)
        });
        if (!success)
        {
            DisplayAlert("Error", "Actualizaci�n fallida. El producto no existe.", "OK");
        }
        else
        {
            DisplayAlert("�xito", "Producto actualizado correctamente.", "OK");
        }
    }

    private void cmdDeleteProd_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtClasificacionID.Text))
        {
            DisplayAlert("Error", "Ingrese el ID del producto que desea eliminar.", "OK");
            return;
        }
        bool success = API.Crud<Producto>.Delete(ApiUrlProd, int.Parse(txtIdProducto.Text));
        if (!success)
        {
            DisplayAlert("Error", "Producto no encontrado para eliminar.", "OK");
        }
        else
        {
            DisplayAlert("�xito", "Producto eliminado correctamente.", "OK");
            txtIdProducto.Text = "";
            txtNombreProducto.Text = "";
            txtExistencia.Text = "";
            txtPrecioUnitario.Text = "";
            txtIVA.Text = "";
            txtClasificacionID.Text = "";
        }
    }

    // Manejador de evento para el bot�n de regresar
    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Menu());
    }

    // Manejador de evento para el bot�n de ir a otra p�gina
    private async void OnNextPageButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Clasificaciones());
    }
}