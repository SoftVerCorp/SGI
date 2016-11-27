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
    public class ViewCoinsVM : ViewModelBase
    {
        #region Private Fields

        private int coinsId;

        private string coinsName;
        private string coinNameFilter;

        private List<Coin> itemList;
        private List<Coin> itemListAux;

        #endregion

        #region Constructors

        /// <summary>
        /// Representa una nueva instancia de la clase ViewFamilyVM
        /// </summary>
        public ViewCoinsVM()
        {
            try
            {
                this.OperationType = Enumeration.Operation.Create;
                Init();
            }
            catch (Exception ex)
            {

            }
        }



        #endregion

        #region Public Properties

        /// <summary>
        /// Obtiene o establece el nombre de la moneda.
        /// </summary>
        public string CoinsName
        {
            get { return coinsName; }
            set
            {
                if (coinsName != value)
                {
                    coinsName = value;
                    RaisePropertyChanged(() => CoinsName);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece una lista de familias.
        /// </summary>
        public List<Coin> ItemList
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

        /// <summary>
        /// Obtiene o establece el nombre de la familia
        /// </summary>
        public string CoinNameFilter
        {
            get { return coinNameFilter; }
            set
            {
                if (coinNameFilter != value)
                {
                    coinNameFilter = value;
                    RaisePropertyChanged(() => CoinNameFilter);
                    SearchAsync();
                }
            }
        }



        #endregion

        #region Private Methods

        public override void OnSelectedItemGridClick(object parameters)
        {
            var item = Helpers.DataGridRowHelper.GetDatagridRow(parameters as MouseButtonEventArgs) as Coin;

            if (item == null)
                return;

            this.coinsId = item.Id;
            this.CoinsName = item.CoinName;
            this.OperationType = Enumeration.Operation.Update;
        }

        public override void OnSave()
        {
            if (string.IsNullOrEmpty(this.CoinsName))
            {
                MessageBox.Show("Debe ingresar un nombre", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                string errorMessage = string.Empty;
                int error = 0;

                if (this.OperationType == Enumeration.Operation.Create)
                {
                    var result = Repository.InsCoins(this.CoinsName, ref error, ref errorMessage);

                    if (!result || error == -1)
                    {
                        MessageBox.Show("Error " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    MessageBox.Show("Datos guardados con exito ", "Datos Guardados", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {
                    if (this.OperationType == Enumeration.Operation.Update)
                    {
                        var result = Repository.UpdCoins(this.coinsId, this.CoinsName, ref errorMessage);

                        if (!result)
                        {
                            MessageBox.Show("Error " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        MessageBox.Show("Datos modificados con exito ", "Datos modificados", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                Task.Run(() => this.Init());
                OnClean();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void OnClean()
        {
            this.CoinNameFilter = string.Empty;
            this.CoinsName = string.Empty;
            this.OperationType = Enumeration.Operation.Create;
            this.coinsId = 0;
        }

        private void Init()
        {
            try
            {
                ItemList = Repository.GetCoins(string.Empty);
                itemListAux = ItemList;
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

        private async Task<List<Coin>> GetList()
        {
            await Task.Delay(100);

            List<Coin> lst = new List<Coin>();

            try
            {
                var aux = this.itemListAux;

                lst = aux.Where(
                      s =>
                         (
                          ((!string.IsNullOrEmpty(this.CoinNameFilter) ? s.CoinName.ToUpper().Contains(this.CoinNameFilter.ToUpper()) : true))
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
            try
            {
                // OnSelectedOfferType(this, new SelectedOfferTypeEventArgs(this.SelectedOfferType));
                OnClose();
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public override void OnDeleteItem(object param)
        {
            try
            {
                if (this.coinsId == 0)
                {
                    MessageBox.Show("Debe elegir una fila para eliminar ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                MessageBoxResult result = MessageBox.Show("¿Esta seguro de querer eliminar este elemento", "Eliminar elementos", MessageBoxButton.OKCancel, MessageBoxImage.Information);

                if (result == MessageBoxResult.OK)
                {

                    string errorMsg = string.Empty;
                    var res = Repository.DelCoins(this.coinsId, ref errorMsg);

                    if (!res)
                    {
                        MessageBox.Show("Error al eliminar el dato " + errorMsg, "Dato eliminado", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    MessageBox.Show("Elemento eliminado", "Dato eliminado", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    Task.Run(() => this.Init());
                    OnClean();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion
    }
}

