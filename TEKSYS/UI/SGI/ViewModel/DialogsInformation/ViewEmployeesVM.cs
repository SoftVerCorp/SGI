using SGI.Helpers;
using SGI.Model;
using SGI.Stuffs;
using SGI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SGI.ViewModel.DialogsInformation
{
    public class ViewEmployeesVM : ViewModelBase
    {
        #region Private Fields

        private string name;

        private DateTime? beginHireDate;
        private DateTime? endHireDate;

        private Empleado selectedItem;

        private List<Empleado> itemList;
        private List<Empleado> itemListAux;

        #endregion

        #region Constructors

        /// <summary>
        /// Representa una nueva instancia de la clase NewCoinsVM
        /// </summary>
        public ViewEmployeesVM()
        {
            try
            {
                this.ItemList = Repository.GetEmployees(string.Empty,ManejadorUbicacion.IdUbicacion);
                this.itemListAux = this.ItemList;
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
        public Empleado SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                RaisePropertyChanged(() => SelectedItem);
            }
        }

        /// <summary>
        /// Obtiene o establece el filtro por nombre del empleado
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
                    SearchAsync();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? EndHireDate
        {
            get { return endHireDate; }
            set
            {
                if (endHireDate != value)
                {
                    endHireDate = value;
                    RaisePropertyChanged(() => EndHireDate);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? BeginHireDate
        {
            get { return beginHireDate; }
            set
            {
                if (beginHireDate != value)
                {
                    beginHireDate = value;
                    RaisePropertyChanged(() => BeginHireDate);
                }
            }
        }


        /// <summary>
        /// Obtiene o establece una lista de proveedores
        /// </summary>
        public List<Empleado> ItemList
        {
            get { return itemList; }
            set
            {
                if (itemList != value)
                {
                    itemList = value;
                    RaisePropertyChanged(() => ItemList);
                }
            }
        }

        public ICommand Refresh
        {
            get
            {
                return new RelayCommand(s => this.OnRefresh());
            }
        }

        #endregion

        #region Private Methods

        public override void OnDeleteItem(object param)
        {
            try
            {
                Empleado obj = param as Empleado;
                string msg = string.Empty;

                MessageBoxResult result = MessageBox.Show("¿Esta seguro de querer eliminar este elemento", "Eliminar elementos", MessageBoxButton.OKCancel, MessageBoxImage.Information);

                if (result == MessageBoxResult.OK)
                {
                    if (obj == null)
                    {
                        MessageBox.Show("Debe elegir un empleado a eliminar ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    var resultDel = Repository.DelEmployee(obj.Id, ref msg);

                    if (!resultDel)
                    {
                        MessageBox.Show("Error " + msg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    MessageBox.Show("Elemento eliminado", "Dato eliminado", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    Task.Run(() => this.OnRefresh());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override void OnUpdateItem(object param)
        {
            try
            {
                Empleado model = param as Empleado;


                if (model == null)
                {
                    MessageBox.Show("Debe elegir un empleado a modificar ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                NewEmployee np = new NewEmployee();
                NewEmployeeVM vm = new NewEmployeeVM(model);
                vm.OnAddEmployee += VMOnAddEmployee;
                np.DataContext = vm;
                np.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override void OnAddItem(object param)
        {
            try
            {
                NewEmployee np = new NewEmployee();
                NewEmployeeVM vm = new NewEmployeeVM();
                vm.OnAddEmployee += VMOnAddEmployee;
                np.DataContext = vm;
                np.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }

        private void VMOnAddEmployee(object sender, EventArgs e)
        {
            try
            {
                OnRefresh();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnRefresh()
        {
            try
            {
                this.ItemList = Repository.GetEmployees(string.Empty,ManejadorUbicacion.IdUbicacion);
                this.itemListAux = this.ItemList;
            }
            catch (Exception ex)
            {

            }
        }

        public async void SearchAsync()
        {
            try
            {
                this.ItemList = await Task.Run(() => this.GetList());
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private async Task<List<Empleado>> GetList()
        {
            List<Empleado> lst = new List<Empleado>();

            await Task.Delay(10);
            try
            {
                var aux = this.itemListAux;

                lst = aux.Where(
                      s =>
                         (

                          ((!string.IsNullOrEmpty(this.Name) ? s.Nombre.ToUpper().Contains(this.Name.ToUpper()) : true))
                          &&
                          (
                           (this.BeginHireDate != null && this.EndHireDate == null)
                             ? s.FechaIngreso == this.BeginHireDate ? true : false : true
                           )
                          )
                    ).ToList();

                return lst;
            }
            catch (Exception ex)
            {
                return lst;
            }
        }

        /// <summary>
        /// Ejecuta la accion para crear un nuevo elemento en el catalogo de familias.
        /// </summary>
        public override void OnAccept()
        {
            //if (string.IsNullOrEmpty(this.ProductName))
            //{
            //    MessageBox.Show("Debe ingresar un nombre", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return;
            //}

            //try
            //{
            //    string errorMessage = string.Empty;
            //    int error = 0;

            //    var result = Repository.InsCoins(this.ProductName, ref error, ref errorMessage);

            //    if (!result || error == -1)
            //    {
            //        MessageBox.Show("Error " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //        return;
            //    }

            //    MessageBox.Show("Datos guardados con exito ", "Datos Guardados", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
            //catch (Exception ex)
            //{

            //}
            //finally
            //{
            //    this.CleanText();
            //}
        }

        /// <summary>
        /// Limpiar el texto despues de guardar los datos.
        /// </summary>
        private void CleanText()
        {
            //this.Name = string.Empty;
            //this.Rfc = string.Empty;
        }

        #endregion
    }
}


