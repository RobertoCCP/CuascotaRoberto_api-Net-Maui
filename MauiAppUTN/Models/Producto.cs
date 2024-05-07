using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppUTN.Models
{
    internal class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Existencia { get; set; }
        public double PrecioUnitario { get; set; }
        public double IVA { get; set; }
        public int ClasificacionId { get; set; }
    }
}
