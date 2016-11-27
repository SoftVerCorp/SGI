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
    public class NewOfferTypeVM : ViewModelBase
    {
        #region Private Fields

        private string typeOfferName;

        #endregion

        #region Constructors

        /// <summary>
        /// Representa una nueva instancia de la clase NewCoinsVM
        /// </summary>
        public NewOfferTypeVM()
        {

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


        #endregion

        #region Private Methods

        /// <summary>
        /// Ejecuta la accion para crear un nuevo elemento en el catalogo de familias.
        /// </summary>
        public override void OnAccept()
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

                var result = Repository.InsOfferType(this.TypeOfferName, ref error, ref errorMessage);

                if (!result || error == -1)
                {
                    MessageBox.Show("Error " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                MessageBox.Show("Datos guardados con exito ", "Datos Guardados", MessageBoxButton.OK, MessageBoxImage.Information);

                OnClose();
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
            this.TypeOfferName = string.Empty;
        }

        #endregion
    }
}

