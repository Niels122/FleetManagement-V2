using Domein;
using Domein.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_GUI.ReadWindows
{
    /// <summary>
    /// Interaction logic for TankkaartInfoWindow.xaml
    /// </summary>
    public partial class TankkaartInfoWindow : Window
    {
        private DomeinController _dc;
        public TankkaartInfoWindow(DomeinController dc, Tankkaart tankkaart)
        {
            _dc = dc;
            InitializeComponent();

            var bestuurders = _dc.GeefBestuurders();
            Bestuurder? bstrdr = bestuurders.Where(b => b.TankkaartNummer == tankkaart.Kaartnummer).FirstOrDefault();

          
            kaartnummer.Text = tankkaart.Kaartnummer.ToString();
            geldigheidsdatum.Text = tankkaart.Geldigheidsdatum.ToString();
            geblokkeerd.IsChecked = tankkaart.Geblokkeerd;
            brandstoftype.Text = tankkaart.Brandstof.ToString();
            pincode.Text = tankkaart.Pincode.ToString();
            bestuurder.Text = $"ID: {bstrdr?.BestuurderId}  Naam: {bstrdr?.Voornaam} {bstrdr?.Naam}";
        }
    }
}
