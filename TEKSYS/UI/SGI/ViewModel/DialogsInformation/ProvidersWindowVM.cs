using SGI.Classes;
using SGI.Stuffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.ViewModel.DialogsInformation
{
    public class ProvidersWindowVM : ViewModelBase
    {
        #region Private Fields

        private ViewProvidersVM viewProvidersVM;

        #endregion

        #region Public Fields

        public event EventHandler<SelectedProviderEventArgs> OnSelectedProvider;

        #endregion

        #region Constructors

        /// <summary>
        /// Representa una nueva instancia de la clase ProvidersWindowVM
        /// </summary>
        public ProvidersWindowVM(ViewProvidersVM param)
        {
            try
            {
                this.ViewProvidersVM = param;
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
        public ViewProvidersVM ViewProvidersVM
        {
            get { return viewProvidersVM; }
            set
            {
                if (viewProvidersVM != value)
                {
                    viewProvidersVM = value;
                    RaisePropertyChanged(() => ViewProvidersVM);
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
            if (this.ViewProvidersVM == null)
                return;
            try
            {
                if (OnSelectedProvider != null)
                {
                    OnSelectedProvider(this, new SelectedProviderEventArgs(this.ViewProvidersVM.SelectedItem));
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.OnClose();
            }
        }

        #endregion
    }
}
