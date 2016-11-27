
using SGI.Enumeration;
using SGI.Helpers;
using SGI.Model;
using SGI.Stuffs;
using SGI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SGI.ViewModel.Catalogos
{
    public class CatalogoClientesVM : ViewModelBase
    {
        #region Private Fields

        private string nombreCliente;
        private string nombreClienteFiltro;
        private Operation tipoOperacion;
        private List<Cliente> clientes;
        private List<Cliente> clientesAux;
        private List<TipoCliente> tipoDeClientes;
        private Cliente selectedCliente;
        private TipoCliente tipodeCliente; 


        #endregion

        public CatalogoClientesVM()
        {
            try
            {
                this.tipoOperacion = Operation.Create;
                this.InicializarDatos();
            }
            catch (Exception ex)
            {

            }
        }


        #region Public Properties

      

        public List<Cliente> Clientes
        {
            get { return clientes; }
            set
            {
                if (clientes != value)
                {
                    clientes = value;
                    RaisePropertyChanged(() => Clientes);
                }
            }
        }

        public string NombreCliente
        {
            get { return nombreCliente; }
            set
            {
                if (nombreCliente != value)
                {
                    nombreCliente = value;
                    RaisePropertyChanged(() => NombreCliente);
                }
            }
        }


        public string NombreClienteFiltro
        {
            get { return nombreClienteFiltro; }
            set
            {
                if (nombreClienteFiltro != value)
                {
                    nombreClienteFiltro = value;
                    RaisePropertyChanged(() => NombreClienteFiltro);
                    BusquedaAsync();
                }
            }
        }

        public ICommand InsertarClienteCmd
        {
            get
            {
                return new RelayCommand(s => InsertarCliente());
            }
        }

        public ICommand EliminarClienteCmd
        {
            get
            {
                return new RelayCommand(OnDeleteItem);
            }
        }

        public ICommand TomarFotoCMD
        {
            get
            {
                return new RelayCommand(s => OnTomarFotoCmd());
            }
        }

        public Cliente SelectedCliente
        {
            get
            {
                return selectedCliente;
            }
            set
            {
                selectedCliente = value;
                RaisePropertyChanged(() => SelectedCliente);
            }
        }

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

        public TipoCliente TipodeCliente
        {
            get
            {
                return tipodeCliente;
            }

            set
            {
                tipodeCliente = value;
                RaisePropertyChanged(() => TipodeCliente);
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
                    var fileName = "CatalogoClientes.xls";

                    var dataTable = ExportToExcel.ListToDataTable(this.Clientes);

                    ExportToExcel.ExportDocument(dataTable, "Catalogo de Clientes", pathFile + "/" + fileName);

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
                this.Clientes = await Task.Run(() => ObtenerClientesAsync());
            }
            catch (Exception ex)
            {

            }
        }

        private async Task<List<Cliente>> ObtenerClientesAsync()
        {
            Task.Delay(100);

            try
            {
                var aux = this.clientesAux;

                var result = (from x in aux
                              where
                              (
                              (!string.IsNullOrEmpty(this.NombreClienteFiltro) ? x.NombreComercial.ToUpper().Contains(this.NombreClienteFiltro.ToUpper()) : true)

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
            Cliente item = Helpers.DataGridRowHelper.GetDatagridRow(parameters as MouseButtonEventArgs) as Cliente;

            if (item == null)
                return;

            try
            {
                this.tipoOperacion = Enumeration.Operation.Update;
                this.SelectedCliente = item as Cliente;
                this.TipodeCliente = TipoDeClientes.FirstOrDefault(s => s.Id == selectedCliente.IdTipoCliente);
            }
            catch (Exception ex)
            {

            }
        }


        public override void OnDeleteItem(object param)
        {
            if (this.selectedCliente == null)
            {
                MessageBox.Show("Error, debe seleccionar un elemento a eliminar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

           // Repository.EliminarCliente(SelectedCliente.IdCliente);


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
                this.tipoOperacion = Operation.Create;
                this.NombreClienteFiltro = string.Empty;
                this.NombreCliente = string.Empty;
                this.SelectedCliente = new Cliente();
                //this.SelectedCliente.idCliente = -1;
                //this.InicializarDatos();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void InsertarCliente()
        {
            try
            {
                if (SelectedCliente == null)
                {
                    return;
                }

                if (TipodeCliente == null)
                {
                    MessageBox.Show("Debe ingresar el tipo de cliente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (TipodeCliente.Id == -1)
                {
                    MessageBox.Show("Debe ingresar el tipo de cliente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (tipoOperacion == Operation.Create)
                {
                    //SelectedCliente.idTipoCliente = TipodeCliente.Id;
                    //var res = Repository.InsUpdCliente(SelectedCliente);

                    //if (res == -1)
                    //{
                    //    MessageBox.Show("Error al insertar tipo de cliente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    //    return;
                    //}

                    MessageBox.Show("Datos guardados con exito", "Datos Guardados", MessageBoxButton.OK, MessageBoxImage.Information);
                    OnClean();
                    InicializarDatos();
                }
                else
                {
                    if (tipoOperacion == Operation.Update)
                    {
                        if (SelectedCliente == null)
                        {
                            MessageBox.Show("Error, debe seleccionar un elemento a modificar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        //if (SelectedCliente.idCliente == -1)
                        //{
                        //    MessageBox.Show("Error, debe seleccionar un elemento a modificar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        //    return;
                        //}

                        if (TipodeCliente == null)
                        {
                            MessageBox.Show("Debe ingresar el tipo de cliente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        if (TipodeCliente.Id == -1)
                        {
                            MessageBox.Show("Debe ingresar el tipo de cliente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        //selectedCliente.idTipoCliente = tipodeCliente.Id;
                        //Repository.InsUpdCliente(selectedCliente);
                        //MessageBox.Show("Datos modificados con exito", "Datos Guardados", MessageBoxButton.OK, MessageBoxImage.Information);
                        ////OnClean();
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
                this.Clientes = Repository.GetClientes(-1);
                RaisePropertyChanged(() => Clientes);
                this.TipoDeClientes = Repository.ObtenerTipoClientes();
                this.tipoDeClientes.Insert(0, new TipoCliente() { Id = -1, TipoClientes = "Ninguno", Descuentos = 0 });
                RaisePropertyChanged(() => TipoDeClientes);
                this.TipodeCliente = tipoDeClientes.FirstOrDefault();
                this.clientesAux = this.Clientes;
                this.SelectedCliente = new Cliente();
                //this.SelectedCliente.idCliente = -1;
                this.tipoOperacion = Operation.Create;
            }
            catch (Exception ex)
            {

            }
        }

        private void OnTomarFotoCmd()
        {
            if (SelectedCliente == null)
            {
                MessageBox.Show("Error, debe seleccionar un elemento a modificar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var tomarfoto = new foto();
            tomarfoto.ShowDialog();

            selectedCliente.Foto = tomarfoto.Ruta;
            RaisePropertyChanged(() => SelectedCliente.Foto);
        }

        #endregion
    }
}
