using SGI.Classes;
using SGI.Stuffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.ViewModel.DialogsInformation
{
    public class EmployeeWindowVM : ViewModelBase
    {
        #region Private Fields

        private ViewEmployeesVM viewEmployeesVM;

        #endregion

        #region Public Fields

        public event EventHandler<SelectedEmployeeEventArgs> OnSelectedEmployee;

        #endregion

        #region Constructors

        /// <summary>
        /// Representa una nueva instancia de la clase EmployeeWindowVM
        /// </summary>
        public EmployeeWindowVM(ViewEmployeesVM param)
        {
            try
            {
                this.ViewEmployeesVM = param;
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
        public ViewEmployeesVM ViewEmployeesVM
        {
            get { return viewEmployeesVM; }
            set
            {
                if (viewEmployeesVM != value)
                {
                    viewEmployeesVM = value;
                    RaisePropertyChanged(() => ViewEmployeesVM);
                }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// 
        /// </summary>
        public override void OnAccept()
        {
            if (this.ViewEmployeesVM == null)
                return;
            try
            {
                if (OnSelectedEmployee != null)
                {
                    OnSelectedEmployee(this, new SelectedEmployeeEventArgs(this.ViewEmployeesVM.SelectedItem));
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


