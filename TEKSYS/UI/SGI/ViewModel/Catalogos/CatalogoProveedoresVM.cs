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
    public class CatalogoProveedoresVM : ViewModelBase
    {
        #region Private Fields

        private Provider selectedProvider;
        private List<Provider> providerList;
        private List<Provider> listaDeProvAux;
        private List<TypePay> tiposDePago;
        private int idTipoPago;
        private int cantidadDeDias;





        private string nombreProveedorFiltro;
        private string razonSocialFiltro;



        #endregion

        #region Public Fields

        public event EventHandler OnAddSupplier;

        #endregion

        #region Public Properties

        public int CantidadDeDias
        {
            get { return cantidadDeDias; }
            set
            {
                cantidadDeDias = value;
                RaisePropertyChanged(() => CantidadDeDias);
            }
        }

        public int IdTipoPago
        {
            get { return idTipoPago; }
            set
            {
                idTipoPago = value;
                RaisePropertyChanged(() => IdTipoPago);
            }
        }

        public List<TypePay> TiposDePago
        {
            get { return tiposDePago; }

        }

        /// <summary>
        /// Obtiene o establece el nombre del proveedor para realizar la busqueda
        /// </summary>
        public string NombreProveedorFiltro
        {
            get { return nombreProveedorFiltro; }
            set
            {
                if (nombreProveedorFiltro != value)
                {
                    nombreProveedorFiltro = value;
                    RaisePropertyChanged(() => NombreProveedorFiltro);
                    BusquedaAsincrona();
                }
            }
        }


        /// <summary>
        /// Obtiene o establece la razon social para realizar la busqueda
        /// </summary>
        public string RazonSocialFiltro
        {
            get { return razonSocialFiltro; }
            set
            {
                if (razonSocialFiltro != value)
                {
                    razonSocialFiltro = value;
                    RaisePropertyChanged(() => RazonSocialFiltro);
                    BusquedaAsincrona();
                }
            }
        }

        public Provider SelectedProvider
        {
            get { return this.selectedProvider; }
            set
            {
                this.selectedProvider = value;
                RaisePropertyChanged(() => SelectedProvider);

            }
        }

        public List<Provider> ProviderList
        {
            get { return this.providerList; }
            set
            {
                this.providerList = value;
                RaisePropertyChanged(() => ProviderList);

            }
        }

        #endregion

        #region Constructors

        public CatalogoProveedoresVM()
        {
            try
            {
                this.tiposDePago = new List<TypePay>();
                tiposDePago.Add(new TypePay { Id = -1, description = "Seleccionar" });
                this.tiposDePago.AddRange(Repository.GetTypePay());
                LimpiarCampos();

                this.OperationType = Enumeration.Operation.Create;
                OnRefresh();
            }
            catch (Exception)
            {

            }
        }

        public RelayCommand Actualizar
        {
            get { return new RelayCommand(s => ActualizaProveedor()); }
        }
        public RelayCommand Agregar
        {
            get { return new RelayCommand(s => AgregarProveedor()); }
        }
        public RelayCommand Eliminar
        {
            get { return new RelayCommand(s => EliminarProveedor()); }
        }

        public RelayCommand Limpiar
        {
            get { return new RelayCommand(s => LimpiarCampos()); }
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
                    var fileName = "CatalogoProveedores.xls";

                    var dataTable = ExportToExcel.ListToDataTable(this.ProviderList);

                    ExportToExcel.ExportDocument(dataTable, "Catalogo de Proveedores", pathFile + "/" + fileName);

                    System.Windows.MessageBox.Show("Archivo exportado correctamente");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al exportar archivo de excel");
            }
        }


        public async void BusquedaAsincrona()
        {
            try
            {
                this.ProviderList = await Task.Run(() => this.ObtenerListaDeProveedoresAsync());
            }
            catch (Exception ex)
            {

            }
        }

        private void ActualizaProveedor()
        {
            if (selectedProvider == null)
            {
                MessageBox.Show("Selecciona un proveedor...", "Informacion", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (selectedProvider.IdTipoPago == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de pago", "Informacion", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (selectedProvider.CantidadDeDias == 0)
            {
                MessageBox.Show("Debe ingresar el numero de dias del tipo de pago", "Informacion", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (MessageBox.Show("¿Realmente deseas actualizar la informacion del proveedor?", "Proveedores", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                Repository.AdminProveedores(selectedProvider.Id, selectedProvider.Name, selectedProvider.CompanyName, selectedProvider.Address, selectedProvider.Correo, selectedProvider.Rfc, 2, SelectedProvider.IdTipoPago, SelectedProvider.CantidadDeDias);
            }
            OnRefresh();
        }
        private void AgregarProveedor()
        {
            if (selectedProvider.IdTipoPago == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de pago", "Informacion", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (selectedProvider.CantidadDeDias == 0)
            {
                MessageBox.Show("Debe ingresar el numero de dias del tipo de pago", "Informacion", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (MessageBox.Show("¿Realmente deseas agregar este proveedor?", "Proveedores", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                Repository.AdminProveedores(-1, selectedProvider.Name, selectedProvider.CompanyName, selectedProvider.Address, selectedProvider.Correo, selectedProvider.Rfc, 1, selectedProvider.IdTipoPago, selectedProvider.CantidadDeDias);
            }

            OnRefresh();
        }
        private void EliminarProveedor()
        {
            if (selectedProvider == null)
                MessageBox.Show("Selecciona un proveedor...", "Informacion", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            if (MessageBox.Show("¿Realmente deseas eliminar el proveedor seleccionado?", "Proveedores", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                Repository.AdminProveedores(selectedProvider.Id, selectedProvider.Name, selectedProvider.CompanyName, selectedProvider.Address, selectedProvider.Correo, selectedProvider.Rfc, 3, this.IdTipoPago, this.CantidadDeDias);
            }

            OnRefresh();
        }

        private void LimpiarCampos()
        {
            //this.IdTipoPago = -1;
            //this.CantidadDeDias = 0;

            SelectedProvider = new Provider()
            {
                Id = -1,
                Name = "",
                Address = "",
                Rfc = "",
                Correo = "",
                CompanyName = "",
                Active = false,
                IdTipoPago = -1,
                CantidadDeDias = 0
            };

        }


        private async Task<List<Provider>> ObtenerListaDeProveedoresAsync()
        {
            List<Provider> lst = new List<Provider>();

            try
            {
                var aux = this.listaDeProvAux;

                lst = aux.Where(
                      s =>
                         (

                          (
                          (!string.IsNullOrEmpty(this.NombreProveedorFiltro) ? s.Name.ToUpper().Contains(this.NombreProveedorFiltro.ToUpper()) : true)
                          &&
                          (!string.IsNullOrEmpty(this.RazonSocialFiltro) ? s.CompanyName.ToUpper().Contains(this.RazonSocialFiltro.ToUpper()) : true)
                          )

                         )
                    ).ToList();

                return lst;
            }
            catch (Exception ex)
            {
                return lst;
            }
        }


        private void OnRefresh()
        {
            try
            {
                this.ProviderList = Repository.GetSuppliers(-1);
                this.listaDeProvAux = Repository.GetSuppliers(-1);
            }
            catch (Exception ex)
            {

            }
        }

        public override void OnSelectedItemGridClick(object parameters)
        {
            Provider item = Helpers.DataGridRowHelper.GetDatagridRow(parameters as MouseButtonEventArgs) as Provider;

            if (item == null)
                return;

            try
            {
                //this.CantidadDeDias = item.CantidadDeDias;
                //this.IdTipoPago = item.IdTipoPago;
                this.SelectedProvider = item;

                if (this.OnAddSupplier != null)
                {
                    this.OnAddSupplier(this, null);
                }
                OnClose();
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

    }
}
