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
    public class CatalogoColorViewModel : ViewModelBase
    {
        #region Private Fields

        private int id;
        private string color;
        private string claveColor;
        private string colorSearch;
        private string claveColorSearch;
        private List<Color> colorList;
        private List<Color> colorListStore;
        private new Operation operationType;
        private bool modoEdicion;

        private System.Windows.Visibility isModeSearch;
        private Color selectedColor;

        #endregion

        #region Public Fields

        public event EventHandler OnAddColor;

        #endregion

        #region Constructors

        public CatalogoColorViewModel()
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

        public CatalogoColorViewModel(bool isModeSearchValue)
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

        public Color SelectedColor
        {
            get { return this.selectedColor; }
            set
            {
                this.selectedColor = value;
                RaisePropertyChanged(() => SelectedColor);
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

        public string ColorText
        {
            get { return color; }
            set { 
                this.color = value;
                RaisePropertyChanged(() => ColorText);
            }
        }

        public string ColorSearch
        {
            get { return colorSearch; }
            set
            {
                this.colorSearch = value;
                RaisePropertyChanged(() => ColorSearch);
                SearchAsync();
            }
        }

        public List<Color> ColorList
        {
            get { return colorList; }
            set
            {
                colorList = value;
                RaisePropertyChanged(() => ColorList);
            }
        }

        public ICommand CreateFamily
        {
            get
            {
                return new RelayCommand(s => this.OnAccept());
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

        public string ClaveColor
        {
            get { return claveColor; }
            set {
                this.claveColor = value;
                RaisePropertyChanged(() => ClaveColor);
            }
        }

        public string ClaveColorSearch
        {
            get { return claveColorSearch; }
            set
            {
                this.claveColorSearch = value;
                RaisePropertyChanged(() => ClaveColorSearch);
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
                    var fileName = "CatalogoColores.xls";

                    var dataTable = ExportToExcel.ListToDataTable(this.ColorList);

                    ExportToExcel.ExportDocument(dataTable, "Catalogo de Colores", pathFile + "/" + fileName);

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
                this.ColorList = await Task.Run(() => this.GetList());
            }
            catch (Exception ex)
            {

            }
        }

        private async Task<List<Color>> GetList()
        {
            List<Color> lst = new List<Color>();

            try
            {
                var aux = this.colorListStore;

                lst = aux.Where(
                      s =>
                         (
                          ((!string.IsNullOrEmpty(this.ColorSearch) ? s.ColorString.ToUpper().Contains(this.ColorSearch.ToUpper()) : true))
                          &&
                          ((!string.IsNullOrEmpty(this.ClaveColorSearch) ? s.ClaveColor.ToUpper().Contains(this.ClaveColorSearch.ToUpper()) : true))
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

            if (string.IsNullOrEmpty(this.ColorText))
            {
                MessageBox.Show("Debe ingresar un nombre", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (string.IsNullOrEmpty(this.ClaveColor))
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
                    var result = Repository.InsertColor(this.ColorText, this.ClaveColor, ref error, ref errorMessage);

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

                    var result = Repository.UpdateColor(this.Id, this.ColorText, this.ClaveColor, ref error, ref errorMessage);

                    if (result)
                    {
                        MessageBox.Show("Registro modificado con exito ", "Registro modificado", MessageBoxButton.OK, MessageBoxImage.Information);

                        ////if (OnAddFamily != null)
                        ////{
                        ////    OnAddFamily(true, null);
                        ////}
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
            this.ColorText = string.Empty;
            this.ClaveColor = string.Empty;
            this.ColorSearch = string.Empty;
            this.ClaveColorSearch = string.Empty;
        }

        private void OnRefresh()
        {
            try
            {
                this.ColorList = Repository.GetColores(string.Empty, string.Empty);
                this.colorListStore = this.ColorList;
            }
            catch (Exception ex)
            {

            }
        }

        public override void OnSelectedItemGridClick(object parameters)
        {
            Color item = Helpers.DataGridRowHelper.GetDatagridRow(parameters as MouseButtonEventArgs) as Color;

            if (item == null)
                return;

            try
            {

                this.OperationType = Enumeration.Operation.Update;

                if (IsModeSearch == System.Windows.Visibility.Collapsed)
                {

                    this.SelectedColor = item;

                    if (this.OnAddColor != null)
                    {
                        this.OnAddColor(this, null);
                    }

                }
                else
                {
                    this.Id = item.Id;
                    this.ColorText = item.ColorString;
                    this.ClaveColor = item.ClaveColor;
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

                    var result = Repository.DeleteColor((int)param, ref msg);

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

        public override void OnRefreshSearch()
        {
            CleanSearch();
            Task.Run(() => this.OnRefresh());
        }

        private void CleanSearch()
        {
            this.ColorSearch = string.Empty;
            this.ClaveColorSearch = string.Empty;
        }

        #endregion
    }
}
