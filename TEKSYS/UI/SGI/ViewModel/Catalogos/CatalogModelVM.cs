using SGI.Enumeration;
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

namespace SGI.ViewModel.Catalogos
{
    public class CatalogModelVM : ViewModelBase
    {

        #region Private Fields

        private int id;
        private string model;
        private string modelSearch;
        private List<Models> modelList;
        private List<Models> modelListStore;
        private new Operation operationType;
        private bool modoEdicion;

        private System.Windows.Visibility isModeSearch;
        private Models selectedModel;

        #endregion

        #region Public Fields

        public event EventHandler OnAddFamily;

        #endregion

        #region Constructors

        public CatalogModelVM()
        {
            try
            {
                IsModeSearch = System.Windows.Visibility.Visible;
                this.OperationType = Enumeration.Operation.Create;
                OnRefresh();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CatalogModelVM(bool isModeSearchValue)
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

        public string Model
        {
            get { return model; }
            set
            {
                this.model = value;
                RaisePropertyChanged(() => Model);
            }
        }

        public string ModelSearch
        {
            get { return modelSearch; }
            set
            {
                this.modelSearch = value;
                RaisePropertyChanged(() => ModelSearch);
                SearchAsync();
            }
        }

        public List<Models> ModelList
        {
            get { return modelList; }
            set
            {
                modelList = value;
                RaisePropertyChanged(() => ModelList);
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

        public System.Windows.Visibility IsModeSearch
        {
            get { return this.isModeSearch; }
            set
            {
                this.isModeSearch = value;
                RaisePropertyChanged(() => IsModeSearch);
            }
        }

        public Models SelectedModel
        {
            get { return this.selectedModel; }
            set
            {
                this.selectedModel = value;
                RaisePropertyChanged(() => SelectedModel);
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
                    var fileName = "CatalogoModelos.xls";

                    var dataTable = ExportToExcel.ListToDataTable(this.ModelList);

                    ExportToExcel.ExportDocument(dataTable, "Catalogo de Modelos", pathFile + "/" + fileName);

                    System.Windows.MessageBox.Show("Archivo exportado correctamente");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al exportar archivo de excel");
            }
        }


        public async void SearchAsync()
        {
            try
            {
                this.ModelList = await Task.Run(() => this.GetList());
            }
            catch (Exception ex)
            {

            }
        }

        private async Task<List<Models>> GetList()
        {
            List<Models> lst = new List<Models>();

            try
            {
                var aux = this.modelListStore;

                lst = aux.Where(
                      s =>
                         (

                          ((!string.IsNullOrEmpty(this.ModelSearch) ? s.Model.ToUpper().Contains(this.ModelSearch.ToUpper()) : true))

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

            if (string.IsNullOrEmpty(this.Model))
            {
                MessageBox.Show("Debe ingresar el nombre del modelo", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                string errorMessage = string.Empty;
                int error = 0;

                if (this.OperationType == Enumeration.Operation.Create)
                {

                    var result = Repository.InsertModelo(this.Model, ref error, ref errorMessage);

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
                else if (this.OperationType == Enumeration.Operation.Update)
                {

                    resultAlert = System.Windows.MessageBox.Show("¿Esta seguro de actualizar este elemento? ", "Advertencia", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                    if (resultAlert != MessageBoxResult.OK)
                        return;

                    var result = Repository.UpdateModelo(this.Id, this.Model, ref error, ref errorMessage);

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
                MessageBox.Show("Error", "Fallo transaccion", MessageBoxButton.OK, MessageBoxImage.Error);
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
            this.Model = string.Empty;
            this.ModelSearch = string.Empty;
        }

        private void OnRefresh()
        {
            try
            {
                this.ModelList = Repository.GetModels(string.Empty);
                this.modelListStore = this.ModelList;
            }
            catch (Exception ex)
            {

            }
        }

        public override void OnSelectedItemGridClick(object parameters)
        {
            Models item = Helpers.DataGridRowHelper.GetDatagridRow(parameters as MouseButtonEventArgs) as Models;

            if (item == null)
                return;

            try
            {

                this.OperationType = Enumeration.Operation.Update;

                if (IsModeSearch == System.Windows.Visibility.Collapsed)
                {
                    SelectedModel = item;
                }
                else
                {
                    this.Id = item.Id;
                    this.Model = item.Model;
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
                if (this.OperationType == Enumeration.Operation.Update)
                {
                    resultAlert = System.Windows.MessageBox.Show("¿Esta seguro de eliminar este elemento? ", "Advertencia", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                    if (resultAlert != MessageBoxResult.OK)
                        return;

                    var result = Repository.DeleteModelo((int)param, ref msg);

                    if (result)
                    {
                        MessageBox.Show("Registro eliminado con exito ", "Registro eliminado", MessageBoxButton.OK, MessageBoxImage.Information);

                        if (OnAddFamily != null)
                        {
                            OnAddFamily(true, null);
                        }
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

        public override void OnRefreshSearch()
        {
            CleanSearch();
            Task.Run(() => this.OnRefresh());
        }

        private void CleanSearch()
        {
            this.ModelSearch = string.Empty;
        }

        #endregion

    }
}
