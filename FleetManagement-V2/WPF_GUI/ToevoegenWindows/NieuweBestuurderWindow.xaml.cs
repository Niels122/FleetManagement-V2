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
            var rijbewijzen = Enum.GetValues(typeof(Rijbewijs)).Cast<Rijbewijs>().ToList().Distinct(); //combobox vullen met mogelijkheden
            cmbRijbewijs.ItemsSource = rijbewijzen;
        }
        private void FillVoertuigen()
        {
            var voertuigen = _dc.GeefVoertuigen();
            var beschikbareVoertuigenNummerplaat = voertuigen.Where(v => v.BestuurderId == null).Select(v => v.Nummerplaat);

            cmbNummerplaat.ItemsSource = beschikbareVoertuigenNummerplaat;
        }
        private void FillTankkaarten()
        {
            var tankkaarten = _dc.GeefTankkaarten();
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


                #region Adres
                string _Straatnaam = tbStraatNaam.Text;
                string _Huisnummer = tbHuisnummer.Text;
                int _Postcode = int.Parse(tbPostcode.Text);
                string _Stad = tbStad.Text;

                _dc.CreateAdres(_Straatnaam, _Huisnummer, _Postcode, _Stad);
                #endregion
                //object maken van bestuurder, alles meegeven
                //(naam, voornaam, geboortedatum, rijksregisternummer, rijbewijstype, voertuigId, tankkaartId, adressId)
                //adres apart object => id van adres gelijk aan adresid in bestuurder, ook voor tankaart en voertuig

                //adres moet worden toegevoegd aan database
                //voertuigId gelijk zetten aan id van het voertuig met geselecteerde nummerplaat.
                Adres laatsteAdres = _dc.GeefAdressen().Last();
                int? _AdresId = laatsteAdres.AdresId;
                string? _ChassisnummerVoertuig = null;
                string? _Tankkaartnummer = null;

               

                
   

                Bestuurder nieuweBestuurder = new(_ID, _Voornaam, _Achternaam, _Geboortedatum, _Rijksregisternummer, _Rijbewijs, _ChassisnummerVoertuig, _Tankkaartnummer, _AdresId );

                _dc.CreateBestuurder(nieuweBestuurder);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
        private void createAdres()
        {
            //straat,huisnummer,postcode,stad
            //Moet nog in persistentie geïmplementeerd wordern
        }
    }
}
