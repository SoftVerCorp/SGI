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

namespace SGI.ViewModel.DialogsInformation
{
    public class ViewProvidersVM : ViewModelBase
    {
        #region Private Fields

        private string name;
        private string rfc;

        private int providerId;
        private string providerName;
        private string providerRfc;
        private string providerAddress;

        private Provider selectedItem;

        private List<Provider> itemList;
        private List<Provider> itemListAux;

        #endregion

        #region Constructors

        /// <summary>
        /// Representa una nueva instancia de la clase NewCoinsVM
        /// </summary>
        public ViewProvidersVM()
        {
            try
            {
                this.OperationType = Enumeration.Operation.Create;
                this.ItemList = Repository.GetProviders(string.Empty);
                this.itemListAux = this.ItemList;
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Obtiene o establece el nombre del proveedor.
        /// </summary>
        public string ProviderName
        {
            get { return providerName; }
            set
            {
                if (providerName != value)
                {
                    providerName = value;
                    RaisePropertyChanged(() => ProviderName);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece la direccion
        /// </summary>
        public string ProviderAddress
        {
            get { return providerAddress; }
            set
            {
                if (providerAddress != value)
                {
                    providerAddress = value;
                    RaisePropertyChanged(() => ProviderAddress);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece la clave del teknobike
        /// </summary>
        public string ProviderRFC
        {
            get { return providerRfc; }
            set
            {
                if (providerRfc != value)
                {
                    providerRfc = value;
                    RaisePropertyChanged(() => ProviderRFC);
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public Provider SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                RaisePropertyChanged(() => SelectedItem);
            }
        }

        /// <summary>
        /// Obtiene o establece el filtro por nombre del proveedor
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    RaisePropertyChanged(() => Name);
                    SearchAsync();
                }
            }
        }

        /// <summary>
        /// Obtiene o establece el nombre de la moneda.
        /// </summary>
        public string Rfc
        {
            get { return rfc; }
            set
            {
                if (rfc != value)
                {
                    rfc = value;
                    RaisePropertyChanged(() => Rfc);
                    SearchAsync();
                }
            }
        }

        /// <summary>
        /// Obtiene o establece una lista de proveedores
        /// </summary>
        public List<Provider> ItemList
        {
            get { return itemList; }
            set
            {
                if (itemList != value)
                {
                    itemList = value;
                    RaisePropertyChanged(() => ItemList);
                }
            }
        }

        public ICommand Refresh
        {
            get
            {
                return new RelayCommand(s => this.OnRefresh());
            }
        }

        #endregion

        #region Private Methods

        public override void OnSelectedItemGridClick(object parameters)
        {
            var item = Helpers.DataGridRowHelper.GetDatagridRow(parameters as MouseButtonEventArgs) as Provider;

            if (item == null)
                return;

            this.providerId = item.Id;
            this.ProviderName = item.Name;
            this.ProviderRFC = item.Rfc;
            this.ProviderAddress = item.Address;

            this.OperationType = Enumeration.Operation.Update;
        }

        public override void OnSave()
        {
            if (string.IsNullOrEmpty(this.ProviderName))
            {
                MessageBox.Show("Debe ingreasar un nombre", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(this.ProviderRFC))
            {
                MessageBox.Show("Debe ingresar el RFC", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            try
            {
                string errorMessage = string.Empty;
                int error = 0;

                Provider provider = new Provider();
                provider.Id = this.providerId;
                provider.Name = this.ProviderName;
                provider.Rfc = this.ProviderRFC;
                provider.Address = this.ProviderAddress;


                if (this.OperationType == Enumeration.Operation.Create)
                {
                    var result = Repository.InsProvider(provider, ref error, ref errorMessage);

                    if (!result || error == -1)
                    {
                        MessageBox.Show("Error " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    MessageBox.Show("Datos guardados con exito ", "Datos Guardados", MessageBoxButton.OK, MessageBoxImage.Information);

                    //if (OnAddProviders != null)
                    //{
                    //    OnAddProviders(true, null);
                    //}
                }
                else
                {
                    if (this.OperationType == Enumeration.Operation.Update)
                    {
                        var res = Repository.UpdProviders(provider, ref errorMessage);

                        if (!res)
                        {
                            MessageBox.Show("Error " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                            return;
                        }

                        MessageBox.Show("Datos modificados con exito ", "Datos Modificados", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }

                //if (OnAddProviders != null)
                //{
                //    OnAddProviders(this, null);
                //}


            }
            catch (Exception ex)
            {

            }
            finally
            {
                Task.Run(() => { OnRefresh(); });
                OnClean();
            }
        }

        public override void OnClean()
        {
            this.providerId = 0;
            this.ProviderName = string.Empty;
            this.ProviderRFC = string.Empty;
            this.ProviderAddress = string.Empty;
            this.rfc = string.Empty;
            this.name = string.Empty;
        }

        public override void OnDeleteItem(object param)
        {
            try
            {
                
                string msg = string.Empty;

                if (this.providerId == 0)
                {
                    MessageBox.Show("Debe elegir un producto para eliminar ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var result = MessageBox.Show("¿Esta seguro de querer eliminar este elemento", "Eliminar elementos", MessageBoxButton.OKCancel, MessageBoxImage.Information);

                if (result == MessageBoxResult.OK)
                {

                    var resultDel = Repository.DelProviders(this.providerId, ref msg);

                    if (!resultDel)
                    {
                        MessageBox.Show("Error " + msg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    MessageBox.Show("Elemento eliminado", "Dato eliminado", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    Task.Run(() => this.OnRefresh());
                    OnClean();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override void OnUpdateItem(object param)
        {
            try
            {
                Provider provider = param as Provider;


                if (provider == null)
                {
                    MessageBox.Show("Debe elegir un proveedor a modificar ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                NewProviders np = new NewProviders();
                NewProviderVM vm = new NewProviderVM(provider);
                vm.OnAddProviders += VMOnAddProviders;
                np.DataContext = vm;
                np.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override void OnAddItem(object param)
        {
            try
            {
                NewProviders np = new NewProviders();
                NewProviderVM vm = new NewProviderVM();
                vm.OnAddProviders += VMOnAddProviders;
                np.DataContext = vm;
                np.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }

        void VMOnAddProviders(object sender, EventArgs e)
        {
            OnRefresh();
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnRefresh()
        {
            try
            {
                this.ItemList = Repository.GetProviders(string.Empty);
                this.itemListAux = this.ItemList;
            }
            catch (Exception ex)
            {

            }
        }

        public async void SearchAsync()
        {
            try
            {
                this.ItemList = await Task.Run(() => this.GetList());
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private async Task<List<Provider>> GetList()
        {
            List<Provider> lst = new List<Provider>();

            await Task.Delay(10);
            try
            {
                var aux = this.itemListAux;

                lst = aux.Where(
                      s =>
                         (

                          ((!string.IsNullOrEmpty(this.Name) ? s.Name.ToUpper().Contains(this.Name.ToUpper()) : true))
                          &&
                          ((!string.IsNullOrEmpty(this.Rfc) ? s.Rfc.ToUpper().Contains(this.Rfc.ToUpper()) : true))

                         )
                    ).ToList();

                return lst;
            }
            catch (Exception ex)
            {
                return lst;
            }
        }

        /// <summary>
        /// Ejecuta la accion para crear un nuevo elemento en el catalogo de familias.
        /// </summary>
        public override void OnAccept()
        {
            //if (string.IsNullOrEmpty(this.ProductName))
            //{
            //    MessageBox.Show("Debe ingresar un nombre", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return;
            //}

            //try
            //{
            //    string errorMessage = string.Empty;
            //    int error = 0;

            //    var result = Repository.InsCoins(this.ProductName, ref error, ref errorMessage);

            //    if (!result || error == -1)
            //    {
            //        MessageBox.Show("Error " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //        return;
            //    }

            //    MessageBox.Show("Datos guardados con exito ", "Datos Guardados", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
            //catch (Exception ex)
            //{

            //}
            //finally
            //{
            //    this.CleanText();
            //}
        }

        /// <summary>
        /// Limpiar el texto despues de guardar los datos.
        /// </summary>
        private void CleanText()
        {
            this.Name = string.Empty;
            this.Rfc = string.Empty;
        }

        #endregion
    }
}
