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
using System.Windows.Controls;
using System.Windows.Input;

namespace SGI.ViewModel.Catalogos
{
    public class CatalogoUsuariosVM : ViewModelBase
    {
        #region Private Fields

        private Usuario selectedUsuario;
        private List<Usuario> usuariosList;
        private List<Usuario> listaDeUsersAux;

        private string nombreUsuarioFiltro;
        private string correoFiltro;

        private List<Ubicacion> ubicaciones;
        private int ubicacionSeleccionada;

        private List<TipoUsuario> tipoUsuarios;
        private int tipoUsuarioSeleccionado;

        PasswordBox passwordBox1;
        PasswordBox passwordBox2;


        public int UbicacionSeleccionada
        {
            get { return ubicacionSeleccionada; }
            set
            {
                ubicacionSeleccionada = value;
                RaisePropertyChanged(() => UbicacionSeleccionada);
            }
        }

        public List<Ubicacion> Ubicaciones
        {
            get { return ubicaciones; }
        }

        #endregion

        #region Public Fields

        public event EventHandler OnAddUser;

        #endregion

        #region Public Properties

        public int TipoUsuarioSeleccionado
        {
            get { return tipoUsuarioSeleccionado; }
            set
            {
                tipoUsuarioSeleccionado = value;
                RaisePropertyChanged(() => TipoUsuarioSeleccionado);
            }
        }

        public List<TipoUsuario> TipoUsuarios
        {
            get { return tipoUsuarios; }

        }


        /// <summary>
        /// Obtiene o establece el nombre del proveedor para realizar la busqueda
        /// </summary>
        public string NombreUsuarioFiltro
        {
            get { return nombreUsuarioFiltro; }
            set
            {
                if (nombreUsuarioFiltro != value)
                {
                    nombreUsuarioFiltro = value;
                    RaisePropertyChanged(() => NombreUsuarioFiltro);
                    BusquedaAsincrona();
                }
            }
        }


        /// <summary>
        /// Obtiene o establece la razon social para realizar la busqueda
        /// </summary>
        public string CorreoFiltro
        {
            get { return correoFiltro; }
            set
            {
                if (correoFiltro != value)
                {
                    correoFiltro = value;
                    RaisePropertyChanged(() => CorreoFiltro);
                    BusquedaAsincrona();
                }
            }
        }

        public Usuario SelectedUsuario
        {
            get { return this.selectedUsuario; }
            set
            {
                this.selectedUsuario = value;
                RaisePropertyChanged(() => SelectedUsuario);

            }
        }

        public List<Usuario> UsuariosList
        {
            get { return this.usuariosList; }
            set
            {
                this.usuariosList = value;
                RaisePropertyChanged(() => UsuariosList);

            }
        }

        public ICommand TomarFotoCmd
        {
            get
            {
                return new RelayCommand(s => this.TomarFoto());
            }
        }

        #endregion

        #region Constructors

        public CatalogoUsuariosVM()
        {
            try
            {
                this.SelectedUsuario = new Usuario();
                this.OperationType = Enumeration.Operation.Create;

                this.ubicaciones = new List<Ubicacion>();
                this.ubicaciones.Add(new Ubicacion { Id = -1, Nombre = "Seleccionar" });
                this.ubicaciones.AddRange(Repository.ObtenerUbicaciones());
                //this.UbicacionSeleccionada = -1;
                this.SelectedUsuario.IdUbicacion = ManejadorUbicacion.IdUbicacion;

                this.tipoUsuarios = new List<TipoUsuario>();
                this.tipoUsuarios.Add(new TipoUsuario { Id = -1, TipoUsuarioSistema = "Seleccionar" });
                this.tipoUsuarios.AddRange(Repository.ObtenerTipoUsuario());
                this.SelectedUsuario.IdTipoUsuario = -1;
                //this.TipoUsuarioSeleccionado = -1;
                OnRefresh();
            }
            catch (Exception)
            {

            }
        }

        public RelayCommand Actualizar
        {
            get { return new RelayCommand(s => ActualizaUsuario()); }
        }
        public RelayCommand Agregar
        {
            get { return new RelayCommand(s => AgregarUsuario()); }
        }
        public RelayCommand Eliminar
        {
            get { return new RelayCommand(s => EliminarUsuario()); }
        }

