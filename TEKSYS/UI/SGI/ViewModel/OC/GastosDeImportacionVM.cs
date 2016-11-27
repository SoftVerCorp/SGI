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

namespace SGI.ViewModel.OC
{
    public class GastosDeImportacionVM : ViewModelBase
    {
        #region  Private fields

        private List<ConceptosImportacion> conceptos;
        private List<AgenteAduanal> agentes;

        private int agenteSeleccionado;
        private int conceptoSeleccionado;
        private int ordenDeCompra;

        private DateTime fecha;

        private string noCuenta;

        private ObservableCollection<GastosImportacionDetalle> gastosDetalle;

        #endregion

        #region Constructors
        public GastosDeImportacionVM()
        {

        }

        public GastosDeImportacionVM(int idOrdenDeCompra)
        {
            try
            {
                this.Conceptos = new List<ConceptosImportacion>();
                this.Conceptos.Add(new ConceptosImportacion { Id = -1, Concepto = "Seleccionar" });
                this.Conceptos.AddRange(Repository.ObtenerConceptosDeImportacion());

                this.Agentes = new List<AgenteAduanal>();
                this.Agentes.Add(new AgenteAduanal { Id = -1, Nombre = "Seleccionar" });
                this.Agentes.AddRange(Repository.ObtenerAgente());
                this.OrdenDeCompra = idOrdenDeCompra;
                this.ConceptoSeleccionado = -1;

                var model = Repository.ObtenerGastoDeImportacion(idOrdenDeCompra);

                if (model == null)
                {
                    this.AgenteSeleccionado = -1;
                    this.NoCuenta = string.Empty;
                    this.Fecha = DateTime.Now;
                }
                else
                {
                    this.AgenteSeleccionado = model.IdAgenteAduanal;
                    this.NoCuenta = model.NoCuenta;
                    this.Fecha = model.Fecha;
                }

                var detalle = Repository.ObtenerGastoDeImportacionDetalle(idOrdenDeCompra);

                if (detalle.Count == 0)
                {
                    this.GastosDetalle = new ObservableCollection<GastosImportacionDetalle>();
                }
                else
                {
                    this.GastosDetalle = new ObservableCollection<GastosImportacionDetalle>(detalle);
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region Public Properties

        public ObservableCollection<GastosImportacionDetalle> GastosDetalle
        {
            get { return gastosDetalle; }
            set
            {
                if (gastosDetalle != value)
                {
                    gastosDetalle = value;
                    RaisePropertyChanged(() => GastosDetalle);
                }
            }
        }

        public string NoCuenta
        {
            get { return noCuenta; }
            set
            {
                if (noCuenta != value)
                {
                    noCuenta = value;
                    RaisePropertyChanged(() => NoCuenta);
                }
            }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set
            {
                if (fecha != value)
                {
                    fecha = value;
                    RaisePropertyChanged(() => Fecha);
                }
            }
        }


        public int OrdenDeCompra
        {
            get { return ordenDeCompra; }
            set
            {
                if (ordenDeCompra != value)
                {
                    ordenDeCompra = value;
                    RaisePropertyChanged(() => OrdenDeCompra);
                }
            }
        }

        public int AgenteSeleccionado
        {
            get { return agenteSeleccionado; }
            set
            {
                if (agenteSeleccionado != value)
                {
                    agenteSeleccionado = value;
                    RaisePropertyChanged(() => AgenteSeleccionado);
                }
            }
        }

        public List<AgenteAduanal> Agentes
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

        public int ConceptoSeleccionado
        {
            get { return conceptoSeleccionado; }
            set
            {
                if (conceptoSeleccionado != value)
                {
                    conceptoSeleccionado = value;
                    RaisePropertyChanged(() => ConceptoSeleccionado);
                }
            }
        }

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

        public ICommand AgregarGastoImportacionCmd
        {
            get
            {
                return new RelayCommand(s => this.AgregarGastoImportacion());
            }
        }

        public ICommand EliminarGastoImportacionCmd
        {
            get
            {
                return new RelayCommand(EliminarGastosImportacion);
            }
        }

        public ICommand AgregarNuevoGastoImportacionCmd
        {
            get
            {
                return new RelayCommand(s => AgregarNuevoGastoImportacion());
            }
        }

        #endregion

        #region Private Methods

        public override void OnClean()
        {
            try
            {
                this.AgenteSeleccionado = -1;
                this.ConceptoSeleccionado = -1;
                this.NoCuenta = string.Empty;
                this.Fecha = DateTime.Now;
                this.GastosDetalle = new ObservableCollection<GastosImportacionDetalle>();
            }
            catch (Exception ex)
            {

            }
        }

        public void AgregarNuevoGastoImportacion()
        {
            try
            {
                if (this.AgenteSeleccionado == -1)
                {
                    MessageBox.Show("Debe seleccionar un agente aduanal");
                    return;
                }

                var xml = new StringBuilder();
                xml.Append("<conceptos>");
                if (this.GastosDetalle.Count > 0)
                {
                    foreach (var item in this.GastosDetalle)
                    {
                        xml.Append("<concepto>");
                        xml.Append("<IdConcepto>" + item.IdConcepto + "</IdConcepto>");
                        xml.Append("<CostoReal>" + item.CostoReal + "</CostoReal>");

                        var txt0 = item.FechaCostoReal == null ? string.Empty : item.FechaCostoReal.Value.ToString("dd/MM/yyyy");
                        xml.Append("<FechaCostoReal>" + txt0 + "</FechaCostoReal>");

                        xml.Append("<CostoEstimado>" + item.CostoEstimado + "</CostoEstimado>");

                        var txt1 = item.FechaCostoEstimado == null ? string.Empty : item.FechaCostoEstimado.Value.ToString("dd/MM/yyyy");
                        xml.Append("<FechaCostoEstimado>" + txt1 + "</FechaCostoEstimado>");
                        xml.Append("</concepto>");
                    }
                }
                xml.Append("</conceptos>");

                var error = Repository.InsertarGastosImportacion(this.OrdenDeCompra, this.AgenteSeleccionado, this.NoCuenta, this.fecha, xml.ToString());

                if (error != 0)
                {
                    MessageBox.Show("Error guardando los datos");
                    return;
                }

                MessageBox.Show("Datos guardados correctamente");
            }
            catch (Exception ex)
            {

            }
        }

        private void EliminarGastosImportacion(object param)
        {
            try
            {
                var aux = param as GastosImportacionDetalle;

                if (aux == null)
                    return;

                this.GastosDetalle.Remove(aux);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar elemento");
            }
        }

        private void AgregarGastoImportacion()
        {
            try
            {
                if (this.ConceptoSeleccionado == -1)
                {
                    MessageBox.Show("Debe seleccionar un concepto de importacion");
                    return;
                }

                var item = (from x in GastosDetalle where x.IdConcepto == this.ConceptoSeleccionado select x).ToList();

                if (item.Count > 0)
                {
                    MessageBox.Show("Ya existe un concepto agregado con el mismo nombre");
                    return;
                }

                var conceptoAux = conceptos.Where(s => s.Id == this.ConceptoSeleccionado).Select(s => s.Concepto).FirstOrDefault();

                this.GastosDetalle.Add(new GastosImportacionDetalle { IdConcepto = this.ConceptoSeleccionado, Concepto = conceptoAux });
            }
            catch (Exception ex)
            {

            }
        }

        #endregion
    }
}
