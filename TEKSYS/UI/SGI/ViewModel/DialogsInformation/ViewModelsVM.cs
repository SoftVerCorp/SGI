using SGI.Model;
using SGI.Stuffs;
using SGI.View;
using SGI.View.DialogsInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SGI.ViewModel.DialogsInformation
{
    public class ViewModelsVM : ViewModelBase
    {
        #region Private Fields

        private int modelId;

        private string modelNameFilter;
        private string modelName;

        private Models selectedItem;

        private List<Models> itemList;
        private List<Models> itemListAux;

        #endregion

        #region Public Fields

        //public event EventHandler<SelectedOfferTypeEventArgs> OnSelectedOfferType;

        #endregion

        #region Constructors

        /// <summary>
        /// Representa una nueva instancia de la clase ViewFamilyVM
        /// </summary>
        public ViewModelsVM()
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
        public string ModelName
        {
            get { return modelName; }
            set
            {
                if (modelName != value)
                {
                    modelName = value;
                    RaisePropertyChanged(() => ModelName);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece una lista de familias.
        /// </summary>
        public List<Models> ItemList
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
        public string ModelNameFilter
        {
            get { return modelNameFilter; }
            set
            {
                if (modelNameFilter != value)
                {
                    modelNameFilter = value;
                    RaisePropertyChanged(() => ModelNameFilter);
                    SearchAsync();
                }
            }
        }

        public Models SelectedItem
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
        public override void OnSave()
        {
            if (string.IsNullOrEmpty(this.ModelName))
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

                    var result = Repository.InsModels(this.ModelName, ref error, ref errorMessage);

                    if (!result || error == -1)
                    {
                        MessageBox.Show("Error " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    MessageBox.Show("Datos guardados con exito ", "Datos guardados", MessageBoxButton.OK, MessageBoxImage.Information);

                    Task.Run(() => this.Init());
                    OnClean();
                }
                else
                {
                    if (this.OperationType == Enumeration.Operation.Update)
                    {
                        if (this.modelId == 0)
                        {
                            MessageBox.Show("Debe seleccionar un modelo a actualizar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        var result = Repository.UpdModels(this.modelId, this.ModelName, ref errorMessage);

                        if (!result)
                        {
                            MessageBox.Show("Error modificando los datos" + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        MessageBox.Show("Datos modificados con exito ", "Datos modificados", MessageBoxButton.OK, MessageBoxImage.Information);
                        OnClean();
                        Task.Run(() => this.Init());

                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
               
            }
        }

        public override void OnClean()
        {
            this.modelId = 0;
            this.ModelName = string.Empty;
            this.OperationType = Enumeration.Operation.Create;
        }

        public override void OnSelectedItemGridClick(object parameters)
        {
            var item = Helpers.DataGridRowHelper.GetDatagridRow(parameters as MouseButtonEventArgs) as Models;

            if (item == null)
                return;

            this.modelId = item.Id;
            this.ModelName = item.Model;
            this.OperationType = Enumeration.Operation.Update;
        }

        private void Init()
        {
            try
            {
                ItemList = Repository.GetModels(string.Empty);
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

        private async Task<List<Models>> GetList()
        {
            await Task.Delay(100);

            List<Models> lst = new List<Models>();

            try
            {
                var aux = this.itemListAux;

                lst = aux.Where(
                      s =>
                         (
                          ((!string.IsNullOrEmpty(this.ModelNameFilter) ? s.Model.ToUpper().Contains(this.ModelNameFilter.ToUpper()) : true))
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
                if (this.modelId == 0)
                {
                    MessageBox.Show("Debe elegir una fila para eliminar ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                MessageBoxResult result = MessageBox.Show("¿Esta seguro de querer eliminar este elemento", "Eliminar elementos", MessageBoxButton.OKCancel, MessageBoxImage.Information);

                if (result == MessageBoxResult.OK)
                {
                    string errorMsg = string.Empty;

                    var res = Repository.DelModels(this.modelId, ref errorMsg);

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
