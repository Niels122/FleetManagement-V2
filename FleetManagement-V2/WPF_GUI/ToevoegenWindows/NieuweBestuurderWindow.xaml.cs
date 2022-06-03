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


                DateTime geboortedatum = dpGeboortedatum.SelectedDate.Value;
                //object maken van bestuurder, alles meegeven
                //(naam, voornaam, geboortedatum, rijksregisternummer, rijbewijstype, voertuigId, tankkaartId, adressId)
                //adres apart object => id van adres gelijk aan adresid in bestuurder, ook voor tankaart en voertuig
                createAdres(); //adres moet worden toegevoegd aan database
                //voertuigId gelijk zetten aan id van het voertuig met geselecteerde nummerplaat.
                int? adresId = null;
                int? voertuigId = null;
                int? tankkaartId = null;


                Rijbewijs _rijbewijs;
                string rijbewijs = cmbRijbewijs.Text;

                switch (rijbewijs.ToUpper())
                {
                    case "A":
                        _rijbewijs = Rijbewijs.A;
                        break;

                    case "B":
                        _rijbewijs = Rijbewijs.B;
                        break;

                    case "C":
                        _rijbewijs = Rijbewijs.C;
                        break;

                    case "D":
                        _rijbewijs = Rijbewijs.D;
                        break;

                    default:
                        _rijbewijs = Rijbewijs.B;
                        break;
                }
   

                Bestuurder bestuurder = new(0, tbNaam.Text, tbAchternaam.Text, geboortedatum, tbRijksregisternummer.Text, _rijbewijs, adresId, voertuigId, tankkaartId);

                _dc.CreateBestuurder(bestuurder);

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
