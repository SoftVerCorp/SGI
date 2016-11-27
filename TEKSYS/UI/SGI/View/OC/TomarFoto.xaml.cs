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
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using WebEye.Controls.Wpf;

namespace SGI.View
{
    /// <summary>
    /// Interaction logic for TomarFoto.xaml
    /// </summary>
    public partial class TomarFoto : Window
    {
        public TomarFoto()
        {
            InitializeComponent();
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            //comboBox.ItemsSource = webCameraControl.GetVideoCaptureDevices();

            //if (comboBox.Items.Count > 0)
            //{
            //    comboBox.SelectedItem = comboBox.Items[0];
            //}
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //startButton.IsEnabled = e.AddedItems.Count > 0;
        }

        private void OnStartButtonClick(object sender, RoutedEventArgs e)
        {
            //var cameraId = (WebCameraId)comboBox.SelectedItem;
            //webCameraControl.StartCapture(cameraId);
        }

        private void OnStopButtonClick(object sender, RoutedEventArgs e)
        {
            //webCameraControl.StopCapture();
        }

        private void OnImageButtonClick(object sender, RoutedEventArgs e)
        {
            //var dialog = new SaveFileDialog { Filter = "Bitmap Image|*.bmp" };
            //if (dialog.ShowDialog() == true)
            //{
            //    webCameraControl.GetCurrentImage().Save(dialog.FileName);
            //}
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //var cameraId = (WebCameraId)comb.SelectedItem;
            //webCameraControl.StartCapture(cameraId);
        }
    }
}
