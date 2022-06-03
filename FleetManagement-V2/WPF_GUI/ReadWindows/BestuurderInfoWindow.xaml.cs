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
    /// Interaction logic for BestuurderInfoWindow.xaml
    /// </summary>
    public partial class BestuurderInfoWindow : Window
    {
        private Bestuurder _bestuurder;
        private DomeinController _dc;
        public BestuurderInfoWindow(DomeinController dc, Bestuurder bestuurder)
        {
            _bestuurder = bestuurder;
            _dc = dc;
            InitializeComponent();

            var adressen = _dc.GeefAdressen();
            var voertuigen = _dc.GeefVoertuigen();
            var tankkaarten = _dc.GeefTankkaarten();
            Adres? adrs = adressen.Where(a => a.AdresId == bestuurder.AdresId).FirstOrDefault();
            Voertuig? vrtg = voertuigen.Where(v => v.VoertuigId == bestuurder.VoertuigId).FirstOrDefault();
            Tankkaart? tnkrt = tankkaarten.Where(t => t.TankkaartId == bestuurder.TankkaartId).FirstOrDefault();

            naam.Text = bestuurder.Voornaam;
            achternaam.Text = bestuurder.Naam;
            geboortedatum.Text = bestuurder.Geboortedatum.ToString();
            rijksregisternummer.Text = bestuurder.Rijksregisternummer;
            rijbewijs.Text = bestuurder.Rijbewijs.ToString();  
            voertuig.Text = vrtg?.Nummerplaat.ToString();
            tankkaart.Text = tnkrt?.Kaartnummer;
            straatnaam.Text = adrs?.Straat;
            huisnummer.Text = adrs?.Nummer;
            postcode.Text = adrs?.Postcode.ToString();
            stad.Text = adrs?.Stad.ToString();

        }
    }
}
