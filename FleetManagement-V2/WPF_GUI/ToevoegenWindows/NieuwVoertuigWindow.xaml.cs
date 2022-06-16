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
    /// Interaction logic for NieuwVoertuigWindow.xaml
    /// </summary>
    public partial class NieuwVoertuigWindow : Window
    {
        private Dictionary<string, List<string>> _voertuigMerkEnModel;
        private DomeinController _dc;
        public NieuwVoertuigWindow(DomeinController dc)
        {
            _dc = dc;
            InitializeComponent();
            FillBrandstofType();
            FillWagenType();
            FillKleur();
            FillAantalDeuren();
            FillMerkEnModel();
        }
        private void FillMerkEnModel()
        {

            List<string> MercedesModellen = new List<string>();
            MercedesModellen.Add("CLA coupé");
            MercedesModellen.Add("AMT-GTR");
            _voertuigMerkEnModel.Add("Mercedes", MercedesModellen);
        }
        private void FillBrandstofType()
        {
            var brandstoftypes = Enum.GetValues(typeof(Brandstoftype)).Cast<Brandstoftype>().ToList().Distinct();
            cmbBrandstoftype.ItemsSource = brandstoftypes;
        }
        private void FillWagenType()
        {
            var wagentypes = Enum.GetValues(typeof(Wagentype)).Cast<Wagentype>().ToList().Distinct();
            cmbWagentype.ItemsSource = wagentypes;
        }
        private void FillKleur()
        {
            string[] kleuren = { "Zwart", "Wit", "Groen", "Blauw", "Geel" };
            cmbKleur.ItemsSource = kleuren;

        }
        private void FillAantalDeuren()
        {
            int[] aantalDeuren = { 3, 5 };
            cmbAantalDeuren.ItemsSource = aantalDeuren;

        }

        private void btnOpslaan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string _Merk = tbMerk.Text;
                string _Model = tbModel.Text;
                string _Chassisnummer = tbChassisnummer.Text;
                string _Nummerplaat = tbNummerplaat.Text;
                Brandstoftype _Brandstoftype;
                if (cmbBrandstoftype.SelectedIndex == -1)
                {
                    throw new VoertuigException("Brandstoftype moet ingevuld zijn");
                }
                else
                {
                    _Brandstoftype = (Brandstoftype)cmbBrandstoftype.SelectedItem;
                }

                Wagentype _Wagentype;
                if (cmbWagentype.SelectedIndex == -1)
                {
                    throw new VoertuigException("Wagentype moet ingevuld zijn");
                }
                else
                {
                    _Wagentype = (Wagentype)cmbWagentype.SelectedItem;
                }

                string _Kleur;
                if (cmbKleur.SelectedItem != null)
                {
                    _Kleur = cmbKleur.Text;

                }
                else
                {
                    _Kleur = null;
                }
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


                _dc.CreateVoertuig(nieuwVoertuig);
                MessageBox.Show($"Nieuw voertuig met chassisnummer: {_Chassisnummer} is succesvol toegevoegd.", "Succes", MessageBoxButton.OK);
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
