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
    public class CatalogoClienteViewModel : ViewModelBase
    {
        #region Constructor

        public CatalogoClienteViewModel()
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

        #endregion

        #region Private Fields

        private List<Cliente> _clientes;
        private List<TipoCliente> _tipoDeClientes;
        private List<TipoPersona> _tipoDePersonas;
        private Cliente _selectedCliente;
        private TipoCliente _tipodeCliente;
        private TipoPersona _tipoPersona;
        private bool _isEnabled;
        private bool incobrable;
        private string nombrefiscal;
        private string rfc;
        private string direccion;
        private string colonia;
        private int cp;
        private string estado;
        private string ciudad;
        private string zona;
        private string nombreComercial;
        private string paginaWeb;
        private string contacto;
        private string telefonoContacto;
        private string direccionEnvio;
        private string telefono1;
        private string telefono2;
        private string telefono3;
        private string celular;
        private string fax;
        private string email;
        private int diasDeCredito;
        private double saldoInicial;
        private double limiteDeCredito;
        private string usuario;
        private string password;
        private bool permitirComprasInternet;
        private bool habilitatBtnGuardar = true;
        private bool habilitatBtnModificar;
        private bool habilitatBtnEliminar;
        private double _saldoCliente;
        private double _saldoAFavor;
        private double _creditoUtilizado;
        private double _totalCreditoUtilizado;
        private double _traspasos;
        private bool _isEnabledFind;

        #endregion

        #region public fields

        public bool HabilitatBtnEliminar
        {
            get { return habilitatBtnEliminar; }
            set
            {
                habilitatBtnEliminar = value;
                RaisePropertyChanged(() => HabilitatBtnEliminar);
            }
        }

        public bool HabilitatBtnModificar
        {
            get { return habilitatBtnModificar; }
            set
            {
                habilitatBtnModificar = value;
                RaisePropertyChanged(() => HabilitatBtnModificar);
            }
        }

        public bool HabilitatBtnGuardar
        {
            get { return habilitatBtnGuardar; }
            set
            {
                habilitatBtnGuardar = value;
                RaisePropertyChanged(() => HabilitatBtnGuardar);
            }
        }

        public bool PermitirComprasInternet
        {
            get { return permitirComprasInternet; }
            set
            {
                permitirComprasInternet = value;
                RaisePropertyChanged(() => PermitirComprasInternet);
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        public string Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
                RaisePropertyChanged(() => Usuario);
            }
        }

        public double LimiteDeCredito
        {
            get { return limiteDeCredito; }
            set
            {
                limiteDeCredito = value;
                RaisePropertyChanged(() => LimiteDeCredito);
            }
        }

        public double SaldoInicial
        {
            get { return saldoInicial; }
            set
            {
                saldoInicial = value;
                RaisePropertyChanged(() => SaldoInicial);
            }
        }

        public int DiasDeCredito
        {
            get { return diasDeCredito; }
            set
            {
                diasDeCredito = value;
                RaisePropertyChanged(() => DiasDeCredito);
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                RaisePropertyChanged(() => Email);
            }
        }

        public string Fax
        {
            get { return fax; }
            set
            {
                fax = value;
                RaisePropertyChanged(() => Fax);
            }
        }

        public string Celular
        {
            get { return celular; }
            set
            {
                celular = value;
                RaisePropertyChanged(() => Celular);
            }
        }

        public string Telefono3
        {
            get { return telefono3; }
            set
            {
                telefono3 = value;
                RaisePropertyChanged(() => Telefono3);
            }
        }

        public string Telefono2
        {
            get { return telefono2; }
            set
            {
                telefono2 = value;
                RaisePropertyChanged(() => Telefono2);
            }
        }

        public string Telefono1
        {
            get { return telefono1; }
            set
            {
                telefono1 = value;
                RaisePropertyChanged(() => Telefono1);
            }
        }

        public string DireccionEnvio
        {
            get { return direccionEnvio; }
            set
            {
                direccionEnvio = value;
                RaisePropertyChanged(() => DireccionEnvio);
            }
        }

        public string TelefonoContacto
        {
            get { return telefonoContacto; }
            set
            {
                telefonoContacto = value;
                RaisePropertyChanged(() => TelefonoContacto);
            }
        }

        public string Contacto
        {
            get { return contacto; }
            set
            {
                contacto = value;
                RaisePropertyChanged(() => Contacto);
            }
        }

        public string PaginaWeb
        {
            get { return paginaWeb; }
            set
            {
                paginaWeb = value;
                RaisePropertyChanged(() => PaginaWeb);
            }
        }

        public string NombreComercial
        {
            get { return nombreComercial; }
            set
            {
                nombreComercial = value;
                RaisePropertyChanged(() => NombreComercial);
            }
        }

        public string Zona
        {
            get { return zona; }
            set
            {
                zona = value;
                RaisePropertyChanged(() => Zona);
            }
        }

        public string Ciudad
        {
            get { return ciudad; }
            set
            {
                ciudad = value;
                RaisePropertyChanged(() => Ciudad);
            }
        }

        public string Estado
        {
            get { return estado; }
            set
            {
                estado = value;
                RaisePropertyChanged(() => Estado);
            }
        }

        public int Cp
        {
            get { return cp; }
            set
            {
                cp = value;
                RaisePropertyChanged(() => Cp);
            }
        }

        public string Colonia
        {
            get { return colonia; }
            set
            {
                colonia = value;
                RaisePropertyChanged(() => Colonia);
            }
        }

        public string Direccion
        {
            get { return direccion; }
            set
            {
                direccion = value;
                RaisePropertyChanged(() => Direccion);
            }
        }

        public string Rfc
        {
            get { return rfc; }
            set
            {
                rfc = value;
                RaisePropertyChanged(() => Rfc);
            }
        }

        public string Nombrefiscal
        {
            get { return nombrefiscal; }
            set
            {
                nombrefiscal = value;
                RaisePropertyChanged(() => Nombrefiscal);
            }
        }

        public bool Incobrable
        {
            get { return incobrable; }
            set
            {
                incobrable = value;
                RaisePropertyChanged(() => Incobrable);
            }
        }

        public List<TipoCliente> TipoDeClientes
        {
            get
            {
                return _tipoDeClientes;
            }

            set
            {
                _tipoDeClientes = value;
                RaisePropertyChanged(() => TipoDeClientes);
            }
        }

        public Cliente SelectedCliente
        {
            get
            {
                return _selectedCliente;
            }

            set
            {
                _selectedCliente = value;
                RaisePropertyChanged(() => SelectedCliente);

                if (SelectedCliente != null)
                {
                    if (SelectedCliente.IdCliente != -1)
                    {
                        HabilitatBtnModificar = true;
                        HabilitatBtnEliminar = true;
                        HabilitatBtnGuardar = false;
                        BuscarCliente();
                    }
                }

            }
        }

        public List<TipoPersona> TipoDePersonas
        {
            get
            {
                return _tipoDePersonas;
            }

            set
            {
                _tipoDePersonas = value;
                RaisePropertyChanged(() => TipoDePersonas);
            }
        }

        public TipoCliente TipodeCliente
        {
            get
            {
                return _tipodeCliente;
            }

            set
            {
                _tipodeCliente = value;
                RaisePropertyChanged(() => TipodeCliente);
            }
        }

        public TipoPersona TipoPersona
        {
            get
            {
                return _tipoPersona;
            }

            set
            {
                _tipoPersona = value;
                RaisePropertyChanged(() => TipoPersona);
            }
        }

        public double SaldoCliente
        {
            get
            {
                return _saldoCliente;
            }

            set
            {
                _saldoCliente = value;
                RaisePropertyChanged(() => SaldoCliente);
            }
        }

        public double SaldoAFavor
        {
            get
            {
                return _saldoAFavor;
            }

            set
            {
                _saldoAFavor = value;
                RaisePropertyChanged(() => SaldoAFavor);
            }
        }

        public double CreditoUtilizado
        {
            get
            {
                return _creditoUtilizado;
            }

            set
            {
                _creditoUtilizado = value;
                RaisePropertyChanged(() => CreditoUtilizado);
            }
        }

        public double TotalCreditoUtilizado
        {
            get
            {
                return _totalCreditoUtilizado;
            }

            set
            {
                _totalCreditoUtilizado = value;
                RaisePropertyChanged(() => TotalCreditoUtilizado);
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
                RaisePropertyChanged(() => IsEnabled);
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
                RaisePropertyChanged(() => IsEnabledFind);
            }

        }

        public double Traspasos
        {
            get
            {
                return _traspasos;
            }

            set
            {
                _traspasos = value;
                RaisePropertyChanged(() => Traspasos);
            }
        }

        #endregion

        private void InicializarDatos()
        {
            try
            {
                this.TipoDeClientes = Repository.ObtenerTipoClientes();
                this.TipoDePersonas = Repository.GetTipoDePersona();
                Repository.ClientesCache = Repository.GetClientes(-1);
                this.SelectedCliente = new Cliente();
                this.IsEnabled = false;
            }
            catch (Exception ex)
            {

            }
        }

        public ICommand BuscarCmd
        {
            get
            {
                return new RelayCommand(s => OnBuscarClient());
            }
        }

        private void OnBuscarClient()
        {
            Repository.ClientesCache = Repository.GetClientes(ManejadorUbicacion.IdUbicacion);
            this.IsEnabledFind = true;
        }

        private void BuscarCliente()
        {
            if (SelectedCliente == null)
            {
                return;
            }

            var cl = Repository.GetCliente(SelectedCliente.IdCliente, ManejadorUbicacion.IdUbicacion);

            if (cl == null)
                return;

            TipodeCliente = TipoDeClientes.Where(s => s.Id == cl.IdTipoCliente).FirstOrDefault();
            //cl.IdTipoCliente = TipodeCliente.Id;
            this.Incobrable = cl.Incobrable;
            //cl.IdUbicacion = ManejadorUbicacion.IdUbicacion;
            //cl.IdUsario = ManejadorLoguin.idUsuario;
            this.Nombrefiscal = cl.NombreFiscal;
            this.Rfc = cl.RFC;
            this.TipoPersona = TipoDePersonas.Where(s => s.Id == cl.IdTipoPersona).FirstOrDefault();
            this.TipoPersona.Id = cl.IdTipoPersona;
            this.Direccion = cl.Direccion;
            this.Colonia = cl.Colonia;
            this.Cp = Convert.ToInt32(cl.CP);
            this.Estado = cl.Estado;
            this.Ciudad = cl.Ciudad;
            this.Zona = cl.Zona;
            this.NombreComercial = cl.NombreComercial;
            this.PaginaWeb = cl.PaginaWeb;
            this.Contacto = cl.Contacto;
            this.TelefonoContacto = cl.TelefonoContacto;
            this.DireccionEnvio = cl.DireccionEnvio;
            this.Telefono1 = cl.Telefono1;
            this.Telefono2 = cl.Telefono2;
            this.Telefono3 = cl.Telefono3;
            this.Celular = cl.Celular == null ? string.Empty : cl.Celular.ToString();
            this.Fax = cl.Fax;
            this.Email = cl.Email;
            this.DiasDeCredito = cl.DiasCredito;
            this.SaldoInicial = cl.SaldoInicial;
            this.LimiteDeCredito = cl.LimiteDeCredito;

            this.SaldoCliente = cl.SaldoDelCliente;
            this.SaldoAFavor = cl.SaldoAFavor;
            this.CreditoUtilizado = cl.CreditoUtilizado;
            this.TotalCreditoUtilizado = cl.TotalCreditoUtilizado;
            this.Traspasos = cl.TotalTraspaso;

            this.Usuario = cl.Usuario;
            this.Password = cl.Password;
            this.PermitirComprasInternet = cl.PermitirComprarPorInternet;
            IsEnabled = false;
            IsEnabledFind = false;
        }

        public ICommand GuardarCmd
        {
            get
            {
                return new RelayCommand(s => OnGuardar());
            }
        }

        private void OnGuardar()
        {
            try
            {
                if (TipodeCliente == null)
                {
                    MessageBox.Show("Debe seleccionar un tipo de cliente");
                    return;
                }

                if (TipoPersona == null)
                {
                    MessageBox.Show("Debe seleccionar un tipo de persona");
                    return;
                }


                Cliente cliente = new Cliente();
                cliente.IdTipoCliente = TipodeCliente.Id;
                cliente.Incobrable = this.Incobrable;
                cliente.IdUbicacion = ManejadorUbicacion.IdUbicacion;
                cliente.IdUsario = ManejadorLoguin.idUsuario;
                cliente.NombreFiscal = this.Nombrefiscal;
                cliente.RFC = this.Rfc;
                cliente.IdTipoPersona = this.TipoPersona.Id;
                cliente.Direccion = this.Direccion;
                cliente.Colonia = this.Colonia;
                cliente.CP = this.Cp.ToString();
                cliente.Estado = this.Estado;
                cliente.Ciudad = this.Ciudad;
                cliente.Zona = this.Zona;
                cliente.NombreComercial = this.NombreComercial;
                cliente.PaginaWeb = this.PaginaWeb;
                cliente.Contacto = this.Contacto;
                cliente.TelefonoContacto = this.TelefonoContacto;
                cliente.DireccionEnvio = this.DireccionEnvio;
                cliente.Telefono1 = this.Telefono1;
                cliente.Telefono2 = this.Telefono2;
                cliente.Telefono3 = this.Telefono3;
                cliente.Celular = this.Celular;
                cliente.Fax = this.Fax;
                cliente.Email = this.Email;
                cliente.DiasCredito = this.DiasDeCredito;
                cliente.SaldoInicial = this.SaldoInicial;
                cliente.LimiteDeCredito = this.LimiteDeCredito;
                cliente.Usuario = this.Usuario;
                cliente.Password = this.Password;
                cliente.PermitirComprarPorInternet = this.PermitirComprasInternet;
                Repository.InsCliente(cliente);
                Limpiar();
                MessageBox.Show("Cliente guardado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error guardado cliente");
            }
        }

        public ICommand LimpiarCmd
        {
            get
            {
                return new RelayCommand(s => Limpiar());
            }
        }

        private void Limpiar()
        {
            try
            {
                this.TipodeCliente = null;
                this.TipoPersona = null;
                this.SelectedCliente = null;
                this.Incobrable = false;
                this.Nombrefiscal = string.Empty;
                this.Rfc = string.Empty;
                this.Direccion = string.Empty;
                this.Colonia = string.Empty;
                this.Cp = 0;
                this.Estado = string.Empty;
                this.Ciudad = string.Empty;
                this.Zona = string.Empty;
                this.NombreComercial = string.Empty;
                this.PaginaWeb = string.Empty;
                this.Contacto = string.Empty;
                this.TelefonoContacto = string.Empty;
                this.DireccionEnvio = string.Empty;
                this.Telefono1 = string.Empty;
                this.Telefono2 = string.Empty;
                this.Telefono3 = string.Empty;
                this.Celular = string.Empty;
                this.Fax = string.Empty;
                this.Email = string.Empty;
                this.DiasDeCredito = 0;
                this.SaldoInicial = 0;
                this.LimiteDeCredito = 0;
                this.Usuario = string.Empty;
                this.Password = string.Empty;
                this.PermitirComprasInternet = false;
                this.IsEnabled = false;
                this.HabilitatBtnModificar = false;
                this.HabilitatBtnEliminar = false;
                this.HabilitatBtnGuardar = true;
                this.SaldoCliente = 0;
                this.SaldoAFavor = 0;
                this.CreditoUtilizado = 0;
                this.TotalCreditoUtilizado = 0;
                this.Traspasos = 0;
            }
            catch (Exception ex)
            {

            }
        }

        public ICommand NuevoCmd
        {
            get
            {
                return new RelayCommand(s => OnNuevoClient());
            }
        }

        public void OnNuevoClient()
        {
            Limpiar();
            IsEnabled = true;
        }

        public ICommand EditarCmd
        {
            get
            {
                return new RelayCommand(s => OnEditarClient());
            }
        }

        public ICommand EliminarCmd
        {
            get
            {
                return new RelayCommand(s => OnEliminarClient());
            }
        }

        public void OnEliminarClient()
        {
            var res = MessageBox.Show("Desea modificar los siguientes datos?", "Confirmacion", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (res != MessageBoxResult.OK)
                return;
            try
            {
                if (SelectedCliente == null)
                {
                    MessageBox.Show("Debe seleccionar un  cliente");
                    return;
                }

                Repository.DeleteCliente(SelectedCliente.IdCliente);
                MessageBox.Show("Cliente eliminado correctamente");
                LimpiarCmd.Execute(null);
                return;
            }
            catch (Exception ex)
            {

            }
        }

        public void OnEditarClient()
        {
            try
            {
                var res = MessageBox.Show("Desea modificar los siguientes datos?", "Confirmacion", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (res != MessageBoxResult.OK)
                    return;

                if (TipodeCliente == null)
                {
                    MessageBox.Show("Debe seleccionar un tipo de cliente");
                    return;
                }

                if (TipoPersona == null)
                {
                    MessageBox.Show("Debe seleccionar un tipo de persona");
                    return;
                }


                Cliente cliente = new Cliente();
                cliente.IdCliente = SelectedCliente.IdCliente;
                cliente.IdTipoCliente = TipodeCliente.Id;
                cliente.Incobrable = this.Incobrable;
                cliente.IdUbicacion = ManejadorUbicacion.IdUbicacion;
                cliente.IdUsario = ManejadorLoguin.idUsuario;
                cliente.NombreFiscal = this.Nombrefiscal;
                cliente.RFC = this.Rfc;
                cliente.IdTipoPersona = this.TipoPersona.Id;
                cliente.Direccion = this.Direccion;
                cliente.Colonia = this.Colonia;
                cliente.CP = this.Cp.ToString();
                cliente.Estado = this.Estado;
                cliente.Ciudad = this.Ciudad;
                cliente.Zona = this.Zona;
                cliente.NombreComercial = this.NombreComercial;
                cliente.PaginaWeb = this.PaginaWeb;
                cliente.Contacto = this.Contacto;
                cliente.TelefonoContacto = this.TelefonoContacto;
                cliente.DireccionEnvio = this.DireccionEnvio;
                cliente.Telefono1 = this.Telefono1;
                cliente.Telefono2 = this.Telefono2;
                cliente.Telefono3 = this.Telefono3;
                cliente.Celular = this.Celular;
                cliente.Fax = this.Fax;
                cliente.Email = this.Email;
                cliente.DiasCredito = this.DiasDeCredito;
                cliente.SaldoInicial = this.SaldoInicial;
                cliente.LimiteDeCredito = this.LimiteDeCredito;
                cliente.Usuario = this.Usuario;
                cliente.Password = this.Password;
                cliente.PermitirComprarPorInternet = this.PermitirComprasInternet;
                Repository.UpdCliente(cliente);
                LimpiarCmd.Execute(null);
                MessageBox.Show("Cliente modificado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error guardado cliente");
            }
        }

        public ICommand CancelarCmd
        {
            get
            {
                return new RelayCommand(s => OnCancelarClient());
            }
        }


        public void OnCancelarClient()
        {
            IsEnabled = false;
            IsEnabledFind = false;
            Limpiar();
        }

        public ICommand SalirCmd
        {
            get
            {
                return new RelayCommand(s => OnSalirClient());
            }
        }

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

    }
}
