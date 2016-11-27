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
    public class CatalogoMarcasViewModel : ViewModelBase
    {

        #region Private Fields

        private int id;
        private string marca;
        private string marcaSearch;
        private List<Brand> marcaList;
        private List<Brand> marcaListStore;
        private new Operation operationType;
        private bool modoEdicion;

        private System.Windows.Visibility isModeSearch;
        private Brand selectedTradeMark;

        #endregion

        #region Public Fields

        public event EventHandler OnAddTradeMark;

        #endregion

        #region Constructors

        public CatalogoMarcasViewModel()
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

        public CatalogoMarcasViewModel(bool isModeSearchValue)
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

        public Brand SelectedTradeMark
        {
            get { return this.selectedTradeMark; }
            set
            {
                this.selectedTradeMark = value;
                RaisePropertyChanged(() => SelectedTradeMark);
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

        public int Id
        {
            get { return id; }
            set
            {
                this.id = value;
                RaisePropertyChanged(() => Id);
            }
        }

        public string Marca 
        {
            get { return marca; }
            set {
                this.marca = value;
                RaisePropertyChanged(() => Marca);
            }
        }

        public string MarcaSearch
        {
            get { return marcaSearch; }
            set
            {
                this.marcaSearch = value;
                RaisePropertyChanged(() => MarcaSearch);
                SearchAsync();
            }
        }

        public List<Brand> MarcaList
        {
            get { return marcaList; }
            set
            {
                marcaList = value;
                RaisePropertyChanged(() => MarcaList);
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
                    var fileName = "CatalogoMarcas.xls";

                    var dataTable = ExportToExcel.ListToDataTable(this.MarcaList);

                    ExportToExcel.ExportDocument(dataTable, "Catalogo de Marcas", pathFile + "/" + fileName);

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
                this.MarcaList = await Task.Run(() => this.GetList());
            }
            catch (Exception ex)
            {

            }
        }

        private async Task<List<Brand>> GetList()
        {
            List<Brand> lst = new List<Brand>();

            try
            {
                var aux = this.marcaListStore;

                lst = aux.Where(
                      s =>
                         (

                          ((!string.IsNullOrEmpty(this.MarcaSearch) ? s.Marca.ToUpper().Contains(this.MarcaSearch.ToUpper()) : true))

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

            if (string.IsNullOrEmpty(this.Marca))
            {
                MessageBox.Show("Debe ingresar el nombre de la marca", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                string errorMessage = string.Empty;
                int error = 0;

                if (this.OperationType == Enumeration.Operation.Create)
                {

                    var result = Repository.InsertMarca(this.Marca, ref error, ref errorMessage);

                    if (!result || error == -1)
                    {
                        MessageBox.Show("Error " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    MessageBox.Show("Datos guardados con exito ", "Datos Guardados", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else if (this.OperationType == Enumeration.Operation.Update)
                {

                    resultAlert = System.Windows.MessageBox.Show("¿Esta seguro de actualizar este elemento? ", "Advertencia", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                    if (resultAlert != MessageBoxResult.OK)
                        return;

                    var result = Repository.UpdateMarca(this.Id, this.Marca, ref error, ref errorMessage);

                    if (result)
                    {
                        MessageBox.Show("Registro modificado con exito ", "Registro modificado", MessageBoxButton.OK, MessageBoxImage.Information);

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
            this.Marca = string.Empty;
            this.MarcaSearch = string.Empty;
        }

        private void OnRefresh()
        {
            try
            {
                this.MarcaList = Repository.GetMarcas(string.Empty);
                this.marcaListStore = this.MarcaList;
            }
            catch (Exception ex)
            {

            }
        }

        public override void OnSelectedItemGridClick(object parameters)
        {
            Brand item = Helpers.DataGridRowHelper.GetDatagridRow(parameters as MouseButtonEventArgs) as Brand;

            if (item == null)
                return;

            try
            {
                this.OperationType = Enumeration.Operation.Update;

                if (IsModeSearch == System.Windows.Visibility.Collapsed)
                {
                    this.SelectedTradeMark = item;

                    if (this.OnAddTradeMark != null)
                    {
                        this.OnAddTradeMark(this, null);
                    }
                }
                else
                {
                    this.Id = item.Id;
                    this.Marca = item.Marca;
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

                    var result = Repository.DeleteMarca((int)param, ref msg);

                    if (result)
                    {
                        MessageBox.Show("Registro eliminado con exito ", "Registro eliminado", MessageBoxButton.OK, MessageBoxImage.Information);

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
            this.MarcaSearch = string.Empty;
        }

        #endregion

    }
}
