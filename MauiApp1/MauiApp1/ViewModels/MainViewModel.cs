using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;

namespace MauiApp1.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string producto1 = string.Empty;

        [ObservableProperty]
        private string producto2 = string.Empty;

        [ObservableProperty]
        private string producto3 = string.Empty;

        [ObservableProperty]
        private double subtotal;

        [ObservableProperty]
        private double descuento;

        [ObservableProperty]
        private double total;

        [RelayCommand]
        private async Task Calcular()
        {
            try
            {
                if (double.TryParse(producto1, out double p1) &&
                    double.TryParse(producto2, out double p2) &&
                    double.TryParse(producto3, out double p3))
                {
                    var compra = new Compra
                    {
                        Producto1 = p1,
                        Producto2 = p2,
                        Producto3 = p3
                    };

                    Subtotal = compra.Subtotal;
                    Descuento = compra.DescuentoPorcentaje * 100; // en %
                    Total = compra.Total;
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Por favor ingrese valores válidos.", "OK");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        [RelayCommand]
        private void Limpiar()
        {
            Producto1 = string.Empty;
            Producto2 = string.Empty;
            Producto3 = string.Empty;
            Subtotal = 0;
            Descuento = 0;
            Total = 0;
        }
    }
}