using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace zipcodetxtbox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String _usZipRegEx = @"^\d{5}(?:[-\s]\d{4})?$";
        String _caZipRegEx = @"^([ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ])\ {0,1}(\d[ABCEGHJKLMNPRSTVWXYZ]\d)$";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void uxUSZip_Changed(object sender, TextChangedEventArgs e)
        {
            if(!IsUSOrCanadianZipCode(uxUSZip.Text))
            {
                uxSubmit.IsEnabled = false;
            }
            else
            {
                uxSubmit.IsEnabled = true;
            }
        }

        private bool IsUSOrCanadianZipCode(string zipCode)
        {
            var validZipCode = true;
            if ((!Regex.Match(zipCode, _usZipRegEx).Success) && (!Regex.Match(zipCode, _caZipRegEx).Success))
            {
                validZipCode = false;
            }
            return validZipCode;
        }
    }
}
