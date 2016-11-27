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
    public class CatalogoTipoDeClienteVM : ViewModelBase
    {
        #region Private Fields

        public int idTipoEmpleado;

        private string tipoCliente;
        private string tipoClienteFiltro;

        private double descuento;

        private Operation tipoOperacion;

        private List<TipoCliente> tipoDeClientes;
        private List<TipoCliente> tipoDeClientesAux;

        #endregion

        public CatalogoTipoDeClienteVM()
        {
            try
            {
                this.idTipoEmpleado = -1;
                this.tipoOperacion = Operation.Create;
                this.descuento = 0;
                this.InicializarDatos();
            }
            catch (Exception ex)
            {

            }
        }


        #region Public Properties

        public List<TipoCliente> TipoDeClientes
        {
            get { return tipoDeClientes; }
            set
            {
                if (tipoDeClientes != value)
                {
                    tipoDeClientes = value;
                    RaisePropertyChanged(() => TipoDeClientes);
                }
            }
        }

        public string TipoCliente
        {
            get { return tipoCliente; }
            set
            {
                if (tipoCliente != value)
                {
                    tipoCliente = value;
                    RaisePropertyChanged(() => TipoCliente);
                }
            }
        }


        public double Descuento
        {
            get { return descuento; }
            set
            {
                if (descuento != value)
                {
                    descuento = value;
                    RaisePropertyChanged(() => Descuento);
                }
            }
        }

        public string TipoClienteFiltro
        {
            get { return tipoClienteFiltro; }
            set
            {
                if (tipoClienteFiltro != value)
                {
                    tipoClienteFiltro = value;
                    RaisePropertyChanged(() => TipoClienteFiltro);
                    BusquedaAsync();
                }
            }
        }

        public ICommand InsertarTipoClienteCmd
        {
            get
            {
                return new RelayCommand(s => InsertarTipoDeCliente());
            }
        }

        public ICommand EliminarTipoDeClienteCmd
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
                    var fileName = "CatalogoTipoClientes.xls";

                    var dataTable = ExportToExcel.ListToDataTable(this.TipoDeClientes);

                    ExportToExcel.ExportDocument(dataTable, "Catalogo de Tipos de Clientes", pathFile + "/" + fileName);

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
                this.TipoDeClientes = await Task.Run(() => ObtenerTipoDeClientesAsync());
            }
            catch (Exception ex)
            {

            }
        }

        private async Task<List<TipoCliente>> ObtenerTipoDeClientesAsync()
        {
            Task.Delay(100);

            try
            {
                var aux = this.tipoDeClientesAux;

                var result = (from x in aux
                              where
                              (
                              (!string.IsNullOrEmpty(this.TipoClienteFiltro) ? x.TipoClientes.ToUpper().Contains(this.TipoClienteFiltro.ToUpper()) : true)

                              )
                              select x).ToList();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public override void OnSelectedItemGridClick(object parameters)
        {
            TipoCliente item = Helpers.DataGridRowHelper.GetDatagridRow(parameters as MouseButtonEventArgs) as TipoCliente;

            if (item == null)
                return;

            try
            {

                this.tipoOperacion = Enumeration.Operation.Update;

                this.idTipoEmpleado = item.Id;
                this.TipoCliente = item.TipoClientes;
                this.Descuento = item.Descuentos;

            }
            catch (Exception ex)
            {

            }
        }


        public override void OnDeleteItem(object param)
        {
            if (this.idTipoEmpleado == -1)
            {
                MessageBox.Show("Error, debe seleccionar un elemento a eliminar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var res = Repository.EliminarTipoCliente(this.idTipoEmpleado);

            if (!res)
            {
                MessageBox.Show("Error al eliminar el tipo de cliente seleccionado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show("Datos eliminados con exito", "Datos Eliminados", MessageBoxButton.OK, MessageBoxImage.Information);
            OnClean();
            this.InicializarDatos();
        }

        public override void OnRefreshSearch()
        {
            try
            {
                this.InicializarDatos();
            }
            catch (Exception ex)
            {

            }
        }

        public override void OnClean()
        {
            try
            {
                this.idTipoEmpleado = -1;
                this.tipoOperacion = Operation.Create;
                this.Descuento = 0;
                this.TipoClienteFiltro = string.Empty;
                this.TipoCliente = string.Empty;
                //this.InicializarDatos();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void InsertarTipoDeCliente()
        {
            try
            {
                if (string.IsNullOrEmpty(this.TipoCliente))
                {
                    MessageBox.Show("Debe ingresar el tipo de cliente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }



                if (tipoOperacion == Operation.Create)
                {
                    var res = Repository.InsertarTipoCliente(this.TipoCliente, this.Descuento);

                    if (!res)
                    {
                        MessageBox.Show("Error al insertar tipo de cliente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    MessageBox.Show("Datos guardados con exito", "Datos Guardados", MessageBoxButton.OK, MessageBoxImage.Information);
                    OnClean();
                    InicializarDatos();
                }
                else
                {
                    if (tipoOperacion == Operation.Update)
                    {
                        if (this.idTipoEmpleado == -1)
                        {
                            MessageBox.Show("Error, debe seleccionar un elemento a modificar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        var res = Repository.ActualizarTipoCliente(this.idTipoEmpleado, this.TipoCliente, this.Descuento);

                        if (!res)
                        {
                            MessageBox.Show("Error al modificar tipo de cliente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        MessageBox.Show("Datos modificados con exito", "Datos Guardados", MessageBoxButton.OK, MessageBoxImage.Information);
                        //OnClean();
                        InicializarDatos();
                        OnClean();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void InicializarDatos()
        {
            try
            {
                this.TipoDeClientes = Repository.ObtenerTipoClientes();
                RaisePropertyChanged(() => TipoDeClientes);
                this.tipoDeClientesAux = this.TipoDeClientes;
            }
            catch (Exception ex)
            {

            }
        }

        #endregion
    }
}
