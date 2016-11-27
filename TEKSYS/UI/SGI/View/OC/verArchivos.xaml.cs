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
using GalaSoft.MvvmLight;
using SGI.Model;

namespace SGI.View.OC
{
    /// <summary>
    /// Interaction logic for verArchivos.xaml
    /// </summary>
    public partial class verArchivos : Window
    {
        private List<Model.ArchivoAdjunto> lista;

        public List<Model.ArchivoAdjunto> Lista
        {
            get { return lista; }
            set { lista = value; }
        }

        public verArchivos()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public void SetDatos(List<Model.ArchivoAdjunto> archivos)
        {
            this.Lista = archivos;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (verGrid.SelectedItem != null)
                {
                    var selected = verGrid.SelectedItem as ArchivoAdjunto;
                    System.Diagnostics.Process.Start(selected.RutaArchivo);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
