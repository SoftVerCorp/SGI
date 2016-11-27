using SGI.Classes;
using SGI.Model;
using SGI.Stuffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SGI.ViewModel.DialogsInformation
{
    public class ViewOfferTypeVM : ViewModelBase
    {
        #region Private Fields

        private int typeOfferId;

        private string offerTypeNameFilter;
        private string typeOfferName;

        private List<OfferType> offerTypeList;
        private List<OfferType> offerTypeListAux;

        #endregion

        #region Constructors

        /// <summary>
        /// Representa una nueva instancia de la clase NewCoinsVM
        /// </summary>
        public ViewOfferTypeVM()
        {
            try
            {
                this.OperationType = Enumeration.Operation.Create;
                this.Init();
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
        public string TypeOfferName
        {
            get { return typeOfferName; }
            set
            {
                if (typeOfferName != value)
                {
                    typeOfferName = value;
                    RaisePropertyChanged(() => TypeOfferName);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece una lista de tipos de ofertas.
        /// </summary>
        public List<OfferType> OfferTypeList
        {
            get { return offerTypeList; }
            set
            {
                if (offerTypeList != value)
                {
                    offerTypeList = value;
                    RaisePropertyChanged(() => OfferTypeList);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece el nombre de la moneda.
        /// </summary>
        public string OfferTypeNameFilter
        {
            get { return offerTypeNameFilter; }
            set
            {
                if (offerTypeNameFilter != value)
                {
                    offerTypeNameFilter = value;
                    RaisePropertyChanged(() => OfferTypeNameFilter);
                    SearchAsync();
                }
            }
        }


        #endregion

        #region Private Methods

        public override void OnDeleteItem(object param)
        {
            try
            {
                if (this.typeOfferId == 0)
                {
                    MessageBox.Show("Debe elegir una fila para eliminar ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                MessageBoxResult result = MessageBox.Show("¿Esta seguro de querer eliminar este elemento", "Eliminar elementos", MessageBoxButton.OKCancel, MessageBoxImage.Information);

                if (result == MessageBoxResult.OK)
                {

                    string errorMsg = string.Empty;
                    var res = Repository.DelOfferType(this.typeOfferId);

                    if (!res)
                    {
                        MessageBox.Show("Error al eliminar el dato " + errorMsg, "Dato eliminado", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    MessageBox.Show("Elemento eliminado", "Dato eliminado", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                OnClean();
                Init();
            }
        }

        public override void OnSelectedItemGridClick(object parameters)
        {
            var item = Helpers.DataGridRowHelper.GetDatagridRow(parameters as MouseButtonEventArgs) as OfferType;

            if (item == null)
                return;

            this.typeOfferId = item.Id;
            this.TypeOfferName = item.OfferTypeName;
            this.OperationType = Enumeration.Operation.Update;
        }

        public override void OnSave()
        {
            if (string.IsNullOrEmpty(this.TypeOfferName))
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
                    var result = Repository.InsOfferType(this.TypeOfferName, ref error, ref errorMessage);

                    if (!result)
                    {
                        MessageBox.Show("Error " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    MessageBox.Show("Datos guardados con exito ", "Datos Guardados", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else
                {
                    if (OperationType == Enumeration.Operation.Update)
                    {
                        var result = Repository.UpdOfferType(this.typeOfferId, this.TypeOfferName);

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
                OnClean();
                Init();
            }
        }

        public override void OnClean()
        {
            this.typeOfferId = 0;
            this.TypeOfferName = string.Empty;
            this.OperationType = Enumeration.Operation.Create;
            this.OfferTypeNameFilter = string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        public async void SearchAsync()
        {
            try
            {
                this.OfferTypeList = await Task.Run(() => this.GetList());
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private async Task<List<OfferType>> GetList()
        {
            await Task.Delay(100);

            List<OfferType> lst = new List<OfferType>();

            try
            {
                var aux = this.offerTypeListAux;

                lst = aux.Where(
                      s =>
                         (
                          ((!string.IsNullOrEmpty(this.OfferTypeNameFilter) ? s.OfferTypeName.ToUpper().Contains(this.OfferTypeNameFilter.ToUpper()) : true))
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
        /// 
        /// </summary>
        private void Init()
        {
            try
            {
                Task.Run(() =>
                {
                    this.OfferTypeList = Repository.GetOfferType(string.Empty);
                    this.offerTypeListAux = OfferTypeList;
                });
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Ejecuta la accion para crear un nuevo elemento en el catalogo de familias.
        /// </summary>
        public override void OnAccept()
        {
            try
            {
                OnClose();
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        #endregion
    }
}
