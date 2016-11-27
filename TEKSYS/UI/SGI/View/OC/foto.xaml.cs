using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using WebEye.Controls.Wpf;

namespace SGI.View
{
    /// <summary>
    /// Interaction logic for foto.xaml
    /// </summary>
    public partial class foto : Window
    {
        public string Ruta { get; set; }
        public foto()
        {
            InitializeComponent();
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            comboBox2.ItemsSource = webCameraControl.GetVideoCaptureDevices();

            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedItem = comboBox2.Items[0];
            }
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // startButton.IsEnabled = e.AddedItems.Count > 0;
        }

        private void OnStartButtonClick(object sender, RoutedEventArgs e)
        {
            //var cameraId = (WebCameraId)comboBox.SelectedItem;
            //webCameraControl.StartCapture(cameraId);
        }

        private void OnStopButtonClick(object sender, RoutedEventArgs e)
        {
            webCameraControl.StopCapture();
            var cameraId = (WebCameraId)comboBox2.SelectedItem;
            webCameraControl.StartCapture(cameraId);
            webCameraControl.Visibility = System.Windows.Visibility.Visible;
            preview.Visibility = System.Windows.Visibility.Hidden;
            preview.Source = null;
        }

        private void OnImageButtonClick(object sender, RoutedEventArgs e)
        {

            var fototomada = webCameraControl.GetCurrentImage();

            webCameraControl.Visibility = System.Windows.Visibility.Hidden;
            preview.Visibility = System.Windows.Visibility.Visible;

            MemoryStream ms = new MemoryStream();
            fototomada.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            ms.Position = 0;
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = ms;
            bi.EndInit();
            preview.Source = bi;

            new Task(() =>
            {
                Thread.Sleep(2000);
                var dialog = new SaveFileDialog { Filter = "Bitmap Image (.bmp)|*.bmp|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png" };
                if (dialog.ShowDialog() == true)
                {
                    fototomada.Save(dialog.FileName);
                    Ruta = dialog.FileName;
                }
            }).Start();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var cameraId = (WebCameraId)comboBox2.SelectedItem;
                webCameraControl.StartCapture(cameraId);
            }
            catch(Exception ex)
            {
                
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            webCameraControl.StopCapture();
            
        }
    }
}