        public RelayCommand Limpiar
        {
            get { return new RelayCommand(s => LimpiarCampos()); }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand ContentRendered
        {
            get
            {
                return new RelayCommand(this.OnContentRendered);
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
                    var fileName = "CatalogoUsuarios.xls";

                    var dataTable = ExportToExcel.ListToDataTable(this.UsuariosList);

                    ExportToExcel.ExportDocument(dataTable, "Catalogo de Usuarios", pathFile + "/" + fileName);

                    System.Windows.MessageBox.Show("Archivo exportado correctamente");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al exportar archivo de excel");
            }
        }


        private void OnContentRendered(object param)
        {
            try
            {
                var window = param as Window;

                if (window != null)
                {
                    passwordBox1 = window.FindName("pass1") as PasswordBox;
                    passwordBox2 = window.FindName("pass2") as PasswordBox;
                }
            }
            catch (Exception ex)
            {

            }
        }


        private void TomarFoto()
        {
            try
            {
                var tomarfoto = new foto();
                tomarfoto.ShowDialog();

                SelectedUsuario.Foto = tomarfoto.Ruta;
            }
            catch (Exception ex)
            {

            }
        }

        public async void BusquedaAsincrona()
        {
            try
            {
                this.UsuariosList = await Task.Run(() => this.ObtenerListaDeUsuariosAsync());
            }
            catch (Exception ex)
            {

            }
        }

        private void ActualizaUsuario()
        {
            if (SelectedUsuario == null)
                MessageBox.Show("Selecciona un proveedor...", "Informacion", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            if (MessageBox.Show("¿Realmente deseas actualizar la informacion del usuario?", "usuarios", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                // Repository.AdminUsuarios(SelectedUsuario, 2);
            }
            OnRefresh();
        }

        private void AgregarUsuario()
        {
            try
            {
                if (this.SelectedUsuario.IdTipoUsuario == -1)
                {
                    MessageBox.Show("Debe seleccionar el tipo de usuario");
                    return;
                }

                if (!string.IsNullOrEmpty(passwordBox1.Password))
                {
                    if (!passwordBox1.Password.ToUpper().Equals(passwordBox2.Password.ToUpper()))
                    {
                        MessageBox.Show("No coincide la contraseña", "Error al ingresar contraseña", MessageBoxButton.OK, MessageBoxImage.Error);
                        passwordBox1.Password = string.Empty;
                        passwordBox2.Password = string.Empty;
                        return;
                    }
                }

                if (this.OperationType == Operation.Create)
                {

                    if (MessageBox.Show("¿Realmente deseas agregar este usuario?", "usuarios", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                    {
                        int idError = 0;
                        string errorMsg = string.Empty;



                        SelectedUsuario.Password = passwordBox1.Password;

                        Repository.AdminUsuarios(SelectedUsuario, 1, ref idError, ref errorMsg);

                        if (idError != 0)
                        {
                            MessageBox.Show("Error " + errorMsg);
                            return;
                        }

                        MessageBox.Show("Usuario almacenado correctamente");
                        OnRefresh();
                        LimpiarCampos();
                    }
                }
                else
                {
                    if (this.OperationType == Operation.Update)
                    {
                        int idError = 0;
                        string errorMsg = string.Empty;

                        try
                        {
                            if (MessageBox.Show("¿Realmente deseas modificar este usuario?", "usuarios", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                            {
                                Repository.AdminUsuarios(SelectedUsuario, 2, ref idError, ref errorMsg);
                                OnRefresh();
                                LimpiarCampos();
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error modificando usuario");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
              
            }
        }
        private void EliminarUsuario()
        {
            if (SelectedUsuario == null)
            {
                MessageBox.Show("Selecciona un usuario...", "Informacion", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            int idError = 0;
            string errorMsg = string.Empty;

            if (MessageBox.Show("¿Realmente deseas eliminar el usuario seleccionado?", "usuarios", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                try
                {
                    Repository.AdminUsuarios(SelectedUsuario, 3, ref idError, ref errorMsg);
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error eliminando usuario");
                }
            }
            OnRefresh();
        }

        private void LimpiarCampos()
        {
            try
            {
                SelectedUsuario = new Usuario()
                {
                    Id = -1,
                    Nombre = string.Empty,
                    Codigo = string.Empty,
                    Foto = string.Empty,
                    Correo = string.Empty,
                    Active = false,
                    IdTipoUsuario = -1,
                    IdUbicacion = ManejadorUbicacion.IdUbicacion,
                    Password = string.Empty
                };

                this.NombreUsuarioFiltro = string.Empty;
                this.CorreoFiltro = string.Empty;

                passwordBox1.Password = string.Empty;
                passwordBox2.Password = string.Empty;

                this.OperationType = Operation.Create;
            }
            catch (Exception ex)
            {

            }

        }


        private async Task<List<Usuario>> ObtenerListaDeUsuariosAsync()
        {
            List<Usuario> lst = new List<Usuario>();

            try
            {
                var aux = this.listaDeUsersAux;

                lst = aux.Where(
                      s =>
                         (

                          (
                          (!string.IsNullOrEmpty(this.NombreUsuarioFiltro) ? s.Nombre.ToUpper().Contains(this.NombreUsuarioFiltro.ToUpper()) : true)
                          &&
                          (!string.IsNullOrEmpty(this.CorreoFiltro) ? s.Correo.ToUpper().Contains(this.CorreoFiltro.ToUpper()) : true)
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


        private void OnRefresh()
        {
            try
            {
                this.UsuariosList = Repository.GetUsuarios(this.SelectedUsuario.IdUbicacion);
                this.listaDeUsersAux = Repository.GetUsuarios(this.SelectedUsuario.IdUbicacion);
            }
            catch (Exception ex)
            {

            }
        }

        public override void OnSelectedItemGridClick(object parameters)
        {
            Usuario item = Helpers.DataGridRowHelper.GetDatagridRow(parameters as MouseButtonEventArgs) as Usuario;

            if (item == null)
                return;

            this.OperationType = Operation.Update;

            try
            {
                this.SelectedUsuario = item;

                if (this.OnAddUser != null)
                {
                    this.OnAddUser(this, null);
                }
                OnClose();
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

    }
}
