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
    public class ViewTrademarksVM : ViewModelBase
    {
        #region Private Fields

        private int trademarkId;

        private string trademarkName;
        private string trademarkNameFilter;

        private Trademark selectedItem;

        private List<Trademark> itemList;
        private List<Trademark> itemListAux;

        #endregion

        #region Constructors

        /// <summary>
        /// Representa una nueva instancia de la clase ViewFamilyVM
        /// </summary>
        public ViewTrademarksVM()
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
        /// Obtiene o establece el nombre de la familia
        /// </summary>
        public string TrademarkName
        {
            get { return trademarkName; }
            set
            {
                if (trademarkName != value)
                {
                    trademarkName = value;
                    RaisePropertyChanged(() => TrademarkName);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece una lista de familias.
        /// </summary>
        public List<Trademark> ItemList
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
        public string TrademarkNameFilter
        {
            get { return trademarkNameFilter; }
            set
            {
                if (trademarkNameFilter != value)
                {
                    trademarkNameFilter = value;
                    RaisePropertyChanged(() => TrademarkNameFilter);
                    SearchAsync();
                }
            }
        }

        public Trademark SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                RaisePropertyChanged(() => SelectedItem);
            }
        }

        #endregion

        #region Private Methods

        public override void OnSelectedItemGridClick(object parameters)
        {
            var item = Helpers.DataGridRowHelper.GetDatagridRow(parameters as MouseButtonEventArgs) as Trademark;

            if (item == null)
                return;

            this.trademarkId = item.Id;
            this.TrademarkName = item.TrademarkName;
            this.OperationType = Enumeration.Operation.Update;
        }

        public override void OnSave()
        {
            if (string.IsNullOrEmpty(this.TrademarkName))
            {
                MessageBox.Show("Debe ingresar un nombre", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                string errorMessage = string.Empty;
                int error = 0;

                if (OperationType == Enumeration.Operation.Create)
                {
                    var result = Repository.InsTrademark(this.TrademarkName, ref error, ref errorMessage);

                    if (!result || error == -1)
                    {
                        MessageBox.Show("Error " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    MessageBox.Show("Datos guardados con exito ", "Datos Guardados", MessageBoxButton.OK, MessageBoxImage.Information);

                    Task.Run(() => this.Init());
                }
                else
                {
                    var result = Repository.UpdTrademark(this.trademarkId, this.TrademarkName, ref errorMessage);

                    if (!result)
                    {
                        MessageBox.Show("Error " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    MessageBox.Show("Datos modificados con exito ", "Datos modificados", MessageBoxButton.OK, MessageBoxImage.Information);
                    Task.Run(() => this.Init());
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                OnClean();
            }
        }

        public override void OnClean()
        {
            this.trademarkId = 0;
            this.TrademarkNameFilter = string.Empty;
            this.TrademarkName = string.Empty;
            this.OperationType = Enumeration.Operation.Create;
        }

        private void Init()
        {
            try
            {
                ItemList = Repository.GetTrademarks(string.Empty);
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

        private async Task<List<Trademark>> GetList()
        {
            await Task.Delay(100);

            List<Trademark> lst = new List<Trademark>();

            try
            {
                var aux = this.itemListAux;

                lst = aux.Where(
                      s =>
                         (
                          ((!string.IsNullOrEmpty(this.TrademarkNameFilter) ? s.TrademarkName.ToUpper().Contains(this.TrademarkNameFilter.ToUpper()) : true))
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
                if (this.trademarkId == 0)
                {
                    MessageBox.Show("Debe elegir una fila para eliminar ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                MessageBoxResult result = MessageBox.Show("¿Esta seguro de querer eliminar este elemento", "Eliminar elementos", MessageBoxButton.OKCancel, MessageBoxImage.Information);

                if (result == MessageBoxResult.OK)
                {
                    string errorMsg = string.Empty;
                    var res = Repository.DelTrademark(this.trademarkId, ref errorMsg);

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

