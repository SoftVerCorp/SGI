using SGI.Model;
using SGI.Stuffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SGI.ViewModel
{
    public class NewTrademarkVM : ViewModelBase
    {
        #region Private Fields

        private int trademarkId;

        private string trademarkName;


        #endregion

        #region Public Fields

        public event EventHandler OnAddTrademark;

        #endregion


        #region Constructors

        /// <summary>
        /// Representa una nueva instancia de la clase NewTrademarkVM
        /// </summary>
        public NewTrademarkVM()
        {
            this.TitleWindow = "Agregar Marca";
            this.OperationType = Enumeration.Operation.Create;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public NewTrademarkVM(Trademark obj)
        {
            this.TitleWindow = "Modificar Marca";
            this.OperationType = Enumeration.Operation.Update;

            if (obj != null)
            {
                this.TrademarkName = obj.TrademarkName;
                this.trademarkId = obj.Id;
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


        #endregion

        #region Private Methods



        /// <summary>
        /// Ejecuta la accion para crear un nuevo elemento en el catalogo de familias.
        /// </summary>
        public override void OnAccept()
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

                    if (OnAddTrademark != null)
                    {
                        OnAddTrademark(true, null);
                    }
                }
                else
                {
                    var result = Repository.UpdTrademark(this.trademarkId, this.TrademarkName, ref errorMessage);

                    if(result)
                    {
                        MessageBox.Show("Datos modificados con exito ", "Datos modificados", MessageBoxButton.OK, MessageBoxImage.Information);

                        if (OnAddTrademark != null)
                        {
                            OnAddTrademark(true, null);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                OnClose();
            }
        }




        /// <summary>
        /// Limpiar el texto despues de guardar los datos.
        /// </summary>
        private void CleanText()
        {
            this.TrademarkName = string.Empty;
        }

        #endregion
    }
}
