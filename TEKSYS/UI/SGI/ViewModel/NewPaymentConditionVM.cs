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
    public class NewPaymentConditionVM : ViewModelBase
    {
        #region Private Fields

        private int id;

        private string name;

        #endregion

        #region Public Fields

        public event EventHandler OnAddPaymentCondition;

        #endregion

        #region Constructors

        /// <summary>
        /// Representa una nueva instancia de la clase NewCoinsVM
        /// </summary>
        public NewPaymentConditionVM()
        {
            this.TitleWindow = "Agregar nueva condición de pago";
            this.OperationType = Enumeration.Operation.Create;
        }

        /// <summary>
        /// Representa una nueva instancia de la clase NewCoinsVM
        /// </summary>
        public NewPaymentConditionVM(PaymentCondition obj)
        {
            this.TitleWindow = "Modificar condición de pago";
            this.OperationType = Enumeration.Operation.Update;

            if (obj != null)
            {
                this.Name = obj.Name;
                this.id = obj.Id;
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Obtiene o establece el nombre de la condicion de pago.
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
            if (string.IsNullOrEmpty(this.Name))
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
                    var result = Repository.InsPaymentCondition(this.Name, ref error, ref errorMessage);

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
                        var result = Repository.UpdPaymentCondition(this.id, this.Name, ref errorMessage);

                        if (!result)
                        {
                            MessageBox.Show("Error " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        MessageBox.Show("Datos modificados con exito ", "Datos modificados", MessageBoxButton.OK, MessageBoxImage.Information);                        
                    }
                }

                if (OnAddPaymentCondition != null)
                {
                    OnAddPaymentCondition(true, null);
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.CleanText();
                OnClose();
            }
        }

        /// <summary>
        /// Limpiar el texto despues de guardar los datos.
        /// </summary>
        private void CleanText()
        {
            this.Name = string.Empty;
        }

        #endregion
    }
}



