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
    public class ViewCostConceptVM : ViewModelBase
    {
        #region Private Fields

        private int costeConceptId;

        private string costName;
        private string costeConceptNameFilter;

        private CosteConcept selectedItem;

        private List<CosteConcept> itemList;
        private List<CosteConcept> itemListAux;

        #endregion

        #region Public Fields

        //public event EventHandler<SelectedOfferTypeEventArgs> OnSelectedOfferType;

        #endregion

        #region Constructors

        /// <summary>
        /// Representa una nueva instancia de la clase ViewFamilyVM
        /// </summary>
        public ViewCostConceptVM()
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
        /// Obtiene o establece el nombre del costo concepto.
        /// </summary>
        public string CostName
        {
            get { return costName; }
            set
            {
                if (costName != value)
                {
                    costName = value;
                    RaisePropertyChanged(() => CostName);
                }
            }
        }


        /// <summary>
        /// Obtiene o establece una lista de familias.
        /// </summary>
        public List<CosteConcept> ItemList
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
        public string CosteConceptNameFilter
        {
            get { return costeConceptNameFilter; }
            set
            {
                if (costeConceptNameFilter != value)
                {
                    costeConceptNameFilter = value;
                    RaisePropertyChanged(() => CosteConceptNameFilter);
                    SearchAsync();
                }
            }
        }

        public CosteConcept SelectedItem
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
            var item = Helpers.DataGridRowHelper.GetDatagridRow(parameters as MouseButtonEventArgs) as CosteConcept;

            if (item == null)
                return;

            this.costeConceptId = item.Id;
            this.CostName = item.ConceptName;
            this.OperationType = Enumeration.Operation.Update;
        }

        public override void OnClean()
        {
            this.costeConceptId = 0;
            this.CostName = string.Empty;
            this.OperationType = Enumeration.Operation.Create;
        }

        public override void OnSave()
        {
            if (string.IsNullOrEmpty(this.CostName))
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
                    var result = Repository.InsCostConcept(this.CostName, ref error, ref errorMessage);

                    if (!result || error == -1)
                    {
                        MessageBox.Show("Error " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    MessageBox.Show("Datos guardados con exito ", "Datos Guardados", MessageBoxButton.OK, MessageBoxImage.Information);

                    //  OnAddCosteConcept(true, null);
                }
                else
                {
                    if (OperationType == Enumeration.Operation.Update)
                    {
                        var result = Repository.UpdCosteConcept(this.costeConceptId, this.CostName, ref errorMessage);

                        if (!result || error == -1)
                        {
                            MessageBox.Show("Error " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        MessageBox.Show("Datos modificados con exito ", "Datos modificados", MessageBoxButton.OK, MessageBoxImage.Information);

                        // OnAddCosteConcept(true, null);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.OnClean();
                Task.Run(() => { Init(); });
            }
        }

        private void Init()
        {
            try
            {
                ItemList = Repository.GetCosteConcept(string.Empty);
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

        private async Task<List<CosteConcept>> GetList()
        {
            await Task.Delay(100);

            List<CosteConcept> lst = new List<CosteConcept>();

            try
            {
                var aux = this.itemListAux;

                lst = aux.Where(
                      s =>
                         (
                          ((!string.IsNullOrEmpty(this.CosteConceptNameFilter) ? s.ConceptName.ToUpper().Contains(this.CosteConceptNameFilter.ToUpper()) : true))
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



        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="param"></param>
        //public override void OnAddItem(object param)
        //{
        //    try
        //    {

        //        NewCostConcept ntv = new NewCostConcept();
        //        NewCostConceptVM nvm = new NewCostConceptVM();
        //        nvm.OnAddCosteConcept += OnAddCosteConcept;
        //        ntv.DataContext = nvm;
        //        ntv.Show();
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}



        //private void OnAddCosteConcept(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Task.Run(() => this.Init());
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public override void OnDeleteItem(object param)
        {
            try
            {

                if (this.costeConceptId == 0)
                {
                    MessageBox.Show("Debe elegir una fila para eliminar ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                MessageBoxResult result = MessageBox.Show("¿Esta seguro de querer eliminar este elemento", "Eliminar elementos", MessageBoxButton.OKCancel, MessageBoxImage.Information);

                if (result == MessageBoxResult.OK)
                {

                    string errorMsg = string.Empty;
                    var res = Repository.DelCosteConcept(this.costeConceptId, ref errorMsg);

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

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="param"></param>
        //public override void OnUpdateItem(object param)
        //{
        //    try
        //    {
        //        CosteConcept coste = param as CosteConcept;

        //        NewCostConcept ntv = new NewCostConcept();
        //        NewCostConceptVM nvm = new NewCostConceptVM(coste);
        //        nvm.OnAddCosteConcept += OnAddCosteConcept;
        //        ntv.DataContext = nvm;
        //        ntv.Show();
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        #endregion
    }
}