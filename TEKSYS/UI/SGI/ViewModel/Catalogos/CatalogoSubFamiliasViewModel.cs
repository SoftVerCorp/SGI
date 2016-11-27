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
    public class CatalogoSubFamiliasViewModel : ViewModelBase
    {
        #region Private Fields

        private int id;
        private int selectedFamilia;

        private string subFamiliaName;
        private string familiaName;

        private Families objFamiliaSearch;
        private string subFamilySearch;
        private string familySearch;
        private string url;
        private List<SubFamilies> subFamilyList;
        private List<SubFamilies> subFamilyListStore;
        private List<Families> familiesList;
        private new Operation operationType;
        private bool modoEdicion;

        #endregion

        #region Public Fields

        public event EventHandler OnAddFamily;

        #endregion

        #region Constructors

        public CatalogoSubFamiliasViewModel()
        {
            try
            {
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

        public string SubFamiliaName
        {
            get { return subFamiliaName; }
            set
            {
                this.subFamiliaName = value;
                RaisePropertyChanged(() => SubFamiliaName);
            }
        }

        public string FamiliaName
        {
            get { return familiaName; }
            set
            {
                this.familiaName = value;
                RaisePropertyChanged(() => FamiliaName);
            }
        }

        public string SubFamilySearch
        {
            get { return subFamilySearch; }
            set
            {
                this.subFamilySearch = value;
                RaisePropertyChanged(() => SubFamilySearch);
                SearchAsync();
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

        public List<SubFamilies> SubFamilyList
        {
            get { return subFamilyList; }
            set
            {
                subFamilyList = value;
                RaisePropertyChanged(() => SubFamilyList);
            }
        }

        public List<Families> FamilyList
        {
            get { return familiesList; }
            set
            {
                if (familiesList != value)
                {
                    familiesList = value;
                    RaisePropertyChanged(() => FamilyList);
                }
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


        /// <summary>
        /// 
        /// </summary>
        public int SelectedFamilia
        {
            get { return selectedFamilia; }
            set
            {
                selectedFamilia = value;
                RaisePropertyChanged(() => SelectedFamilia);
            }
        }

        public Families ObjFamiliaSearch
        {
            get { return objFamiliaSearch; }
            set
            {
                objFamiliaSearch = value;
                RaisePropertyChanged(() => ObjFamiliaSearch);
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
                    var fileName = "CatalogoSubFamilias.xls";

                    var dataTable = ExportToExcel.ListToDataTable(this.SubFamilyList);

                    ExportToExcel.ExportDocument(dataTable, "Catalogo de SubFamilias", pathFile + "/" + fileName);

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
                this.SubFamilyList = await Task.Run(() => this.GetList());
            }
            catch (Exception ex)
            {

            }
        }

        private async Task<List<SubFamilies>> GetList()
        {
            List<SubFamilies> lst = new List<SubFamilies>();

            try
            {
                var aux = this.subFamilyListStore;

                lst = aux.Where(
                      s =>
                         (

                          ((!string.IsNullOrEmpty(this.SubFamilySearch) ? s.SubFamilyName.ToUpper().Contains(this.SubFamilySearch.ToUpper()) : true))
                          &&
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


            if (this.SelectedFamilia == -1)
            {
                MessageBox.Show("Debe seleccionar una familia", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(this.SubFamiliaName))
            {
                MessageBox.Show("Debe ingresar un nombre", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (string.IsNullOrEmpty(this.Url))
            {
                MessageBox.Show("Debe ingresar una Url", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                string errorMessage = string.Empty;
                int error = 0;

                if (this.OperationType == Enumeration.Operation.Create)
                {

                    var result = Repository.InsertSubFamily(this.SelectedFamilia, this.SubFamiliaName, this.Url, ref error, ref errorMessage);

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

                    var result = Repository.UpdateSubFamilia(this.Id, this.SelectedFamilia, this.SubFamiliaName, this.Url, ref error, ref errorMessage);

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
            this.SubFamiliaName = string.Empty;
            this.Url = string.Empty;
            this.SubFamilySearch = string.Empty;
            this.FamiliaName = string.Empty;
            this.FamilySearch = string.Empty;
            this.SelectedFamilia = -1;
        }

        private void OnRefresh()
        {
            try
            {
                this.SubFamilyList = Repository.GetSubFamilias(-1, string.Empty, string.Empty);
                this.FamilyList = new List<Families>();
                this.FamilyList.Add(new Families { Id = -1, FamilyName = "Seleccionar" });
                this.FamilyList.AddRange(Repository.GetFamilies(string.Empty));

                this.subFamilyListStore = this.SubFamilyList;
                this.SelectedFamilia = -1;

                this.OperationType = Enumeration.Operation.Create;

            }
            catch (Exception ex)
            {

            }
        }

        public override void OnSelectedItemGridClick(object parameters)
        {
            SubFamilies item = Helpers.DataGridRowHelper.GetDatagridRow(parameters as MouseButtonEventArgs) as SubFamilies;

            if (item == null)
                return;

            try
            {
                this.OperationType = Enumeration.Operation.Update;
                this.Id = item.Id;
                this.SubFamiliaName = item.SubFamilyName;
                this.Url = item.Url;
                this.SelectedFamilia = item.IdFamilia;
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

                    var result = Repository.DeleteSubFamilia((int)param, ref msg);

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
                if (resultAlert == MessageBoxResult.OK) {
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
            this.SubFamilySearch = string.Empty;
            this.FamilySearch = string.Empty;
        }
        #endregion
    }
}
