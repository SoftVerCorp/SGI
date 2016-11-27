using SGI.Enumeration;
using SGI.Helpers;
using SGI.Model;
using SGI.Stuffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SGI.ViewModel.Catalogos
{
    public class CatalogoPaqueteriasVM : ViewModelBase
    {
        #region Private Fields

        private string nombre;
        private string filtroNombre;
        private string direccion;
        private string filtroDireccion;

        private int idPaqueteria;

        private List<Paqueterias> paqueterias;
        private List<Paqueterias> paqueteriasAux;

        private Operation tipoDeOperacion;


        #endregion

        public CatalogoPaqueteriasVM()
        {
            try
            {
                tipoDeOperacion = Operation.Create;
                idPaqueteria = -1;
                MostrarDatos();
            }
            catch (Exception ex)
            {

            }
        }

        #region Public Properties
        public List<Paqueterias> Paqueterias
        {
            get { return paqueterias; }
            set
            {
                if (paqueterias != value)
                {
                    paqueterias = value;
                    RaisePropertyChanged(() => Paqueterias);
                }
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (nombre != value)
                {
                    nombre = value;
                    RaisePropertyChanged(() => Nombre);
                }
            }
        }


        public string Direccion
        {
            get { return direccion; }
            set
            {
                if (direccion != value)
                {
                    direccion = value;
                    RaisePropertyChanged(() => Direccion);
                }
            }
        }

        public string FiltroNombre
        {
            get { return filtroNombre; }
            set
            {
                if (filtroNombre != value)
                {
                    filtroNombre = value;
                    RaisePropertyChanged(() => FiltroNombre);
                    BusquedaAsync();
                }
            }
        }


        public string FiltroDireccion
        {
            get { return filtroDireccion; }
            set
            {
                if (filtroDireccion != value)
                {
                    filtroDireccion = value;
                    RaisePropertyChanged(() => FiltroDireccion);
                    BusquedaAsync();
                }
            }
        }

        public ICommand InsertarPaqueteriaCmd
        {
            get
            {
                return new RelayCommand(s => InsertarPaqueteria());
            }
        }

        public ICommand EliminarPaqueteriaCmd
        {
            get
            {
                return new RelayCommand(OnDeleteItem);
            }
        }

        #endregion

        #region Private Methods

        public override void ExportarExcel()
        {
            try
            {
                System.Windows.Forms.FolderBrowserDialog broserDialog = new System.Windows.Forms.FolderBrowserDialog();

                if (broserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var pathFile = broserDialog.SelectedPath;
                    var fileName = "CatalogoPAqueterias.xls";

                    var dataTable = ExportToExcel.ListToDataTable(this.Paqueterias);

                    ExportToExcel.ExportDocument(dataTable, "Catalogo de Paqueterias", pathFile + "/" + fileName);

                    System.Windows.MessageBox.Show("Archivo exportado correctamente");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al exportar archivo de excel");
            }
        }


        private async void BusquedaAsync()
        {
            try
            {
                this.Paqueterias = await Task.Run(() => ObtenerPaqueteriasAsync());
            }
            catch (Exception ex)
            {

            }
        }

        private async Task<List<Paqueterias>> ObtenerPaqueteriasAsync()
        {
            Task.Delay(100);

            try
            {
                var aux = this.paqueteriasAux;

                var result = (from x in aux
                              where
                              (
                              (!string.IsNullOrEmpty(this.FiltroNombre) ? x.Nombre.ToUpper().Contains(this.FiltroNombre.ToUpper()) : true)
                              &&
                              (!string.IsNullOrEmpty(this.FiltroDireccion) ? x.Direccion.ToUpper().Contains(this.FiltroDireccion.ToUpper()) : true)
                              )
                              select x).ToList();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void MostrarDatos()
        {
            try
            {
                this.Paqueterias = Repository.ObtenerPaqueterias();
                this.paqueteriasAux = this.Paqueterias;
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void InsertarPaqueteria()
        {
            try
            {
                if (string.IsNullOrEmpty(this.Nombre))
                {
                    MessageBox.Show("Debe ingresar el nombre de la paqueteria", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (string.IsNullOrEmpty(this.Direccion))
                {
                    MessageBox.Show("Debe ingresar la direccion de la paqueteria", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (tipoDeOperacion == Operation.Create)
                {
                    var res = Repository.InsetarPaqueteria(this.Nombre, this.Direccion);

                    if (!res)
                    {
                        MessageBox.Show("Error al insertar paqueteria", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    MessageBox.Show("Datos guardados con exito", "Datos Guardados", MessageBoxButton.OK, MessageBoxImage.Information);
                    OnClean();
                    MostrarDatos();
                }
                else
                {
                    if (tipoDeOperacion == Operation.Update)
                    {
                        if (this.idPaqueteria == -1)
                        {
                            MessageBox.Show("Error, debe seleccionar un elemento a modificar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        var res = Repository.ActualizarPaqueteria(this.idPaqueteria, this.Nombre, this.Direccion);

                        if (!res)
                        {
                            MessageBox.Show("Error al modificar paqueteria", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        MessageBox.Show("Datos modificados con exito", "Datos Guardados", MessageBoxButton.OK, MessageBoxImage.Information);
                        OnClean();
                        MostrarDatos();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public override void OnDeleteItem(object param)
        {
            if (this.idPaqueteria == -1)
            {
                MessageBox.Show("Error, debe seleccionar un elemento a modificar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var res = Repository.EliminarPaqueteria(this.idPaqueteria);

            if (!res)
            {
                MessageBox.Show("Error al eliminar la paqueteria seleccionada", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show("Datos eliminados con exito", "Datos Eliminados", MessageBoxButton.OK, MessageBoxImage.Information);
            OnClean();
            MostrarDatos();
        }

        public override void OnSelectedItemGridClick(object parameters)
        {
            Paqueterias item = Helpers.DataGridRowHelper.GetDatagridRow(parameters as MouseButtonEventArgs) as Paqueterias;

            if (item == null)
                return;

            try
            {

                this.tipoDeOperacion = Enumeration.Operation.Update;

                this.idPaqueteria = item.Id;
                this.Nombre = item.Nombre;
                this.Direccion = item.Direccion;

            }
            catch (Exception ex)
            {

            }
        }

        public override void OnClean()
        {
            this.Nombre = string.Empty;
            this.Direccion = string.Empty;
            this.tipoDeOperacion = Operation.Create;
            this.MostrarDatos();
        }

        #endregion
    }
}
