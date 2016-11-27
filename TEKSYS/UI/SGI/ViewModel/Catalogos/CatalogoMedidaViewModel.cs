using SGI.Classes;
using SGI.Enumeration;
using SGI.Helpers;
using SGI.Model;
using SGI.Stuffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SGI.ViewModel.Catalogos
{
    public class CatalogoMedidaViewModel : ViewModelBase
    {
        #region Private Fields

        private int id;
        private string medida;
        private string claveMedida;
        private string medidaSearch;
        private string claveMedidaSearch;
        private List<Measure> medidaList;
        private List<Measure> medidaListStore;
        private new Operation operationType;
        private bool modoEdicion;

        private System.Windows.Visibility isModeSearch;
        private Measure selectedMeasurement;

        #endregion

        #region Public Fields

        public event EventHandler OnAddMeasurement;

        #endregion

        #region Constructors

        public CatalogoMedidaViewModel()
        {
            try
            {
                this.OperationType = Enumeration.Operation.Create;
                OnRefresh();
            }
            catch (Exception)
            {               
                throw;
            }
        }

        public CatalogoMedidaViewModel(bool isModeSearchValue)
        {
            try
            {
                if (isModeSearchValue)
                    IsModeSearch = System.Windows.Visibility.Visible;
                else
                {
                    IsModeSearch = System.Windows.Visibility.Collapsed;
                }

                this.OperationType = Enumeration.Operation.Create;
                OnRefresh();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Public Properties

        public int Id
        {
            get { return id; }
            set
            {
                this.id = value;
                RaisePropertyChanged(() => Id);
            }
        }

        public string MedidaText
        {
            get { return medida; }
            set {
                this.medida = value;
                RaisePropertyChanged(() => MedidaText);
            }
        }

        public string MedidaSearch
        {
            get { return medidaSearch; }
            set
            {
                this.medidaSearch = value;
                RaisePropertyChanged(() => MedidaSearch);
                SearchAsync();
            }
        }

        public List<Measure> MedidaList
        {
            get { return medidaList; }
            set
            {
                medidaList = value;
                RaisePropertyChanged(() => MedidaList);
            }
        }

        public bool ModoEdicion
        {
            get { return this.modoEdicion; }
            set
            {
                this.modoEdicion = value;
                RaisePropertyChanged(() => ModoEdicion);
            }
        }

        public new Operation OperationType
        {
            get { return this.operationType; }
            set 
            { 
                this.operationType = value;
                RaisePropertyChanged(() => OperationType);
                this.ModoEdicion = (value == Enumeration.Operation.Update);
            }
        }

        public string ClaveMedida
        {
            get { return claveMedida; }
            set {
                this.claveMedida = value;
                RaisePropertyChanged(() => ClaveMedida);
            }
        }

        public string ClaveMedidaSearch
        {
            get { return claveMedidaSearch; }
            set
            {
                this.claveMedidaSearch = value;
                RaisePropertyChanged(() => ClaveMedidaSearch);
                SearchAsync();
            }
        }

        #endregion

        #region Private Methods

        public override void ExportarExcel()
        {
            try
            {
                System.Windows.Forms.FolderBrowserDialog broserDialog = new System.Windows.Forms.FolderBrowserDialog();

                if (broserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var pathFile = broserDialog.SelectedPath;
                    var fileName = "CatalogoMedidas.xls";

                    var dataTable = ExportToExcel.ListToDataTable(this.MedidaList);

                    ExportToExcel.ExportDocument(dataTable, "Catalogo de Medidas", pathFile + "/" + fileName);

                    System.Windows.MessageBox.Show("Archivo exportado correctamente");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al exportar archivo de excel");
            }
        }

        public Measure SelectedMeasurement
        {
            get { return this.selectedMeasurement; }
            set
            {
                this.selectedMeasurement = value;
                RaisePropertyChanged(() => SelectedMeasurement);
            }
        }

        public System.Windows.Visibility IsModeSearch
        {
            get { return this.isModeSearch; }
            set
            {
                this.isModeSearch = value;
                RaisePropertyChanged(() => IsModeSearch);
            }
        }

        public async void SearchAsync()
        {
            try
            {
                this.MedidaList = await Task.Run(() => this.GetList());
            }
            catch (Exception ex)
            {

            }
        }

        private async Task<List<Measure>> GetList()
        {
            List<Measure> lst = new List<Measure>();

            try
            {
                var aux = this.medidaListStore;

                lst = aux.Where(
                      s =>
                         (
                          ((!string.IsNullOrEmpty(this.MedidaSearch) ? s.MedidaString.ToUpper().Contains(this.MedidaSearch.ToUpper()) : true))
                          &&
                          ((!string.IsNullOrEmpty(this.ClaveMedidaSearch) ? s.ClaveMedida.ToUpper().Contains(this.ClaveMedidaSearch.ToUpper()) : true))
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
            MessageBoxResult resultAlert = MessageBoxResult.OK;     

            if (string.IsNullOrEmpty(this.MedidaText))
            {
                MessageBox.Show("Debe ingresar una medida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (string.IsNullOrEmpty(this.ClaveMedida))
            {
                MessageBox.Show("Debe ingresar una clave", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                string errorMessage = string.Empty;
                int error = 0;

                if (this.OperationType == Enumeration.Operation.Create)
                {
                    var result = Repository.InsertMedida(this.MedidaText, this.ClaveMedida, ref error, ref errorMessage);

                    if (!result || error == -1)
                    {
                        MessageBox.Show("Error " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    MessageBox.Show("Datos guardados con exito ", "Datos Guardados", MessageBoxButton.OK, MessageBoxImage.Information);

                    //if (OnAddFamily != null)
                    //{
                    //    OnAddFamily(true, null);
                    //}
                }
                else if (this.OperationType == Enumeration.Operation.Update)
                {
                    resultAlert = System.Windows.MessageBox.Show("¿Esta seguro de actualizar este elemento? ", "Advertencia", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                    if (resultAlert != MessageBoxResult.OK)
                        return;

                    var result = Repository.UpdateMedida(this.Id, this.MedidaText, this.ClaveMedida, ref error, ref errorMessage);

                    if (result)
                    {
                        MessageBox.Show("Registro modificado con exito ", "Registro modificado", MessageBoxButton.OK, MessageBoxImage.Information);

                        //if (OnAddFamily != null)
                        //{
                        //    OnAddFamily(true, null);
                        //}
                    }
                    else
                    {
                        MessageBox.Show("Error  " + errorMessage, "Registro modificado", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" , "Fallo transaccion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (resultAlert == MessageBoxResult.OK)
                {
                    OnClean();
                    Task.Run(() => this.OnRefresh());
                }
            }
        }

        public override void OnClean()
        {
            this.OperationType = Enumeration.Operation.Create;
            this.MedidaText = string.Empty;
            this.ClaveMedida = string.Empty;
            this.MedidaSearch = string.Empty;
            this.ClaveMedidaSearch = string.Empty;
        }

        public void CleanSearch() 
        {
            this.MedidaSearch = string.Empty;
            this.ClaveMedidaSearch = string.Empty;
        }

        private void OnRefresh()
        {
            try
            {
                this.MedidaList = Repository.GetMedidas(string.Empty, string.Empty);
                this.medidaListStore = this.MedidaList;
            }
            catch (Exception ex)
            {

            }
        }

        public override void OnRefreshSearch()
        {
            CleanSearch();
            Task.Run(() => this.OnRefresh());
        }

        public override void OnSelectedItemGridClick(object parameters)
        {
            Measure item = Helpers.DataGridRowHelper.GetDatagridRow(parameters as MouseButtonEventArgs) as Measure;

            if (item == null)
                return;

            try
            {
                this.OperationType = Enumeration.Operation.Update;

                if (IsModeSearch == System.Windows.Visibility.Collapsed)
                {

                    this.SelectedMeasurement = item;

                    if (this.OnAddMeasurement != null)
                    {
                        this.OnAddMeasurement(this, null);
                    }

                }
                else
                {
                    this.Id = item.Id;
                    this.MedidaText = item.MedidaString;
                    this.ClaveMedida = item.ClaveMedida;
                }
               
            }
            catch (Exception ex)
            {

            }
        }

        public override void OnDeleteItem(object param)
        {
            MessageBoxResult resultAlert = MessageBoxResult.OK;            

            string msg = string.Empty;
            try
            {
                if(this.OperationType == Enumeration.Operation.Update)
                {
                    resultAlert = System.Windows.MessageBox.Show("¿Esta seguro de eliminar este elemento? ", "Advertencia", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                    if (resultAlert != MessageBoxResult.OK)
                        return;

                    var result = Repository.DeleteMedida((int)param, ref msg);

                    if (result)
                    {
                        MessageBox.Show("Registro eliminado con exito ", "Registro eliminado", MessageBoxButton.OK, MessageBoxImage.Information);

                        //if (OnAddFamily != null)
                        //{
                        //    OnAddFamily(true, null);
                        //}
                    }
                    else
                    {
                        MessageBox.Show("Error  " + msg, "Registro eliminado", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception)
            {              
                throw;
            }
            finally
            {
                if (resultAlert == MessageBoxResult.OK)
                {
                    OnClean();
                    Task.Run(() => this.OnRefresh());
                }
            }
        }

        #endregion
    }
}
