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
    public class ViewPaymentConditionVM : ViewModelBase
    {
        #region Private Fields

        private int id;

        private string name;
        private string paymentConditionName;

        private PaymentCondition selectedItem;

        private List<PaymentCondition> itemList;
        private List<PaymentCondition> itemListAux;

        #endregion

        #region Public Fields

        #endregion

        #region Constructors

        /// <summary>
        /// Representa una nueva instancia de la clase ViewPaymentConditionVM
        /// </summary>
        public ViewPaymentConditionVM()
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
        /// 
        /// </summary>
        public string PaymentConditionName
        {
            get { return paymentConditionName; }
            set
            {
                if (paymentConditionName != value)
                {
                    paymentConditionName = value;
                    RaisePropertyChanged(() => PaymentConditionName);
                }
            }
        }


        /// <summary>
        /// Obtiene o establece una lista de familias.
        /// </summary>
        public List<PaymentCondition> ItemList
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
        public PaymentCondition SelectedItem
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        public override void OnSelectedItemGridClick(object parameters)
        {
            var item = Helpers.DataGridRowHelper.GetDatagridRow(parameters as MouseButtonEventArgs) as PaymentCondition;

            if (item == null)
                return;

            this.id = item.Id;
            this.PaymentConditionName = item.Name;
            this.OperationType = Enumeration.Operation.Update;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void OnSave()
        {
            if (string.IsNullOrEmpty(this.PaymentConditionName))
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
                    var result = Repository.InsPaymentCondition(this.PaymentConditionName, ref error, ref errorMessage);

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
                        var result = Repository.UpdPaymentCondition(this.id, this.PaymentConditionName, ref errorMessage);

                        if (!result)
                        {
                            MessageBox.Show("Error " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        MessageBox.Show("Datos modificados con exito ", "Datos modificados", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }

                //if (OnAddPaymentCondition != null)
                //{
                //    OnAddPaymentCondition(true, null);
                //}

            }
            catch (Exception ex)
            {

            }
            finally
            {
                OnClean();
                Task.Run(() => { this.Init(); });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void OnClean()
        {
            this.id = 0;
            this.PaymentConditionName = string.Empty;
            this.OperationType = Enumeration.Operation.Create;
        }

        private void Init()
        {
            try
            {
                ItemList = Repository.GetPaymentConditions(string.Empty);
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

        private async Task<List<PaymentCondition>> GetList()
        {
            await Task.Delay(100);

            List<PaymentCondition> lst = new List<PaymentCondition>();

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
                NewPaymentConditionView view = new NewPaymentConditionView();
                NewPaymentConditionVM viewModel = new NewPaymentConditionVM();
                viewModel.OnAddPaymentCondition += OnAddPaymentCondition;
                view.DataContext = viewModel;
                view.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void OnAddPaymentCondition(object sender, EventArgs e)
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
                if (this.id == 0)
                {
                    MessageBox.Show("Debe elegir una fila para eliminar ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                MessageBoxResult result = MessageBox.Show("¿Esta seguro de querer eliminar este elemento", "Eliminar elementos", MessageBoxButton.OKCancel, MessageBoxImage.Information);

                if (result == MessageBoxResult.OK)
                {
                    string errorMsg = string.Empty;
                    var res = Repository.DelPaymentCondition(this.id, ref errorMsg);

                    if (res)
                    {
                        MessageBox.Show("Elemento eliminado", "Dato eliminado", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                        Task.Run(() => this.Init());
                        this.OnClean();
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
                PaymentCondition model = param as PaymentCondition;

                if (model == null)
                {
                    MessageBox.Show("Debe elegir una fila para modificar ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                NewPaymentConditionView view = new NewPaymentConditionView();
                NewPaymentConditionVM viewModel = new NewPaymentConditionVM(model);
                viewModel.OnAddPaymentCondition += OnAddPaymentCondition;
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


