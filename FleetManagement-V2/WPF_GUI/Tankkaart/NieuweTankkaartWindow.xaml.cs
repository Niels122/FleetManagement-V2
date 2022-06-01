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
using System.Windows.Shapes;

namespace WPF_GUI.Tankkaart
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
        }
    }
}
