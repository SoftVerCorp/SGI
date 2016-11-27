using SGI.Helpers;
using SGI.Model;
using SGI.Model.Entidades;
using SGI.Stuffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SGI.ViewModel.CreditoYCobranza
{
    public class AbonarVM : ViewModelBase
    {
        private List<Abonos> abonos;
        private double totalVenta;
        private double totalAbonos;
        private double restan;
        private double cantidad;
        private DateTime fecha;
        private int idVenta;

        public AbonarVM(int idVentaP, double totalP)
        {
            try
            {
                this.idVenta = idVentaP;
                this.TotalVenta = totalP;

                this.Inicializar();

            }
            catch (Exception ex)
            {

            }
        }

        #region Public Properties

        public DateTime Fecha
        {
            get { return fecha; }
            set
            {
                fecha = value;
                RaisePropertyChanged(() => Fecha);
            }
        }


        public double Cantidad
        {
            get { return cantidad; }
            set
            {
                cantidad = value;
                RaisePropertyChanged(() => Cantidad);
            }
        }

        public double Restan
        {
            get { return restan; }
            set
            {
                restan = value;
                RaisePropertyChanged(() => Restan);
            }
        }


        public double TotalAbonos
        {
            get { return totalAbonos; }
            set
            {
                totalAbonos = value;
                RaisePropertyChanged(() => TotalAbonos);
            }
        }

        public double TotalVenta
        {
            get { return totalVenta; }
            set
            {
                totalVenta = value;
                RaisePropertyChanged(() => TotalVenta);
            }
        }
        public List<Abonos> Abonos
        {
            get { return abonos; }
            set
            {
                abonos = value;
                RaisePropertyChanged(() => Abonos);
            }
        }

        public ICommand AbonarCmd
        {
            get
            {
                return new RelayCommand(s => this.RealizarAbono());
            }
        }

        #endregion

        private void Inicializar()
        {
            try
            {

                this.Abonos = Repository.ObtenerAbonos(idVenta);

                if (this.Abonos.Count > 0)
                {
                    this.TotalAbonos = this.Abonos.Sum(s => s.Cantidad);
                }
                // this.TotalVenta = totalP;
                this.Restan = this.TotalVenta - TotalAbonos;
                this.Fecha = DateTime.Now;
                this.Cantidad = this.Restan;
            }
            catch (Exception ex)
            {

            }
        }

        private void RealizarAbono()
        {
            try
            {
                var res = MessageBox.Show("Desea realizar el abono?", "Confirmacion", MessageBoxButton.OKCancel, MessageBoxImage.Error);

                if (res != MessageBoxResult.OK)
                    return;


                if (Cantidad <= 0)
                {
                    MessageBox.Show("Debes agregar una cantidad valida");
                    return;
                }

                Repository.InsertarAbono(this.idVenta, ManejadorLoguin.idUsuario, ManejadorUbicacion.IdUbicacion, this.Cantidad, this.Fecha);

                Inicializar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregando abono", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
