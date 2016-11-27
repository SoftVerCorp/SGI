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

namespace SGI.ViewModel.Contabilidad
{
    public class EmpleadosViewModel : ViewModelBase
    {
        #region Constructor

        public EmpleadosViewModel()
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
            //Repository.EmpleadosCache = Repository.GetEmployees("");
            this.SelectedEmpleado = new Empleado();
            this.IsEnabledFind = false;
        }

        #endregion

        #region private field

        private Empleado _selectedEmpleado;

        private List<Empleado> _empleados;

        private bool _isEnabledFind;

        private bool _isEnabled;

        private List<Puesto> _puestos;

        private Puesto _selectedPuesto;

        private List<Sexo> _sexos;

        private Sexo _selectedSexo;

        private List<EstadoCivil> _tipoEstadoCivil;

        private EstadoCivil _selectedEstadoCivil;

        #endregion

        #region public field


        public Empleado SelectedEmpleado
        {
            get
            {
                return _selectedEmpleado;
            }

            set
            {
                _selectedEmpleado = value;
                RaisePropertyChanged(() => SelectedEmpleado);

                if (value != null)
                {
                    if (value.Id > 0)
                        Buscar();
                }
            }
        }

        public List<Empleado> Empleados
        {
            get
            {
                return _empleados;
            }

            set
            {
                _empleados = value;
                RaisePropertyChanged(() => Empleados);
            }
        }

        public bool IsEnabledFind
        {
            get
            {
                return _isEnabledFind;
            }

            set
            {
                _isEnabledFind = value;
                RaisePropertyChanged(() => this.IsEnabledFind);
            }
        }

        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }

            set
            {
                _isEnabled = value;
                RaisePropertyChanged(() => this.IsEnabled);
            }
        }


        public List<Puesto> Puestos
        {
            get
            {
                return _puestos;
            }

            set
            {
                _puestos = value;
                RaisePropertyChanged(() => this.Puestos);
            }
        }

        public Puesto SelectedPuesto
        {
            get
            {
                return _selectedPuesto;
            }

            set
            {
                _selectedPuesto = value;
                RaisePropertyChanged(() => this.SelectedPuesto);
            }
        }

        public List<Sexo> Sexos
        {
            get
            {
                return _sexos;
            }

            set
            {
                _sexos = value;
                RaisePropertyChanged(() => this.Sexos);
            }
        }

        public Sexo SelectedSexo
        {
            get
            {
                return _selectedSexo;
            }

            set
            {
                _selectedSexo = value;
                RaisePropertyChanged(() => this.SelectedSexo);
            }
        }

        public List<EstadoCivil> TipoEstadoCivil
        {
            get
            {
                return _tipoEstadoCivil;
            }

            set
            {
                _tipoEstadoCivil = value;
                RaisePropertyChanged(() => this.TipoEstadoCivil);
            }
        }

        public EstadoCivil SelectedEstadoCivil
        {
            get
            {
                return _selectedEstadoCivil;
            }

            set
            {
                _selectedEstadoCivil = value;
                RaisePropertyChanged(() => this.SelectedEstadoCivil);
            }
        }


        #endregion

        #region Comandos

        public ICommand SalirCmd
        {
            get
            {
                return new RelayCommand(s => OnSalir());
            }
        }

        public ICommand BuscarCmd
        {
            get
            {
                return new RelayCommand(s => OnBuscar());
            }
        }

        public ICommand NuevoCmd
        {
            get
            {
                return new RelayCommand(s => OnNuevo());
            }
        }

        public ICommand CancelarCmd
        {
            get
            {
                return new RelayCommand(s => OnCancelar());
            }
        }

        public ICommand EditarCmd
        {
            get
            {
                return new RelayCommand(s => OnEditar());
            }
        }

        public ICommand GuardarCmd
        {
            get
            {
                return new RelayCommand(s => OnGuardar());
            }
        }

        #endregion

        #region Private Method

        private void OnGuardar()
        {
            if (SelectedEstadoCivil == null)
            {
                MessageBox.Show("Debe seleccionar un estado civil");
                return;
            }

            this.SelectedEmpleado.EstadoCivil = SelectedEstadoCivil.Nombre;

            if (SelectedSexo == null)
            {
                MessageBox.Show("Debe seleccionar un sexo");
                return;
            }

            this.SelectedEmpleado.Sexo = SelectedSexo.Nombre;

            if (SelectedPuesto == null)
            {
                MessageBox.Show("Debe seleccionar un puesto");
                return;
            }

            this.SelectedEmpleado.IdPuesto = SelectedPuesto.IdPuesto;
            this.SelectedEmpleado.Salario = SelectedPuesto.Salario;

            int error = 0;
            string errorMessage = string.Empty;
            Repository.InsEmployee(this.SelectedEmpleado, ManejadorUbicacion.IdUbicacion, ref error, ref errorMessage);

        }

        private void OnEditar()
        {
            if (this.SelectedEmpleado != null)
            {
                this.IsEnabled = true;
            }
        }

        private void OnSalir()
        {
            foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
                }
            }
        }

        private void OnBuscar()
        {
            Repository.EmpleadosCache = Repository.GetEmployees("", ManejadorUbicacion.IdUbicacion);
            this.IsEnabledFind = true;
        }

        private void Buscar()
        {
            Puestos = Repository.GetPuesto(ManejadorUbicacion.IdUbicacion);
            Sexos = Repository.GetSexos();
            TipoEstadoCivil = Repository.GetEstadoCivil();

            this.SelectedEstadoCivil = TipoEstadoCivil.Where(s => s.Nombre == SelectedEmpleado.EstadoCivil).FirstOrDefault();
            this.SelectedSexo = Sexos.Where(s => s.Nombre == SelectedEmpleado.Sexo).FirstOrDefault();
            this.SelectedPuesto = Puestos.Where(s => s.IdPuesto == SelectedEmpleado.IdPuesto).FirstOrDefault();

            this.IsEnabledFind = false;
        }

        private void OnNuevo()
        {
            this.IsEnabled = true;
            SelectedEmpleado = new Empleado();
            Puestos = Repository.GetPuesto(ManejadorUbicacion.IdUbicacion);
            Sexos = Repository.GetSexos();
            TipoEstadoCivil = Repository.GetEstadoCivil();

            this.IsEnabledFind = false;
        }

        private void OnCancelar()
        {
            this.IsEnabled = false;
            SelectedEmpleado = null;
            this.IsEnabledFind = false;
        }

        #endregion
    }
}
