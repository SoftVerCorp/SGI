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
    public class NewModelsVM : ViewModelBase
    {
        #region Private Fields

        private int modelId;
        private string modelName;

        #endregion

        #region Public Fields

        public event EventHandler OnAddModel;

        #endregion

        #region Constructors

        /// <summary>
        /// Representa una nueva instancia de la clase NewTrademarkVM
        /// </summary>
        public NewModelsVM()
        {
            this.TitleWindow = "Agregar Modelo";
            this.OperationType = Enumeration.Operation.Create;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public NewModelsVM(Models obj)
        {
            this.TitleWindow = "Modificar Modelo";
            this.OperationType = Enumeration.Operation.Update;

            if (obj != null)
            {
                this.ModelName = obj.Model;
                this.modelId = obj.Id;
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


        #endregion

        #region Private Methods



        /// <summary>
        /// Ejecuta la accion para crear un nuevo elemento en el catalogo de familias.
        /// </summary>
        public override void OnAccept()
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

                    if (OnAddModel != null)
                    {
                        OnAddModel(true, null);
                    }
                }
                else
                {
                    if (this.OperationType == Enumeration.Operation.Update)
                    {
                        var result = Repository.UpdModels(this.modelId, this.ModelName, ref errorMessage);

                        if (!result)
                        {
                            MessageBox.Show("Error modificando los datos" + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        MessageBox.Show("Datos modificados con exito ", "Datos modificados", MessageBoxButton.OK, MessageBoxImage.Information);

                        if (OnAddModel != null)
                        {
                            OnAddModel(true, null);
                        }
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
            this.ModelName = string.Empty;
        }

        #endregion
    }
}


