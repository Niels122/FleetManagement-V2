﻿using Domein;
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
        private DomeinController _dc;
        public NieuwVoertuigWindow(DomeinController dc)
        {
            _dc = dc;
            InitializeComponent();
        }
    }
}
