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
    /// Interaction logic for NieuweTankkaartWindow.xaml
    /// </summary>
    public partial class NieuweTankkaartWindow : Window
    {
        private DomeinController _dc;
        public NieuweTankkaartWindow(DomeinController dc)
        {
            InitializeComponent();
            _dc = dc;

            FillBrandstofType();
        }
        private void FillBrandstofType()
        {
            var brandstoftypes = Enum.GetValues(typeof(Brandstoftype)).Cast<Brandstoftype>().ToList().Distinct();
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


                Brandstoftype brandstoftype = (Brandstoftype)cmbBrandstoftype.SelectedItem; //https://stackoverflow.com/questions/6139429/how-to-retrieve-combobox-selected-value-as-enum-type


                Int32.TryParse(tbPincode.Text, out int pincode);

                Tankkaart nieuweTankkaart = new(kaartnummer, geldigheidsdatum, isGeblokkeerd, pincode, brandstoftype);



                _dc.CreateTankkaart(nieuweTankkaart);
                MessageBox.Show($"Nieuwe tankkaart met kaartnummer: {kaartnummer} is succesvol toegevoegd.", "Succes", MessageBoxButton.OK);
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
