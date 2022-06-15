using Domein;
using Domein.Enums;
using Domein.Exceptions;
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
            geboortedatum.SelectedDate = bestuurder.Geboortedatum;
            rijksregisternummer.Text = bestuurder.Rijksregisternummer;
            cmbRijbewijs.SelectedItem = bestuurder.Rijbewijs;

            cmbNummerplaat.SelectedItem = vrtg?.Nummerplaat;

            cmbTankkaart.SelectedItem = tnkrt?.Kaartnummer;

            straatnaam.Text = adrs?.Straat;
            huisnummer.Text = adrs?.Nummer;
            postcode.Text = adrs?.Postcode.ToString();
            stad.Text = adrs?.Stad.ToString();

            FillRijbewijzen();
            FillVoertuigen(vrtg?.Nummerplaat);
            FillTankkaarten(tnkrt?.Kaartnummer);
        }

        private void btnOpslaan_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show($"Bent u zeker dat u wijzigingen wilt aanbrengen?", "Zeker?", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

            if (result == MessageBoxResult.Yes)
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
            try
            {

                string _BestuurderId = _bestuurder.BestuurderId;
                string _Voornaam = naam.Text;
                string _Achternaam = achternaam.Text;
                DateTime _Geboortedatum = geboortedatum.SelectedDate.Value;
                string _Rijksregisternummer = rijksregisternummer.Text;
                Rijbewijs _Rijbewijs = (Rijbewijs)cmbRijbewijs.SelectedItem;


                string? _Tankkaartnummer = null;
                string selectedTankkaart = cmbTankkaart.Text;
                string tankkaartnummer = _dc.GeefTankkaarten().Where(t => t.Kaartnummer == selectedTankkaart).Select(t => t.Kaartnummer).FirstOrDefault();
                if (tankkaartnummer != null)
                {
                    _Tankkaartnummer = tankkaartnummer;
                }

                string _ChassisnummerVoertuig = _bestuurder.ChassisnummerVoertuig;
                string selectedNummerplaat = cmbNummerplaat.Text;
                string chassisnummer = _dc.GeefVoertuigen().Where(v => v.Nummerplaat == selectedNummerplaat).Select(v => v.Chassisnummer).FirstOrDefault();
                if (chassisnummer != null)
                {
                    _ChassisnummerVoertuig = chassisnummer.Trim();
                }




                try
                {

                    int? _AdresId = _bestuurder.AdresId;
                    string _Straatnaam = straatnaam.Text;  //als niet is ingevuld geen adresID meegeven
                    string _Huisnummer = huisnummer.Text;
                    int? _Postcode = int.Parse(postcode.Text);
                    string _Stad = stad.Text;
                    if (_Straatnaam.Length != 0 && _Huisnummer.Length != 0 && _Stad.Length != 0)
                    {
                        if (_Postcode < 1000 || _Postcode > 9999)
                        {
                            throw new AdresException("Postcode is ongdeldig.");
                        }
                        if(_bestuurder.AdresId == null)
                        {
                            _dc.CreateAdres(_Straatnaam, _Huisnummer, (int)_Postcode, _Stad);
                            Adres laatsteAdres = _dc.GeefAdressen().Last();
                            _AdresId = laatsteAdres.AdresId;
                        }
                        
                        Adres updatedAdres = new((int)_AdresId, _Straatnaam, _Huisnummer, (int)_Postcode, _Stad);
                        _dc.UpdateAdres(updatedAdres);

                    }
                    else
                    {
                        throw new AdresException("Alle velden van adres moeten ingevuld worden");
                    }
                Bestuurder updatedBestuurder = new(_BestuurderId, _Voornaam, _Achternaam, _Geboortedatum, _Rijksregisternummer, _Rijbewijs, _ChassisnummerVoertuig, _Tankkaartnummer, _AdresId );
                _dc.UpdateBestuurder(updatedBestuurder);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


                MessageBox.Show($"Wijzigingen zijn aangebracht", "Voltooid", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillRijbewijzen()
        {
            var rijbewijzen = Enum.GetValues(typeof(Rijbewijs)).Cast<Rijbewijs>().ToList().Distinct(); //combobox vullen met mogelijkheden
            cmbRijbewijs.ItemsSource = rijbewijzen;
        }
        private void FillVoertuigen(string? huidigeNummerplaat = null)
        {
            var voertuigen = _dc.GeefVoertuigenMetBestuurderId();
            List<string> beschikbareVoertuigenNummerplaat = voertuigen.Where(v => v.BestuurderId == null).Select(v => v.Nummerplaat).ToList();
            beschikbareVoertuigenNummerplaat.Add(huidigeNummerplaat);
            cmbNummerplaat.ItemsSource = beschikbareVoertuigenNummerplaat;
        }
        private void FillTankkaarten(string? huidigeTankkaart = null)
        {
            var tankkaarten = _dc.GeefTankkaartenMetBestuurderId();
            List<string> beschikbareTankkaarten = tankkaarten.Where(t => t.BestuurderId == null).Select(t => t.Kaartnummer).ToList(); ;
            beschikbareTankkaarten.Add(huidigeTankkaart);
            cmbTankkaart.ItemsSource = beschikbareTankkaarten;

        }
    }
}
