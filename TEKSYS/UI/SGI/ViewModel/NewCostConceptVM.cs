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
    public class NewCostConceptVM : ViewModelBase
    {
        #region Private Fields

        private string costName;

        private int costeConceptId;

        #endregion

        #region Public Fields

        public event EventHandler OnAddCosteConcept;

        #endregion


        #region Constructors

        /// <summary>
        /// Representa una nueva instancia de la clase NewCoinsVM
        /// </summary>
        public NewCostConceptVM()
        {
            this.TitleWindow = "Agregar nuevo concepto de costo";
            this.OperationType = Enumeration.Operation.Create;
        }

        /// <summary>
        /// Representa una nueva instancia de la clase NewCoinsVM
        /// </summary>
        public NewCostConceptVM(CosteConcept model)
        {
            this.TitleWindow = "modificar concepto de costo";
            this.OperationType = Enumeration.Operation.Update;

            if (model != null)
            {
                this.CostName = model.ConceptName;
                this.costeConceptId = model.Id;
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


        #endregion

        #region Private Methods

        /// <summary>
        /// Ejecuta la accion para crear un nuevo elemento en el catalogo de familias.
        /// </summary>
        public override void OnAccept()
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
                    
                    OnAddCosteConcept(true, null);
                }
                else
                {
                    if (OperationType == Enumeration.Operation.Update)
                    {
                        var result = Repository.UpdCosteConcept(this.costeConceptId,this.CostName, ref errorMessage);

                        if (!result || error == -1)
                        {
                            MessageBox.Show("Error " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        MessageBox.Show("Datos modificados con exito ", "Datos modificados", MessageBoxButton.OK, MessageBoxImage.Information);
                        
                        OnAddCosteConcept(true, null);
                    }
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
            this.CostName = string.Empty;
        }

        #endregion
    }
}
