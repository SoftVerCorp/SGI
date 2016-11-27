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
    public class NewFamilyVM : ViewModelBase
    {
        #region Private Fields

        private string familyName;
        private int idFamily;        

        #endregion

        #region Public Fields

        public event EventHandler OnAddFamily;

        #endregion

        #region Constructors

        /// <summary>
        /// Representa una nueva instancia de la clase NewFamilyVM
        /// </summary>
        public NewFamilyVM()
        {
            try
            {
                this.TitleWindow = "Agregar Familia";
                this.OperationType = Enumeration.Operation.Create;
            }
            catch (Exception ex)
            {

            }
        }


        /// <summary>
        /// Representa una nueva instancia de la clase NewFamilyVM
        /// </summary>
        public NewFamilyVM(Families obj)
        {
            try
            {
                this.OperationType = Enumeration.Operation.Update;
                this.TitleWindow = "Modificar Familia";

                if (obj != null)
                {
                    this.FamilyName = obj.FamilyName;
                    this.idFamily = obj.Id;
                }
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


        /// <summary>
        /// Obtiene el comando que creara un nuevo elemento en el catalogo de familias.
        /// </summary>
        public ICommand CreateFamily
        {
            get
            {
                return new RelayCommand(s => this.OnAccept());
            }
        }





        #endregion

        #region Private Methods



        /// <summary>
        /// Ejecuta la accion para crear un nuevo elemento en el catalogo de familias.
        /// </summary>
        public override void OnAccept()
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

                    if (OnAddFamily != null)
                    {
                        OnAddFamily(true, null);
                    }
                }
                else
                {
                    var result = Repository.UpdFamily(this.idFamily, this.FamilyName, ref errorMessage);

                    if (result)
                    {
                        MessageBox.Show("Registro modificado con exito ", "Registro modificado", MessageBoxButton.OK, MessageBoxImage.Information);

                        if (OnAddFamily != null)
                        {
                            OnAddFamily(true, null);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error  " + errorMessage, "Registro modificado", MessageBoxButton.OK, MessageBoxImage.Error);
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
            this.FamilyName = string.Empty;
        }

        #endregion
    }
}

