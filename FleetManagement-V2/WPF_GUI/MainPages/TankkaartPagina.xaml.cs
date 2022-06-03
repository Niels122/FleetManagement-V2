using Domein;
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
using WPF_GUI.ToevoegenWindows;

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
    }
}
