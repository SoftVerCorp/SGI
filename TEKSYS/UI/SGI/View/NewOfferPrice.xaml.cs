﻿using System;
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
using System.Windows.Shapes;

namespace SGI.View
{
    /// <summary>
    /// Interaction logic for NewOfferPrice.xaml
    /// </summary>
    public partial class NewOfferPrice : Window
    {
        public NewOfferPrice()
        {
            InitializeComponent();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                Regex regex = new Regex(@"[^0-9.\-]+$");
                e.Handled = regex.IsMatch(e.Text);

              //  //Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");
              //  Regex regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
              ////  e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
              //  e.Handled = !regex.IsMatch(e.Text);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
