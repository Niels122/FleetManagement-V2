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

namespace WPF_GUI.ToevoegenWindows
{
    /// <summary>
    /// Interaction logic for NieuweBestuurderWindow.xaml
    /// </summary>
    public partial class NieuweBestuurderWindow : Window
    {
        private DomeinController _dc;
        public NieuweBestuurderWindow(DomeinController dc)
        {
            InitializeComponent();
            _dc = dc;
            FillRijbewijzen();
            FillVoertuigen();
            FillTankkaarten();
        }

        private void FillRijbewijzen()
        {

            Array rijbewijzen = Enum.GetValues(typeof(Rijbewijs));
            cmbRijbewijs.ItemsSource = rijbewijzen;
            cmbRijbewijs.SelectedIndex = 0;
        }
        private void FillVoertuigen()
        {
            var voertuigen = _dc.GeefVoertuigenMetBestuurderId();
            var beschikbareVoertuigenNummerplaat = voertuigen.Where(v => v.BestuurderId == null).Select(v => v.Nummerplaat);

            cmbNummerplaat.ItemsSource = beschikbareVoertuigenNummerplaat;
        }
        private void FillTankkaarten()
        {
            var tankkaarten = _dc.GeefTankkaartenMetBestuurderId();
            var beschikbareTankkaarten = tankkaarten.Where(t => t.BestuurderId == null).Select(t => t.Kaartnummer);

            cmbTankkaart.ItemsSource = beschikbareTankkaarten;

        }

        private void btnOpslaan_Click(object sender, RoutedEventArgs e)
        {
            CreateBestuurder();
        }
        private void CreateBestuurder()
        {
            try
            {
                string _ID = tbBestuurderID.Text;
                string _Voornaam = tbVoornaam.Text;
                string _Achternaam = tbAchternaam.Text;
                DateTime _Geboortedatum = dpGeboortedatum.SelectedDate.Value;
                string _Rijksregisternummer = tbRijksregisternummer.Text;
                Rijbewijs _Rijbewijs = (Rijbewijs)cmbRijbewijs.SelectedItem;
                
                int? _AdresId = null;
                string? _ChassisnummerVoertuig = null;
                string? _Tankkaartnummer = null;

                #region Tankkaart
                string selectedTankkaart = cmbTankkaart.Text;
                string tankkaartnummer = _dc.GeefTankkaarten().Where(t => t.Kaartnummer == selectedTankkaart).Select(t => t.Kaartnummer).FirstOrDefault();
                if(tankkaartnummer != null)
                {
                    _Tankkaartnummer = tankkaartnummer;
                }
                #endregion

                #region Voertuig
                string selectedNummerplaat = cmbNummerplaat.Text;
                string chassisnummer = _dc.GeefVoertuigen().Where(v => v.Nummerplaat == selectedNummerplaat).Select(v => v.Chassisnummer).FirstOrDefault();
                if (chassisnummer != null)
                {
                    _ChassisnummerVoertuig = chassisnummer.Trim();
                }
                #endregion

                #region Adres 
                string _Straatnaam = tbStraatNaam.Text; ; //als niet is ingevuld geen adresID meegeven
                    string _Huisnummer = tbHuisnummer.Text;
                    int? _Postcode = int.Parse(tbPostcode.Text);
                    string _Stad = tbStad.Text;
                if (_Straatnaam.Length != 0 && _Huisnummer.Length != 0 && _Stad.Length != 0)
                {
                    if (_Postcode < 1000 || _Postcode > 9999)
                    {
                        throw new AdresException("Postcode is ongdeldig.");
                    }
                    _dc.CreateAdres(_Straatnaam, _Huisnummer, (int)_Postcode, _Stad);
                    Adres laatsteAdres = _dc.GeefAdressen().Last(); //een tweede methode is om de laatste uit de lijst te selecteren
                    _AdresId = laatsteAdres.AdresId;
                }
                else
                {
                    throw new AdresException("Niet alle velden zijn ingevuld");
                }

                //Adres nieuwAdres = _dc.GetNewAdress(_Straatnaam, _Huisnummer, _Postcode, _Stad); //TODO: nieuw adress aanmaken en dit adres terug geven, nu heeft het ook een ID
                //en dit kan dus aan een bestuurder gekoppeld worden
                #endregion
                //object maken van bestuurder, alles meegeven
                //(naam, voornaam, geboortedatum, rijksregisternummer, rijbewijstype, voertuigId, tankkaartId, adressId)
                //adres apart object => id van adres gelijk aan adresid in bestuurder, ook voor tankaart en voertuig

                //adres moet worden toegevoegd aan database
                //voertuigId gelijk zetten aan id van het voertuig met geselecteerde nummerplaat.






                Bestuurder nieuweBestuurder = new(_ID, _Voornaam, _Achternaam, _Geboortedatum, _Rijksregisternummer, _Rijbewijs, _ChassisnummerVoertuig, _Tankkaartnummer, _AdresId);

                _dc.CreateBestuurder(nieuweBestuurder);

                MessageBox.Show($"Bestuurder met id {_ID} is succesvol toegevoegd");
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void btnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
