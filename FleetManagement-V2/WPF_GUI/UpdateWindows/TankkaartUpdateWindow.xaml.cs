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

            kaartnummer.Text = tankkaart.Kaartnummer;
            geldigheidsdatum.SelectedDate = tankkaart.Geldigheidsdatum;
            geblokkeerd.IsChecked = tankkaart.Geblokkeerd;
            pincode.Text = tankkaart.Pincode.ToString();
            brandstofType.SelectedItem = tankkaart.Brandstof;

        }
        private void FillBrandstofType()
        {
            var brandstoftypes = Enum.GetValues(typeof(Brandstoftype)).Cast<Brandstoftype>().ToList().Distinct();
            brandstofType.ItemsSource = brandstoftypes;
        }

        private void btnOpslaan_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAnnuleren_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
