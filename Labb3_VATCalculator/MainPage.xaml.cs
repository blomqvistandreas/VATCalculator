using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Labb3_VATCalculator
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Button1.Clicked += OnButtonClick;
            Button2.Clicked += OnButtonClick;
            Button3.Clicked += OnButtonClick;
        }

        public void Calculate(double vat, double price)
        {
            double formula = 1 / (vat / 100 + 1);
            double calcPrice = formula * price;
            double calcVat = price - calcPrice;

            priceLabel.Text = price.ToString("0.00") + " Sek";
            vatLabel.Text = vat.ToString("0.00") + " %";
            outputPriceLabel.Text = calcVat.ToString("0.00") + " Sek";
            outputVatLabel.Text = calcPrice.ToString("0.00") + " Sek";
        }

        public void OnButtonClick(object sender, EventArgs args)
        {
            double.TryParse(inputField.Text, out double price);
            string inputString = ((Button)sender).Text;
            inputString = inputString.Remove(inputString.Length - 1);
            double.TryParse(inputString, out double vat);

            Calculate(price, vat);
        }
    }
}