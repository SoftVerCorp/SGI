using SGI.Model;
using SGI.Stuffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SGI.ViewModel
{
    public class NewCoinsVM : ViewModelBase
    {
        #region Private Fields

        private int coinsId;

        private string coinsName;

        #endregion

        #region Public Fields

        public event EventHandler OnAddCoin;

        #endregion

        #region Constructors

        /// <summary>
        /// Representa una nueva instancia de la clase NewCoinsVM
        /// </summary>
        public NewCoinsVM()
        {
            this.TitleWindow = "Agregar nueva moneda";
            this.OperationType = Enumeration.Operation.Create;
        }

        /// <summary>
        /// Representa una nueva instancia de la clase NewCoinsVM
        /// </summary>
        public NewCoinsVM(Coin obj)
        {
            this.TitleWindow = "Modificar moneda";
            this.OperationType = Enumeration.Operation.Update;

            if (obj != null)
            {
                this.CoinsName = obj.CoinName;
                this.coinsId = obj.Id;
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


        #endregion

        #region Private Methods

        /// <summary>
        /// Ejecuta la accion para crear un nuevo elemento en el catalogo de familias.
        /// </summary>
        public override void OnAccept()
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
                    OnAddCoin(true, null);
                }
                else
                {
                    if(this.OperationType == Enumeration.Operation.Update)
                    {
                        var result = Repository.UpdCoins(this.coinsId, this.CoinsName, ref errorMessage);

                        if (!result)
                        {
                            MessageBox.Show("Error " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        MessageBox.Show("Datos modificados con exito ", "Datos modificados", MessageBoxButton.OK, MessageBoxImage.Information);
                        
                        OnAddCoin(true, null);
                    }
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.CleanText();
            }
        }

        /// <summary>
        /// Limpiar el texto despues de guardar los datos.
        /// </summary>
        private void CleanText()
        {
            this.CoinsName = string.Empty;
        }

        #endregion
    }
}



