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
    /// Interaction logic for VoertuigUpdateWindow.xaml
    /// </summary>
    public partial class VoertuigUpdateWindow : Window
    {
        private DomeinController _dc;
        private Voertuig _voertuig;
        public VoertuigUpdateWindow(Voertuig voertuig, DomeinController dc)
        {
            InitializeComponent();

            _dc = dc;
            this._voertuig = voertuig;

            tbChassisnummer.Text = voertuig.Chassisnummer;
            tbNummerplaat.Text = voertuig.Nummerplaat;
            tbMerk.Text = voertuig.Merk;
            tbModel.Text = voertuig.Model;
            cmbWagentype.SelectedItem = voertuig.Wagentype;
            cmbAantalDeuren.SelectedItem = voertuig.AantalDeuren;
            cmbBrandstoftype.SelectedItem = voertuig.Brandstoftype;
            cmbKleur.SelectedItem = voertuig.Kleur;
            //bestuurder.Text = Bestuurder

            FillWagentype();
            FillBrandstoftype();
            FillDeuren();
            FillKleur();
        }

        private void FillKleur()
        {
            string[] kleuren = { "Zwart", "Wit", "Groen", "Blauw", "Geel" };
            cmbKleur.ItemsSource = kleuren;
        }

        private void FillDeuren()
        {
            //var aantalDeuren = Enum.GetValues(typeof(Deuren)).Cast<Deuren>().ToList().Distinct();
            string[] aantalDeuren = { "3", "5" };
            cmbAantalDeuren.ItemsSource = aantalDeuren;
        }

        private void FillBrandstoftype()
        {
            var brandstoftypes = Enum.GetValues(typeof(Brandstoftype)).Cast<Brandstoftype>().ToList().Distinct();
            cmbBrandstoftype.ItemsSource = brandstoftypes;
        }

        private void FillWagentype()
        {
            var wagentypes = Enum.GetValues(typeof(Wagentype)).Cast<Wagentype>().ToList().Distinct();
            cmbWagentype.ItemsSource = wagentypes;
        }

        private void btnOpslaan_Click(object sender, RoutedEventArgs e)
        {
            UpdateVoertuig();
        }

        private void btnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UpdateVoertuig()
        {
            string _Merk = tbMerk.Text;
            string _Model = tbModel.Text;
            string _Chassisnummer = tbChassisnummer.Text;
            string _Nummerplaat = tbNummerplaat.Text;
            Brandstoftype _Brandstoftype = (Brandstoftype)cmbBrandstoftype.SelectedItem;
            Wagentype _Wagentype = (Wagentype)cmbWagentype.SelectedItem;
            string _Kleur = cmbKleur.Text;
            int? _Deuren;

            if (cmbAantalDeuren.SelectedItem != null)
            {
                _Deuren = int.Parse(cmbAantalDeuren.SelectedItem.ToString());
            }
            else
            {
                _Deuren = null;
            }

            Voertuig nieuwVoertuig = new(_Merk, _Model, _Chassisnummer, _Nummerplaat, _Brandstoftype, _Wagentype, _Kleur, _Deuren);

            try
            {
                _dc.CreateVoertuig(nieuwVoertuig);
                MessageBox.Show($"Voertuig met chassisnummer: {_Chassisnummer} is succesvol gewijzigd.", "Succes", MessageBoxButton.OK);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
