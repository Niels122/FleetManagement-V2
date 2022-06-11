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

namespace WPF_GUI.UitgebreideFilters
{
    /// <summary>
    /// Interaction logic for TankkaardExtendedFilter.xaml
    /// </summary>
    public partial class TankkaardExtendedFilter : UserControl
    {
        public TankkaardExtendedFilter()
        {
            InitializeComponent();
        }

        //private void btnZoek_Click(object sender, RoutedEventArgs e)
        //{
        //    string zoekterm = tbKaartnummer.Text;
        //    string kolom = kaartnummer.Content.ToString();


        //    var gefilterdeTankkaarten = _dc.FilterLijstTankkaart(zoekterm, kolom);
        //    lvOverzichtTankkaarten.Items.Clear();

        //    foreach (Tankkaart tankkaart in gefilterdeTankkaarten)
        //    {
        //        lvOverzichtTankkaarten.Items.Add(tankkaart);

        //    }
        //}
    }
}
