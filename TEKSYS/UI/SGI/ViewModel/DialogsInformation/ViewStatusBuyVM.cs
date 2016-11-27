using SGI.Model;
using SGI.Stuffs;
using SGI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SGI.ViewModel.DialogsInformation
{
    public class ViewStatusBuyVM : ViewModelBase
    {
        #region Private Fields

        private string name;

        private StatusBuy selectedItem;

        private List<StatusBuy> itemList;
        private List<StatusBuy> itemListAux;

        #endregion

        #region Public Fields

        #endregion

        #region Constructors

        /// <summary>
        /// Representa una nueva instancia de la clase ViewPaymentConditionVM
        /// </summary>
        public ViewStatusBuyVM()
        {
            try
            {
                Init();
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Obtiene o establece una lista de familias.
        /// </summary>
        public List<StatusBuy> ItemList
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
        /// Obtiene o establece el nombre de la forma de pago
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
        /// 
        /// </summary>
        public StatusBuy SelectedItem
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

        private void Init()
        {
            try
            {
                ItemList = Repository.GetStatusBuy(string.Empty);
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

        private async Task<List<StatusBuy>> GetList()
        {
            await Task.Delay(100);

            List<StatusBuy> lst = new List<StatusBuy>();

            try
            {
                var aux = this.itemListAux;

                lst = aux.Where(
                      s =>
                         (
                          ((!string.IsNullOrEmpty(this.Name) ? s.Name.ToUpper().Contains(this.Name.ToUpper()) : true))
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
        /// Ejecuta la accion para crear un nuevo elemento en el catalogo de concepto de pago.
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
        /// Limpiar el texto despues de guardar los datos.
        /// </summary>
        private void CleanText()
        {
            this.Name = string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public override void OnAddItem(object param)
        {
            try
            {
                NewStatusBuyView view = new NewStatusBuyView();
                NewStatusBuyVM viewModel = new NewStatusBuyVM();
                viewModel.OnAddStatusBuy += OnAddStatusBuy;
                view.DataContext = viewModel;
                view.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void OnAddStatusBuy(object sender, EventArgs e)
        {
            try
            {
                Task.Run(() => this.Init());
            }
            catch (Exception ex)
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
                if (param == null)
                {
                    MessageBox.Show("Debe elegir una fila para eliminar ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                StatusBuy obj = param as StatusBuy;

                MessageBoxResult result = MessageBox.Show("¿Esta seguro de querer eliminar este elemento", "Eliminar elementos", MessageBoxButton.OKCancel, MessageBoxImage.Information);

                if (result == MessageBoxResult.OK)
                {
                    string errorMsg = string.Empty;

                    var res = Repository.DelStatusBuy(obj.Id, ref errorMsg);

                    if (res)
                    {
                        MessageBox.Show("Elemento eliminado", "Dato eliminado", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                        Task.Run(() => this.Init());
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el dato " + errorMsg, "Dato eliminado", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public override void OnUpdateItem(object param)
        {
            try
            {
                StatusBuy model = param as StatusBuy;

                if (model == null)
                {
                    MessageBox.Show("Debe elegir una fila para modificar ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                NewStatusBuyView view = new NewStatusBuyView();
                NewStatusBuyVM viewModel = new NewStatusBuyVM(model);
                viewModel.OnAddStatusBuy += OnAddStatusBuy;
                view.DataContext = viewModel;
                view.Show();
            }
            catch (Exception ex)
            {

            }
        }

        #endregion
    }
}
