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
    public class NewProviderVM : ViewModelBase
    {
        #region Private Fields

        private int providerId;
        private string name;
        private string rfc;
        private string address;

        #endregion

        #region Public Properties

        public event EventHandler OnAddProviders;


        #endregion

        #region Constructors

        /// <summary>
        ///  Representa una nueva instancia de la clase NewProductVM
        /// </summary>
        public NewProviderVM()
        {
            try
            {
                this.OperationType = Enumeration.Operation.Create;
                this.TitleWindow = "Agregar nuevo proveedor";
            }
            catch (Exception ex)
            {

            }
        }


        /// <summary>
        ///  Representa una nueva instancia de la clase NewProductVM
        /// </summary>
        public NewProviderVM(Provider provider)
        {
            try
            {
                OperationType = Enumeration.Operation.Update;
                this.TitleWindow = "Modificar Proveedor";

                if (provider != null)
                {
                    this.providerId = provider.Id;
                    this.name = provider.Name;
                    this.address = provider.Address;
                    this.rfc = provider.Rfc;
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region Public Properties


        /// <summary>
        /// Obtiene o establece el nombre del proveedor.
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

        /// <summary>
        /// Obtiene o establece la direccion
        /// </summary>
        public string Address
        {
            get { return address; }
            set
            {
                if (address != value)
                {
                    address = value;
                    RaisePropertyChanged(() => Address);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece la clave del teknobike
        /// </summary>
        public string RFC
        {
            get { return rfc; }
            set
            {
                if (rfc != value)
                {
                    rfc = value;
                    RaisePropertyChanged(() => RFC);
                }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Guarda un nuevo elemento en el catalogo de productos.
        /// </summary>
        public override void OnAccept()
        {
            if (string.IsNullOrEmpty(this.Name))
            {
                MessageBox.Show("Debe ingreasar un nombre", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(this.RFC))
            {
                MessageBox.Show("Debe ingresar el RFC", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            try
            {
                string errorMessage = string.Empty;
                int error = 0;

                Provider provider = new Provider();
                provider.Id = this.providerId;
                provider.Name = this.Name;
                provider.Rfc = this.RFC;
                provider.Address = this.Address;


                if (this.OperationType == Enumeration.Operation.Create)
                {
                    var result = Repository.InsProvider(provider, ref error, ref errorMessage);

                    if (!result || error == -1)
                    {
                        MessageBox.Show("Error " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    MessageBox.Show("Datos guardados con exito ", "Datos Guardados", MessageBoxButton.OK, MessageBoxImage.Information);

                    if (OnAddProviders != null)
                    {
                        OnAddProviders(true, null);
                    }
                }
                else
                {
                    if (this.OperationType == Enumeration.Operation.Update)
                    {
                        var res = Repository.UpdProviders(provider, ref errorMessage);

                        if (res)
                        {
                            MessageBox.Show("Datos modificados con exito ", "Datos Modificados", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }

                if (OnAddProviders != null)
                {
                    OnAddProviders(this, null);
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
        /// Cierra la ventana
        /// </summary>
        public override void OnClose()
        {
            try
            {
                if (thisWindow != null)
                {
                    this.thisWindow.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Limpiar los controles.
        /// </summary>

        private void Clean()
        {

        }

        #endregion
    }
}
