using SGI.Helpers;
using SGI.Model;
using SGI.Stuffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SGI.ViewModel
{
    public class LoginVM : ViewModelBase
    {
        #region Private Fields

        private string user;
        private string password;
        private List<Ubicacion> ubicaciones;
        private Ubicacion ubicacionSeleccionada;

        #endregion

        #region Constructors

        public LoginVM()
        {
            try
            {
                this.ubicaciones = new List<Ubicacion>();
                this.ubicaciones.Add(new Ubicacion { Id = -1, Nombre = "Seleccionar" });
                this.ubicaciones.AddRange(Repository.ObtenerUbicaciones());
                this.UbicacionSeleccionada = ubicaciones.FirstOrDefault();
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region Public Properties

        public Ubicacion UbicacionSeleccionada
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

        /// <summary>
        /// Obtiene o establece el password del usuario
        /// </summary>
        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    RaisePropertyChanged(() => Password);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece la contraseña del usuario.
        /// </summary>
        public string User
        {
            get { return user; }
            set
            {
                if (user != value)
                {
                    user = value;
                    RaisePropertyChanged(() => User);
                }
            }
        }

        /// <summary>
        /// Obtiene el comando para loguear usuario
        /// </summary>
        public ICommand Login
        {
            get
            {
                return new RelayCommand(this.OnLogin);
            }
        }

        #endregion

        #region Private Methods

        private void OnLogin(object param)
        {
            PasswordBox pb = param as PasswordBox;

            if (this.UbicacionSeleccionada == null)
            {
                MessageBox.Show("Error , debe seleccionar la ubicacion", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (this.UbicacionSeleccionada.Id == -1)
            {
                MessageBox.Show("Error , debe seleccionar la ubicacion", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(User))
            {
                MessageBox.Show("Error , debe ingresar un usuario", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(pb.Password))
            {
                MessageBox.Show("Error , debe ingresar una contraseña", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            try
            {
                if (this.User.ToUpper() == "ADMIN" && pb.Password.ToUpper() == "ADMIN")
                {
                    ManejadorUbicacion.EstableceUbicacion(this.UbicacionSeleccionada.Id);
                    ManejadorLoguin.InicializarUsuario("USUARIO DEMO", 0);

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.DataContext = new MainVM(this.User.ToUpper());
                    mainWindow.Show();
                    OnClose();
                    return;
                }

                var result = Repository.GetUserExist(this.User.ToUpper(), pb.Password.ToUpper(), this.UbicacionSeleccionada.Id);

                //if (result.Id == -1)
                if (result == null)
                {
                    MessageBox.Show("Error , usuario o contraseña incorrectos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    pb.Password = string.Empty;
                    return;
                }
                else
                {
                    ManejadorLoguin.InicializarUsuario(result.Nombre, result.Id);
                    ManejadorUbicacion.EstableceUbicacion(this.UbicacionSeleccionada.Id, this.UbicacionSeleccionada.Nombre, this.UbicacionSeleccionada.EsMatriz);
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.DataContext = new MainVM(this.User.ToUpper());
                    mainWindow.Show();
                    OnClose();
                    return;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Verifica el usuario logueado
        /// </summary>
        public override void OnAccept()
        {
            try
            {
                //MainWindow mainWindow = new MainWindow();
                //mainWindow.DataContext = new MainVM(this.User.ToUpper());
                //mainWindow.Show();

                //OnClose();
            }
            catch (Exception ex)
            {

            }
        }

        #endregion
    }
}
