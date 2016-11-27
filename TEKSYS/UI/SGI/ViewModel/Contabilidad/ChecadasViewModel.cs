using SGI.Helpers;
using SGI.Model;
using SGI.Stuffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SGI.ViewModel.Contabilidad
{
    public class ChecadasViewModel : ViewModelBase
    {
        #region Contructor

        public ChecadasViewModel()
        {
            try
            {
                this.InicializarDatos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void InicializarDatos()
        {
            Repository.EmpleadosCache = Repository.GetEmployees("", ManejadorUbicacion.IdUbicacion);
        }

        #endregion

        #region Commands

        public ICommand SalirCmd
        {
            get
            {
                return new RelayCommand(s => OnSalirClient());
            }
        }

        public ICommand RegistrarCmd
        {
            get
            {
                return new RelayCommand(s => OnRegistrar());
            }
        }

        public ICommand ModificarCmd
        {
            get
            {
                return new RelayCommand(s => OnModificar());
            }
        }

        public ICommand RegistrarFaltaCmd
        {
            get
            {
                return new RelayCommand(s => OnRegistrarFalta());
            }
        }

        //public ICommand BuscarCmd
        //{
        //    get
        //    {
        //        return new RelayCommand(s => OnBuscarEmpleado());
        //    }
        //}


        #endregion

        #region Private Method

        public void Buscar()
        {
            ChecadasMes = Repository.GetChecadas(SelectedEmpleado.Id);
        }

        public void OnRegistrar()
        {
            if (Repository.RegistrarChecadas(SelectedEmpleado.Id))
            {
                Buscar();
            }
            else
            {
                System.Windows.MessageBox.Show("Checada no registrada");
            }
        }

        public void OnModificar()
        {

        }

        public void OnRegistrarFalta()
        {

        }

        //public void OnBuscarEmpleado()
        //{
        //    Repository.EmpleadosCache = Repository.GetEmployees("", ManejadorUbicacion.IdUbicacion);
        //}

        public void OnSalirClient()
        {
            foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
                }
            }
        }

        #endregion

        #region private field

        //private bool _isEnabledFind;

        private Empleado _selectedEmpleado;

        private List<Checadas> _checadasMes;

        private string _fechaActual;

        #endregion

        #region public field

        //public bool IsEnabledFind
        //{
        //    get
        //    {
        //        return _isEnabledFind;
        //    }

        //    set
        //    {
        //        _isEnabledFind = value;
        //        RaisePropertyChanged(() => this.IsEnabledFind);
        //    }
        //}

        public Empleado SelectedEmpleado
        {
            get
            {
                return _selectedEmpleado;
            }

            set
            {
                _selectedEmpleado = value;
                if (value != null && value.Id > 0)
                {
                    Buscar();
                }
            }
        }

        public List<Checadas> ChecadasMes
        {
            get
            {
                return _checadasMes;
            }

            set
            {
                _checadasMes = value;
                if (value != null)
                {
                    RaisePropertyChanged(() => this.ChecadasMes);
                }
            }
        }

        public string FechaActual
        {
            get
            {
                return _fechaActual;
            }
            set
            {
                _fechaActual = value;
                if (value != null)
                {
                    RaisePropertyChanged(() => this.FechaActual);
                }
            }
        }


        #endregion

    }
}
