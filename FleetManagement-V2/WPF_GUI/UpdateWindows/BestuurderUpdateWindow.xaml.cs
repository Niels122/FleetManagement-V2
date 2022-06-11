using Domein;
using Domein.Enums;
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

namespace WPF_GUI.UpdateWindows
{
    /// <summary>
    /// Interaction logic for BestuurderUpdateWindow.xaml
    /// </summary>
    public partial class BestuurderUpdateWindow : Window
    {
        private Bestuurder _bestuurder;
        private DomeinController _dc;
        public BestuurderUpdateWindow(DomeinController dc, Bestuurder bestuurder)
        {
            _dc = dc;
            _bestuurder = bestuurder;
            InitializeComponent();

            var adressen = _dc.GeefAdressen();
            var voertuigen = _dc.GeefVoertuigen();
            var tankkaarten = _dc.GeefTankkaarten();
            Adres? adrs = adressen.Where(a => a.AdresId == bestuurder.AdresId).FirstOrDefault();
            Voertuig? vrtg = voertuigen.Where(v => v.Chassisnummer == bestuurder.ChassisnummerVoertuig).FirstOrDefault();
            Tankkaart? tnkrt = tankkaarten.Where(t => t.Kaartnummer == bestuurder.TankkaartNummer).FirstOrDefault();

            naam.Text = bestuurder.Voornaam;
            achternaam.Text = bestuurder.Naam;
            geboortedatum.Text = bestuurder.Geboortedatum.ToString();
            rijksregisternummer.Text = bestuurder.Rijksregisternummer;
            cmbRijbewijs.SelectedItem = bestuurder.Rijbewijs;
            cmbVoertuig.SelectedItem = vrtg?.Nummerplaat;
            cmbTankkaart.SelectedItem = tnkrt?.Kaartnummer;
            straatnaam.Text = adrs?.Straat;
            huisnummer.Text = adrs?.Nummer;
            postcode.Text = adrs?.Postcode.ToString();
            stad.Text = adrs?.Stad.ToString();

            FillRijbewijzen();
            FillVoertuigen();
            FillTankkaarten();
        }

        private void btnOpslaan_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show($"Bent u zeker dat u wijzigingen wilt aanbrengen?", "Zeker?", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            
            if(result == MessageBoxResult.Yes)
            {

                UpdateBestuurder();
            }
            else
            {
                MessageBox.Show($"Geen wijzigingen aangebracht", "Annuleren", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
        }

        private void btnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Geen wijzigingen aangebracht", "Annuleren", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            this.Close();
        }

        private void UpdateBestuurder()
        {
            _dc.UpdateBestuurder(_bestuurder);
            MessageBox.Show($"Wijzigingen zijn aangebracht", "Voltooid", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            this.Close();
        }

        private void FillRijbewijzen()
        {
            var rijbewijzen = Enum.GetValues(typeof(Rijbewijs)).Cast<Rijbewijs>().ToList().Distinct(); //combobox vullen met mogelijkheden
            cmbRijbewijs.ItemsSource = rijbewijzen;
        }
        private void FillVoertuigen()
        {
            var voertuigen = _dc.GeefVoertuigen();
            var beschikbareVoertuigenNummerplaat = voertuigen.Where(v => v.BestuurderId == null).Select(v => v.Nummerplaat);

            cmbVoertuig.ItemsSource = beschikbareVoertuigenNummerplaat;
        }
        private void FillTankkaarten()
        {
            var tankkaarten = _dc.GeefTankkaarten();
            var beschikbareTankkaarten = tankkaarten.Where(t => t.BestuurderId == null).Select(t => t.Kaartnummer);

            cmbTankkaart.ItemsSource = beschikbareTankkaarten;

        }
    }
}
