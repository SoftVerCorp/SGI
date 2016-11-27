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
    public class CatalogoAlmacenVM : ViewModelBase
    {
        #region Private Fields

        private string nombre;
        private string filtroNombre;
        private string direccion;
        private string filtroDireccion;

        private int idAgenteAduanal;

        private List<Almacen> agentes;
        private List<Almacen> agentesAux;

        private Operation tipoDeOperacion;

        #endregion

        #region Contructors

        public CatalogoAlmacenVM()
        {
            try
            {
                tipoDeOperacion = Operation.Create;
                idAgenteAduanal = -1;
                MostrarDatos();
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region Public Properties

        public List<Almacen> Agentes
        {
            get { return agentes; }
            set
            {
                if (agentes != value)
                {
                    agentes = value;
                    RaisePropertyChanged(() => Agentes);
                }
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (nombre != value)
                {
                    nombre = value;
                    RaisePropertyChanged(() => Nombre);
                }
            }
        }


        public string Direccion
        {
            get { return direccion; }
            set
            {
                if (direccion != value)
                {
                    direccion = value;
                    RaisePropertyChanged(() => Direccion);
                }
            }
        }

        public string FiltroNombre
        {
            get { return filtroNombre; }
            set
            {
                if (filtroNombre != value)
                {
                    filtroNombre = value;
                    RaisePropertyChanged(() => FiltroNombre);
                    BusquedaAsync();
                }
            }
        }


        public string FiltroDireccion
        {
            get { return filtroDireccion; }
            set
            {
                if (filtroDireccion != value)
                {
                    filtroDireccion = value;
                    RaisePropertyChanged(() => FiltroDireccion);
                    BusquedaAsync();
                }
            }
        }

        public ICommand InsertarAgenteCmd
        {
            get
            {
                return new RelayCommand(s => InsertarPaqueteria());
            }
        }

        public ICommand EliminarAgenteCmd
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
                    var fileName = "CatalogoAlmacenes.xls";

                    var dataTable = ExportToExcel.ListToDataTable(this.Agentes);

                    ExportToExcel.ExportDocument(dataTable, "Catalogo de Almacenes", pathFile + "/" + fileName);

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
                this.Agentes = await Task.Run(() => ObtenerAgentesAsync());
            }
            catch (Exception ex)
            {

            }
        }

        private async Task<List<Almacen>> ObtenerAgentesAsync()
        {
            Task.Delay(100);

            try
            {
                var aux = this.agentesAux;

                var result = (from x in aux
                              where
                              (
                              (!string.IsNullOrEmpty(this.FiltroNombre) ? x.Nombre.ToUpper().Contains(this.FiltroNombre.ToUpper()) : true)
                              &&
                              (!string.IsNullOrEmpty(this.FiltroDireccion) ? x.Direccion.ToUpper().Contains(this.FiltroDireccion.ToUpper()) : true)
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
                this.Agentes = Repository.ObtenerAlmacen();
                this.agentesAux = this.Agentes;
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
        private void InsertarPaqueteria()
        {
            try
            {
                if (string.IsNullOrEmpty(this.Nombre))
                {
                    MessageBox.Show("Debe ingresar el nombre del Almacen", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (string.IsNullOrEmpty(this.Direccion))
                {
                    MessageBox.Show("Debe ingresar la direccion del Almacen", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (tipoDeOperacion == Operation.Create)
                {
                    var res = Repository.InsertarAlmacen(this.Nombre, this.Direccion);

                    if (!res)
                    {
                        MessageBox.Show("Error al insertar Almacen", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    MessageBox.Show("Datos guardados con exito", "Datos Guardados", MessageBoxButton.OK, MessageBoxImage.Information);
                    OnClean();
                    MostrarDatos();
                }
                else
                {
                    if (tipoDeOperacion == Operation.Update)
                    {
                        if (this.idAgenteAduanal == -1)
                        {
                            MessageBox.Show("Error, debe seleccionar un elemento a modificar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        var res = Repository.ActualizarAlmacen(this.idAgenteAduanal, this.Nombre, this.Direccion);

                        if (!res)
                        {
                            MessageBox.Show("Error al modificar Almacen", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        MessageBox.Show("Datos modificados con exito", "Datos Guardados", MessageBoxButton.OK, MessageBoxImage.Information);
                        OnClean();
                        MostrarDatos();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public override void OnDeleteItem(object param)
        {
            if (this.idAgenteAduanal == -1)
            {
                MessageBox.Show("Error, debe seleccionar un elemento a modificar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var res = Repository.EliminarAlmacen(this.idAgenteAduanal);

            if (!res)
            {
                MessageBox.Show("Error al eliminar la paqueteria seleccionada", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show("Datos eliminados con exito", "Datos Eliminados", MessageBoxButton.OK, MessageBoxImage.Information);
            OnClean();
            MostrarDatos();
        }

        public override void OnSelectedItemGridClick(object parameters)
        {
            Almacen item = Helpers.DataGridRowHelper.GetDatagridRow(parameters as MouseButtonEventArgs) as Almacen;

            if (item == null)
                return;

            try
            {

                this.tipoDeOperacion = Enumeration.Operation.Update;

                this.idAgenteAduanal = item.Id;
                this.Nombre = item.Nombre;
                this.Direccion = item.Direccion;

            }
            catch (Exception ex)
            {

            }
        }

        public override void OnClean()
        {
            this.Nombre = string.Empty;
            this.Direccion = string.Empty;
            this.FiltroNombre = string.Empty;
            this.FiltroDireccion = string.Empty;
            this.tipoDeOperacion = Operation.Create;
            this.idAgenteAduanal = -1;
            this.MostrarDatos();
        }

        #endregion
    }
}
