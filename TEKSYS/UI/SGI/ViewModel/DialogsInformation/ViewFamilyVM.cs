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
    public class ViewFamilyVM : ViewModelBase
    {
        #region Private Fields

        private int idFamily;
        private string familyName;
        private string familyNameFilter;

        private Families selectedItem;

        private List<Families> familyList;
        private List<Families> familyListAux;

        #endregion

        #region Public Fields

        //public event EventHandler<SelectedOfferTypeEventArgs> OnSelectedOfferType;

        #endregion

        #region Constructors

        /// <summary>
        /// Representa una nueva instancia de la clase ViewFamilyVM
        /// </summary>
        public ViewFamilyVM()
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
        public string FamilyNameFilter
        {
            get { return familyNameFilter; }
            set
            {

                if (familyNameFilter != value)
                {
                    familyNameFilter = value;
                    RaisePropertyChanged(() => FamilyNameFilter);
                    SearchAsync();
                }
            }
        }

        /// <summary>
        /// Obtiene o establece una lista de familias.
        /// </summary>
        public List<Families> FamilyList
        {
            get { return familyList; }
            set
            {
                if (familyList != value)
                {
                    familyList = value;
                    RaisePropertyChanged(() => FamilyList);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece el nombre de la familia
        /// </summary>
        public string FamilyName
        {
            get { return familyName; }
            set
            {
                if (familyName != value)
                {
                    familyName = value;
                    RaisePropertyChanged(() => FamilyName);

                }
            }
        }

        public Families SelectedItem
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

        public override void OnClean()
        {
            this.OperationType = Enumeration.Operation.Create;
            this.FamilyName = string.Empty;
            this.idFamily = 0;
        }

        /// <summary>
        /// Selecciona una fila del grid
        /// </summary>
        /// <param name="parameters"></param>
        public override void OnSelectedItemGridClick(object parameters)
        {
            var item = Helpers.DataGridRowHelper.GetDatagridRow(parameters as MouseButtonEventArgs) as Families;

            if (item == null)
                return;

            this.idFamily = item.Id;
            this.FamilyName = item.FamilyName;
            this.OperationType = Enumeration.Operation.Update;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void OnSave()
        {
            if (string.IsNullOrEmpty(this.FamilyName))
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

                    var result = Repository.InsFamily(this.FamilyName, ref error, ref errorMessage);

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
                    var result = Repository.UpdFamily(this.idFamily, this.FamilyName, ref errorMessage);


                    if (!result)
                    {
                        MessageBox.Show("Error  " + errorMessage, "Registro modificado", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    MessageBox.Show("Registro modificado con exito ", "Registro modificado", MessageBoxButton.OK, MessageBoxImage.Information);
                    Task.Run(() => this.Init());
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                OnClean();
                //  OnClose();
            }
        }

        private void Init()
        {
            try
            {
                FamilyList = Repository.GetFamilies(string.Empty);
                familyListAux = FamilyList;
            }
            catch (Exception ex)
            {

            }
        }

        public async void SearchAsync()
        {
            try
            {
                this.FamilyList = await Task.Run(() => this.GetList());
            }
            catch (Exception ex)
            {

            }
        }

        private async Task<List<Families>> GetList()
        {
            await Task.Delay(100);

            List<Families> lst = new List<Families>();

            try
            {
                var aux = this.familyListAux;

                lst = aux.Where(
                      s =>
                         (
                          ((!string.IsNullOrEmpty(this.FamilyNameFilter) ? s.FamilyName.ToUpper().Contains(this.FamilyNameFilter.ToUpper()) : true))
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

                MessageBoxResult result = MessageBox.Show("¿Esta seguro de querer eliminar este elemento", "Eliminar elementos", MessageBoxButton.OKCancel, MessageBoxImage.Information);

                if (result == MessageBoxResult.OK)
                {
                    if (this.idFamily == 0)
                    {
                        MessageBox.Show("Debe elegir una fila para eliminar ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    string errorMsg = string.Empty;
                    var res = Repository.DelFamily(this.idFamily, ref errorMsg);

                    if (!res)
                    {
                        MessageBox.Show("Error al eliminar el dato " + errorMsg, "Dato eliminado", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    MessageBox.Show("Elemento eliminado", "Dato eliminado", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    Task.Run(() => this.Init());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                OnClean();
            }
        }



        #endregion
    }
}

