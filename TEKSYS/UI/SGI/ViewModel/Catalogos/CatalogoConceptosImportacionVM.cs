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
    public class CatalogoConceptosImportacionVM : ViewModelBase
    {
        #region Private Fields

        private string concepto;
        private string filtroConcepto;

        private int idConcepto;

        private List<ConceptosImportacion> conceptos;
        private List<ConceptosImportacion> conceptosAux;

        private Operation tipoDeOperacion;

        #endregion

        #region Constructors
        public CatalogoConceptosImportacionVM()
        {
            try
            {
                tipoDeOperacion = Operation.Create;
                idConcepto = -1;
                MostrarDatos();
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region Public Properties

        public List<ConceptosImportacion> Conceptos
        {
            get { return conceptos; }
            set
            {
                if (conceptos != value)
                {
                    conceptos = value;
                    RaisePropertyChanged(() => Conceptos);
                }
            }
        }

        public string Concepto
        {
            get { return concepto; }
            set
            {
                if (concepto != value)
                {
                    concepto = value;
                    RaisePropertyChanged(() => Concepto);
                }
            }
        }




        public string FiltroConcepto
        {
            get { return filtroConcepto; }
            set
            {
                if (filtroConcepto != value)
                {
                    filtroConcepto = value;
                    RaisePropertyChanged(() => FiltroConcepto);
                    BusquedaAsync();
                }
            }
        }



        public ICommand InsertarConceptoCmd
        {
            get
            {
                return new RelayCommand(s => InsertarConcepto());
            }
        }

        public ICommand EliminarConceptoCmd
        {
            get
            {
                return new RelayCommand(OnDeleteItem);
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
                    var fileName = "CatalogoConceptosImportacion.xls";

                    var dataTable = ExportToExcel.ListToDataTable(this.Conceptos);

                    ExportToExcel.ExportDocument(dataTable, "Catalogo de Conceptos de importacion", pathFile + "/" + fileName);

                    System.Windows.MessageBox.Show("Archivo exportado correctamente");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al exportar archivo de excel");
            }
        }


        private async void BusquedaAsync()
        {
            try
            {
                this.Conceptos = await Task.Run(() => ObtenerConceptosAsync());
            }
            catch (Exception ex)
            {

            }
        }

        private async Task<List<ConceptosImportacion>> ObtenerConceptosAsync()
        {
            Task.Delay(100);

            try
            {
                var aux = this.conceptosAux;

                var result = (from x in aux
                              where
                              (
                              (!string.IsNullOrEmpty(this.FiltroConcepto) ? x.Concepto.ToUpper().Contains(this.FiltroConcepto.ToUpper()) : true)

                              )
                              select x).ToList();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void MostrarDatos()
        {
            try
            {
                this.Conceptos = Repository.ObtenerConceptosDeImportacion();
                this.conceptosAux = this.Conceptos;
            }
            catch (Exception ex)
            {

            }
        }


        public override void OnRefreshSearch()
        {
            try
            {
                this.MostrarDatos();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void InsertarConcepto()
        {
            try
            {
                if (string.IsNullOrEmpty(this.Concepto))
                {
                    MessageBox.Show("Debe ingresar el nombre del concepto de importación", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


                if (tipoDeOperacion == Operation.Create)
                {
                    var res = Repository.InsertarConceptosDeImportacion(this.Concepto);

                    if (!res)
                    {
                        MessageBox.Show("Error al insertar concepto de importación", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    MessageBox.Show("Datos guardados con exito", "Datos Guardados", MessageBoxButton.OK, MessageBoxImage.Information);
                    OnClean();                    
                }
                else
                {
                    if (tipoDeOperacion == Operation.Update)
                    {
                        if (this.idConcepto == -1)
                        {
                            MessageBox.Show("Error, debe seleccionar un elemento a modificar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        var res = Repository.ActualizarConceptosDeImportacion(this.idConcepto, this.Concepto);

                        if (!res)
                        {
                            MessageBox.Show("Error al modificar Concepto seleccionado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        MessageBox.Show("Datos modificados con exito", "Datos Guardados", MessageBoxButton.OK, MessageBoxImage.Information);
                        OnClean();                       
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public override void OnDeleteItem(object param)
        {
            if (this.idConcepto == -1)
            {
                MessageBox.Show("Error, debe seleccionar un elemento a modificar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var res = Repository.EliminarConceptosDeImportacion(this.idConcepto);

            if (!res)
            {
                MessageBox.Show("Error al eliminar el concepto seleccionada", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show("Datos eliminados con exito", "Datos Eliminados", MessageBoxButton.OK, MessageBoxImage.Information);
            OnClean();
            MostrarDatos();
        }

        public override void OnSelectedItemGridClick(object parameters)
        {
            ConceptosImportacion item = Helpers.DataGridRowHelper.GetDatagridRow(parameters as MouseButtonEventArgs) as ConceptosImportacion;

            if (item == null)
                return;

            try
            {
                this.tipoDeOperacion = Enumeration.Operation.Update;

                this.idConcepto = item.Id;
                this.Concepto = item.Concepto;
            }
            catch (Exception ex)
            {

            }
        }

        public override void OnClean()
        {
            this.MostrarDatos();

            this.Concepto = string.Empty;
            this.FiltroConcepto = string.Empty;
            this.tipoDeOperacion = Operation.Create;
            this.idConcepto = -1;
          
        }

        #endregion
    }
}
