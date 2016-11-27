using Microsoft.Win32;
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
using System.Windows.Forms;
using System.Windows.Input;

namespace SGI.ViewModel.Catalogos
{
    public class CatalogoFamiliasViewModel : ViewModelBase
    {
        #region Private Fields

        private int id;
        private string family;
        private string familySearch;
        private string url;
        private List<Families> familyList;
        private List<Families> familyListStore;
        private new Operation operationType;
        private bool modoEdicion;

        private System.Windows.Visibility isModeSearch;
        private Families selectedFamily;
        #endregion

        #region Public Fields

        public event EventHandler OnAddFamily;

        #endregion

        #region Constructors

        public CatalogoFamiliasViewModel()
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

        public CatalogoFamiliasViewModel(bool isModeSearchValue)
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

        public Families SelectedFamily
        {
            get { return this.selectedFamily; }
            set
            {
                this.selectedFamily = value;
                RaisePropertyChanged(() => SelectedFamily);
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

        public string Family
        {
            get { return family; }
            set
            {
                this.family = value;
                RaisePropertyChanged(() => Family);
            }
        }

        public string FamilySearch
        {
            get { return familySearch; }
            set
            {
                this.familySearch = value;
                RaisePropertyChanged(() => FamilySearch);
                SearchAsync();
            }
        }

        public string Url
        {
            get { return this.url; }
            set
            {
                this.url = value;
                RaisePropertyChanged(() => Url);
            }
        }

        public List<Families> FamilyList
        {
            get { return familyList; }
            set
            {
                familyList = value;
                RaisePropertyChanged(() => FamilyList);
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

        #endregion

        #region Private Methods

        public override void ExportarExcel()
        {
            try
            {
                FolderBrowserDialog broserDialog = new FolderBrowserDialog();

                if (broserDialog.ShowDialog() == DialogResult.OK)
                {
                    var pathFile = broserDialog.SelectedPath;
                    var fileName = "CatalogoFamilias.xls";

                    var dataTable = ExportToExcel.ListToDataTable(this.FamilyList);

                    ExportToExcel.ExportDocument(dataTable, "Catalogo de Familias", pathFile + "/" + fileName);

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
                this.FamilyList = await Task.Run(() => this.GetList());
            }
            catch (Exception ex)
            {

            }
        }

        private async Task<List<Families>> GetList()
        {
            List<Families> lst = new List<Families>();

            try
            {
                var aux = this.familyListStore;

                lst = aux.Where(
                      s =>
                         (

                          ((!string.IsNullOrEmpty(this.FamilySearch) ? s.FamilyName.ToUpper().Contains(this.FamilySearch.ToUpper()) : true))

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

            if (string.IsNullOrEmpty(this.Family))
            {
                System.Windows.MessageBox.Show("Debe ingresar un nombre", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (string.IsNullOrEmpty(this.Url))
            {
                System.Windows.MessageBox.Show("Debe ingresar una Url", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                string errorMessage = string.Empty;
                int error = 0;

                if (this.OperationType == Enumeration.Operation.Create)
                {

                    var result = Repository.InsFamily(this.Family, this.Url, ref error, ref errorMessage);

                    if (!result || error == -1)
                    {
                        System.Windows.MessageBox.Show("Error " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    System.Windows.MessageBox.Show("Datos guardados con exito ", "Datos Guardados", MessageBoxButton.OK, MessageBoxImage.Information);

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

                    var result = Repository.UpdFamily(this.Id, this.Family, this.Url, ref error, ref errorMessage);

                    if (result)
                    {
                        System.Windows.MessageBox.Show("Registro modificado con exito ", "Registro modificado", MessageBoxButton.OK, MessageBoxImage.Information);

                        if (OnAddFamily != null)
                        {
                            OnAddFamily(true, null);
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Error  " + errorMessage, "Registro modificado", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error", "Fallo transaccion", MessageBoxButton.OK, MessageBoxImage.Error);
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
            this.Family = string.Empty;
            this.Url = string.Empty;
            this.FamilySearch = string.Empty;
        }

        private void OnRefresh()
        {
            try
            {
                this.FamilyList = Repository.GetFamilies(string.Empty);
                this.familyListStore = this.FamilyList;
            }
            catch (Exception ex)
            {

            }
        }

        public override void OnSelectedItemGridClick(object parameters)
        {
            Families item = Helpers.DataGridRowHelper.GetDatagridRow(parameters as MouseButtonEventArgs) as Families;

            if (item == null)
                return;

            try
            {
                this.OperationType = Enumeration.Operation.Update;

                if (IsModeSearch == System.Windows.Visibility.Collapsed)
                {

                    this.SelectedFamily = item;

                    if (this.OnAddFamily != null)
                    {
                        this.OnAddFamily(this, null);
                    }

                }
                else
                {
                    this.Id = item.Id;
                    this.Family = item.FamilyName;
                    this.Url = item.Url;
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

                    var result = Repository.DelFamily((int)param, ref msg);

                    if (result)
                    {
                        System.Windows.MessageBox.Show("Registro eliminado con exito ", "Registro eliminado", MessageBoxButton.OK, MessageBoxImage.Information);

                        if (OnAddFamily != null)
                        {
                            OnAddFamily(true, null);
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Error  " + msg, "Registro eliminado", MessageBoxButton.OK, MessageBoxImage.Error);
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
            this.FamilySearch = string.Empty;
        }

        #endregion
    }
}
