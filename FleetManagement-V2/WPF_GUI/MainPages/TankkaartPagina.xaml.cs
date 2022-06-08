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
        }

        private void RefreshTankkaarten()
        {
            var tankkaarten = _dc.GeefTankkaarten();

            foreach (Tankkaart tankkaart in tankkaarten)
            {
                lvOverzichtTankkaarten.Items.Add(tankkaart);
            }
        }
        private void btnVoegTankkaartToe_Click(object sender, RoutedEventArgs e)
        {
            NieuweTankkaartWindow nieuweTankkaartWindow = new NieuweTankkaartWindow(_dc);
            nieuweTankkaartWindow.Show();
        }

        private void btnVerwijderTankkaart_Click(object sender, RoutedEventArgs e)
        {

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
    }
}
