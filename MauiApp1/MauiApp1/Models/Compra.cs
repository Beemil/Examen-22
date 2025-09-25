using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class Compra
    {
        public double Producto1 { get; set; }
        public double Producto2 { get; set; }
        public double Producto3 { get; set; }
        public double Subtotal => Producto1 + Producto2 + Producto3;
        public double DescuentoPorcentaje
        {
            get
            {
                if (Subtotal >= 1000 && Subtotal <= 4999.99)
                    return 0.10;
                else if (Subtotal >= 5000 && Subtotal <= 9999.99)
                    return 0.20;
                else if (Subtotal >= 10000 && Subtotal <= 19999.99)
                    return 0.30;
                else
                    return 0;
            }
        }
        public double Total => Subtotal - (Subtotal * DescuentoPorcentaje);
    }
}
