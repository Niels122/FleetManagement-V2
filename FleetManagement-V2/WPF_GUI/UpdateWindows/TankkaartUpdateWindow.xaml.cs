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
    /// Interaction logic for TankkaartUpdateWindow.xaml
    /// </summary>
    public partial class TankkaartUpdateWindow : Window
    {
        private DomeinController _dc;
        public TankkaartUpdateWindow(DomeinController dc, Tankkaart tankkaart)
        {
            _dc = dc;
            InitializeComponent();
            FillBrandstofType();

            tbKaartnummer.Text = tankkaart.Kaartnummer;
            dpGeldigheidsdatum.SelectedDate = tankkaart.Geldigheidsdatum;
            cbGeblokkeerd.IsChecked = tankkaart.Geblokkeerd;
            tbPincode.Text = tankkaart.Pincode.ToString();
            cmbBrandstoftype.SelectedItem = tankkaart.Brandstof;

        }
        private void FillBrandstofType()
        {
            List<Brandstoftype?> brandstoftypes = new List<Brandstoftype?> { null, Brandstoftype.Benzine, Brandstoftype.Diesel };
            cmbBrandstoftype.ItemsSource = brandstoftypes;
        }

        private void btnOpslaan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var kaartnummer = tbKaartnummer.Text;

                var geldigheidsdatum = dpGeldigheidsdatum.SelectedDate.Value;
                bool isGeblokkeerd = false;
                if (cbGeblokkeerd.IsChecked == true)
                {
                    isGeblokkeerd = true;
                }
                else
                {
                    isGeblokkeerd = false;
                }

                Brandstoftype? brandstoftype = (Brandstoftype?)cmbBrandstoftype.SelectedItem; //https://stackoverflow.com/questions/6139429/how-to-retrieve-combobox-selected-value-as-enum-type

                int? pincode;
                if (int.TryParse(tbPincode.Text, out int i))
                {
                    pincode = i;
                }
                else
                {
                    pincode = null;
                }

                Tankkaart gewijzigdeTankkaart = new(kaartnummer, geldigheidsdatum, isGeblokkeerd, pincode, brandstoftype);

                try
                {
                    _dc.UpdateTankkaart(gewijzigdeTankkaart);
                    MessageBox.Show($"Tankkaart met kaartnummer: {kaartnummer} is succesvol gewijzigd.", "Succes", MessageBoxButton.OK);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch(Exception ex)
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
