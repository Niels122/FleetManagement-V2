﻿using Domein;
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
    /// Interaction logic for BestuurderPagina.xaml
    /// </summary>
    public partial class BestuurderPagina : Page
    {
        private DomeinController _dc;
        public BestuurderPagina(DomeinController dc)
        {
            InitializeComponent();
            _dc = dc;
            RefreshBestuurders();
        }

        private void RefreshBestuurders()
        {
            List<Bestuurder> bestuurders = _dc.GeefBestuurders();
            foreach (Bestuurder bestuurder in bestuurders)          //over lijst van bestuurders lopen en deze invullen
            {
                lvOverzichtBestuurders.Items.Add(bestuurder);
            }
        }
        private void lvOverzichtBestuurders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnVoegBestuurderToe_Click(object sender, RoutedEventArgs e)
        {
            NieuweBestuurderWindow nieuweBestuurderWindow = new(_dc);
            nieuweBestuurderWindow.Show();
        }

        private void btnVerwijderBestuurder_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show($"Bent u zeker dat u bestuurder {lvOverzichtBestuurders.SelectedItem} wilt verwijderen?", "Verwijder bestuurder", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    _dc.DeleteBestuurder((Bestuurder)lvOverzichtBestuurders.SelectedItem);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Er liep iets mis bij het verwijderen: {ex.Message}", "Er liep iets mis", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    RefreshBestuurders();
                }
            }
            else if (result == MessageBoxResult.No)
            {
                MessageBox.Show("Geen items verwijderd.");
            }
        }

        private void btnToonAlleInfo_Click(object sender, RoutedEventArgs e)
        {
            if (lvOverzichtBestuurders.SelectedItem != null)
            {
                BestuurderInfoWindow bestuurderInfoWindow = new(_dc, (Bestuurder)lvOverzichtBestuurders.SelectedItem);
                bestuurderInfoWindow.Show();
            }
            else
            {
                MessageBox.Show("Geen item geslecteerd", "Waarschuwing", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnWijzigBestuurder_Click(object sender, RoutedEventArgs e)
        {
            if (lvOverzichtBestuurders.SelectedItem != null)
            {
                BestuurderUpdateWindow bestuurderUpdateWindow = new(_dc, (Bestuurder)lvOverzichtBestuurders.SelectedItem);
                bestuurderUpdateWindow.Show();
            }
            else
            {
                MessageBox.Show("Geen item geslecteerd", "Waarschuwing", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void lvOverzichtBestuurders_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BestuurderInfoWindow bestuurderInfoWindow = new(_dc, (Bestuurder)lvOverzichtBestuurders.SelectedItem);
            bestuurderInfoWindow.Show();
        }
    }
}
