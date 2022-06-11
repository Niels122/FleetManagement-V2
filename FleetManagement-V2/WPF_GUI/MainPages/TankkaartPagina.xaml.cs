using Domein;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_GUI.ReadWindows;
using WPF_GUI.ToevoegenWindows;
using WPF_GUI.UpdateWindows;

namespace WPF_GUI.MainPages
{
    /// <summary>
    /// Interaction logic for TankkaartPagina.xaml
    /// </summary>
    public partial class TankkaartPagina : Page
    {
        private DomeinController _dc;
        public TankkaartPagina(DomeinController dc)
        {
            InitializeComponent();
            _dc = dc;
            RefreshTankkaarten();

            string[] filterMogelijkheden = { "Kaartnummer", "Geldigheidsdatum", "Brandstoftype", "Geblokkeerd" };

            cmbFilter.ItemsSource = filterMogelijkheden;
        }

        private void RefreshTankkaarten()
        {
            lvOverzichtTankkaarten.Items.Clear();
            var tankkaarten = _dc.GeefTankkaarten();

            foreach (Tankkaart tankkaart in tankkaarten)
            {
                lvOverzichtTankkaarten.Items.Add(tankkaart);

            }
        }
        private void btnVoegTankkaartToe_Click(object sender, RoutedEventArgs e)
        {
            NieuweTankkaartWindow nieuweTankkaartWindow = new NieuweTankkaartWindow(_dc);
            try
            {
                nieuweTankkaartWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er liep iets mis { ex.Message}");
            }

        }

        private void btnVerwijderTankkaart_Click(object sender, RoutedEventArgs e)
        {
            Tankkaart tankkaart = (Tankkaart)lvOverzichtTankkaarten.SelectedItem;
            MessageBoxResult result = MessageBox.Show($"Bent u zeker dat u tankkaart met kaartnummer: {tankkaart.Kaartnummer} wilt verwijderen?", "Verwijder tankkaart", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    _dc.DeleteTankkaart((Tankkaart)lvOverzichtTankkaarten.SelectedItem);

                    MessageBox.Show("Tankkaart verwijderd");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Er liep iets mis bij het verwijderen: {ex.Message}", "Er liep iets mis", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    RefreshTankkaarten();
                }
            }
            else if (result == MessageBoxResult.No)
            {
                MessageBox.Show("Geen items verwijderd.");
            }

        }
        private void lvOverzichtTankkaarten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnToonAlleInfo_Click(object sender, RoutedEventArgs e)
        {
            TankkaartInfoWindow tankkaartInfo = new(_dc, (Tankkaart)lvOverzichtTankkaarten.SelectedItem);
            tankkaartInfo.Show();
        }

        private void btnWijzigTankkaart_Click(object sender, RoutedEventArgs e)
        {
            TankkaartUpdateWindow tankkaartUpdate = new(_dc, (Tankkaart)lvOverzichtTankkaarten.SelectedItem);
            tankkaartUpdate.Show();
        }

        private void btnZoek_Click(object sender, RoutedEventArgs e)
        {
            string zoekterm = tbFilter.Text;
            string kolom = cmbFilter.Text;


            var gefilterdeTankkaarten = _dc.FilterLijstTankkaart(zoekterm, kolom);
            lvOverzichtTankkaarten.Items.Clear();

            foreach (Tankkaart tankkaart in gefilterdeTankkaarten)
            {
                lvOverzichtTankkaarten.Items.Add(tankkaart);

            }
        }

        private void btnWisFilters_Click(object sender, RoutedEventArgs e)
        {
            tbFilter.Clear();
            RefreshTankkaarten();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshTankkaarten();
        }
    }
}
