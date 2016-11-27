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
    public class NewUserViewVM : ViewModelBase
    {
        #region Private Fields

        private string userName;



        PasswordBox passwordBox1;
        PasswordBox passwordBox2;

        #endregion

        #region Constructors

        public NewUserViewVM()
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Obtiene o establece el nombre de usuario.
        /// </summary>
        public string UserName
        {
            get { return userName; }
            set
            {
                if (userName != value)
                {
                    userName = value;
                    RaisePropertyChanged(() => UserName);
                }
            }
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

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        public override void OnAccept()
        {
            if (passwordBox1 != null && passwordBox2 != null)
            {
                try
                {
                    if (string.IsNullOrEmpty(this.UserName))
                    {
                        MessageBox.Show("Debe ingresar el nombre del usuario", "Error al ingresar usuario", MessageBoxButton.OK, MessageBoxImage.Error);
                        passwordBox1.Password = string.Empty;
                        passwordBox2.Password = string.Empty;
                        return;
                    }

                    if (string.IsNullOrEmpty(passwordBox1.Password))
                    {
                        MessageBox.Show("Debe ingresar una contraseña", "Error al ingresar contraseña", MessageBoxButton.OK, MessageBoxImage.Error);
                        passwordBox1.Password = string.Empty;
                        passwordBox2.Password = string.Empty;
                        return;
                    }

                    if (string.IsNullOrEmpty(passwordBox2.Password))
                    {
                        MessageBox.Show("Debe ingresarla verificacion de contraseña", "Error al ingresar contraseña", MessageBoxButton.OK, MessageBoxImage.Error);
                        passwordBox1.Password = string.Empty;
                        passwordBox2.Password = string.Empty;
                        return;
                    }

                    if (!passwordBox1.Password.ToUpper().Equals(passwordBox2.Password.ToUpper()))
                    {
                        MessageBox.Show("No coincide la contraseña", "Error al ingresar contraseña", MessageBoxButton.OK, MessageBoxImage.Error);
                        passwordBox1.Password = string.Empty;
                        passwordBox2.Password = string.Empty;                        
                        return;
                    }

                    int error = 0;
                    string msg = string.Empty;

                    var result = Repository.InsUser(UserName, passwordBox1.Password, ref error, ref msg);

                    if (error < 0)
                    {
                        MessageBox.Show("Error al guardar usuario " + msg, "Error al ingresar usuario", MessageBoxButton.OK, MessageBoxImage.Error);
                        passwordBox1.Password = string.Empty;
                        passwordBox2.Password = string.Empty;
                        return;
                    }

                    MessageBox.Show("Usuario almacenado con exito");

                    OnClose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.ToString(), "Error al ingresar usuario", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        #endregion

    }
}
