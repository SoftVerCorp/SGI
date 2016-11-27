using SGI.Helpers;
using SGI.Model;
using SGI.Stuffs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SGI.ViewModel.Correo
{
    public class NotificacionDeCorreoVM : ViewModelBase
    {
        private int idUbicacion = -1;
        private int notificacion = -1;

        private string ubicacion;

        private List<TipoDeNotificacion> notificaciones;

        private Usuario usuarioSeleccionado;

        private ObservableCollection<Usuario> usuarios;



        public NotificacionDeCorreoVM()
        {
            try
            {
                idUbicacion = ManejadorUbicacion.IdUbicacion;
                Repository.UsuariosDisponiblesCache = Repository.GetUsuarios(idUbicacion);

                ubicacion = Repository.ObtenerUbicaciones().Where(s => s.Id == idUbicacion).FirstOrDefault().Nombre;

                this.notificaciones = new List<TipoDeNotificacion>();
                this.notificaciones.Add(new TipoDeNotificacion { IdTipoNotificacion = -1, TipoNotificacion = "Seleccionar" });
                this.notificaciones.AddRange(Repository.ObtenerTipoDeNotificacion());

                this.Usuarios = new ObservableCollection<Usuario>();

            }
            catch (Exception ex)
            {

            }
        }

        #region public properties

        public ObservableCollection<Usuario> Usuarios
        {
            get { return usuarios; }
            set
            {
                usuarios = value;
                RaisePropertyChanged(() => Usuarios);
            }
        }

        public Usuario UsuarioSeleccionado
        {
            get { return usuarioSeleccionado; }
            set
            {
                usuarioSeleccionado = value;
                RaisePropertyChanged(() => UsuarioSeleccionado);
            }
        }

        public int Notificacion
        {
            get { return notificacion; }
            set
            {
                notificacion = value;
                RaisePropertyChanged(() => Notificacion);
                ObtenerNotificacionesExistentes();
            }
        }

        public List<TipoDeNotificacion> Notificaciones
        {
            get { return notificaciones; }
        }


        public string Ubicacion
        {
            get { return ubicacion; }
        }

        public ICommand AgregarCmd
        {
            get
            {
                return new RelayCommand(s => AgregarUsuario());
            }
        }

        public ICommand GuardarCmd
        {
            get
            {
                return new RelayCommand(s => GuardarNotificaciones());
            }
        }

        public ICommand EliminarCmd
        {
            get
            {
                return new RelayCommand(EliminarElemento);
            }
        }
        #endregion

        #region Private Methods

        private void ObtenerNotificacionesExistentes()
        {
            try
            {
                this.Usuarios = new ObservableCollection<Usuario>(Repository.ObtenerUsuariosPorNotificacion(ManejadorUbicacion.IdUbicacion, notificacion));
            }
            catch (Exception ex)
            {

            }
        }

        private void EliminarElemento(object value)
        {
            var val = value as Usuario;

            if (val == null)
            {
                return;
            }

            try
            {
                this.Usuarios.Remove(val);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar elemento", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GuardarNotificaciones()
        {
            try
            {
                if (this.Usuarios.Count == 0)
                {
                    MessageBox.Show("No hay datos a guardar");
                    return;
                }

                if (this.Notificacion == -1)
                {
                    MessageBox.Show("Debe seleccionar el tipo de notificacion");
                    return;
                }

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<notificaciones>");

                foreach (var item in Usuarios)
                {
                    sb.AppendLine("<notificacion>");
                    sb.AppendLine("<IdUsuario>" + item.Id + "</IdUsuario>");
                    sb.AppendLine("</notificacion>");
                }
                sb.AppendLine("</notificaciones>");

                var res = Repository.InsertarUsuarioTipoNotificacion(ManejadorUbicacion.IdUbicacion, this.Notificacion, sb.ToString());

                if (res != 0)
                {
                    MessageBox.Show("Error al guardar los datos");
                    return;
                }

                MessageBox.Show("Datos guardados correctamente");
                Limpiar();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ");
            }
        }

        private void Limpiar()
        {
            this.Usuarios = new ObservableCollection<Usuario>();
            this.UsuarioSeleccionado = null;
            this.Notificacion = -1;

        }

        private void AgregarUsuario()
        {
            try
            {
                if (UsuarioSeleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un usuario");
                    return;
                }


                var item = this.Usuarios.Where(s => s.Id == UsuarioSeleccionado.Id).FirstOrDefault();

                if (item != null)
                {
                    MessageBox.Show("El usuario ya existe");
                    return;
                }

                if (string.IsNullOrEmpty(UsuarioSeleccionado.Correo))
                {
                    MessageBox.Show("El usuario no tiene correo! favor de modificarlo");
                    return;
                }

                this.Usuarios.Add(new Usuario { Id = UsuarioSeleccionado.Id, Nombre = UsuarioSeleccionado.Nombre, Correo = UsuarioSeleccionado.Correo });

                this.UsuarioSeleccionado = null;
            }
            catch (Exception ex)
            {

            }
        }

        #endregion
    }
}
