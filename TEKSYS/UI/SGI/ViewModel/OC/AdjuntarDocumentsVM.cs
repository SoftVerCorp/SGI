using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using SGI.Model;
using SGI.View;
using SGI.Model.Entidades;
using System.Windows.Input;
using SGI.Stuffs;
using System.Diagnostics;

namespace SGI.ViewModel.OC
{
    public class AdjuntarDocumentsVM : ViewModelBase
    {

        private string rutaArchivo;
        private TipoDocumentos tipoArchivo;
        private string nombreArchivo;
        private int IDOC;
        private ObservableCollection<ArchivoAdjunto> archivos;
        private List<TipoDocumentos> tipos;
        public EventHandler Aceptar { get; set; }

        public AdjuntarDocumentsVM(int idOC)
        {
            this.IDOC = idOC;
            this.tipos = new List<TipoDocumentos>();
            this.tipos.Add(new TipoDocumentos { IdDocumento = -1, Nombre = "Seleccionar" });
            this.tipos.AddRange(Repository.ObtenerTipoDocumento());
            this.tipoArchivo = tipos.FirstOrDefault();

            //this.Archivos = new ObservableCollection<ArchivoAdjunto>();
            this.Archivos = new ObservableCollection<ArchivoAdjunto>( Repository.ObtenerDocumentosAdjuntosPorOC(idOC));
            //            this.Tipos = new List<string>()
            //            {
            //"Pedimento" ,
            //"Documento general" ,
            //"Foto General"  ,
            //"Foto Producto"     ,
            //"Documento Producto"    ,
            //"Factura Aduanal"   ,
            //"Factura Fletes"    ,
            //            };

            //            TipoArchivo = tipos.FirstOrDefault();
        }


        public string RutaArchivo
        {
            get { return rutaArchivo; }
            set
            {
                rutaArchivo = value;
                RaisePropertyChanged(() => RutaArchivo);
            }
        }

        public TipoDocumentos TipoArchivo
        {
            get { return tipoArchivo; }
            set
            {
                tipoArchivo = value;
                RaisePropertyChanged(() => TipoArchivo);
            }
        }
        public string NombreArchivo
        {
            get { return nombreArchivo; }
            set
            {
                nombreArchivo = value;
                RaisePropertyChanged(() => NombreArchivo);
            }
        }
        public ObservableCollection<ArchivoAdjunto> Archivos
        {
            get { return archivos; }
            set
            {
                archivos = value;
                RaisePropertyChanged(() => Archivos);
            }
        }



        public List<TipoDocumentos> Tipos
        {
            get { return tipos; }
            set
            {
                tipos = value;
                RaisePropertyChanged(() => Tipos);
            }
        }


        public ICommand TomarFoto
        {
            get { return new RelayCommand(s => AbrirTomarFoto()); }
        }

        public RelayCommand AdjuntarArchivo
        {
            get { return new RelayCommand(s => Adjuntar()); }
        }

        public RelayCommand AgregarComando
        {
            get { return new RelayCommand(s => OnAgregar()); }
        }

        public RelayCommand AceptarCommando
        {
            get { return new RelayCommand(s => OnAceptar()); }
        }

        public ICommand AbrirDocumentoCmd
        {
            get
            {
                return new RelayCommand(AbrirDocumento);
            }
        }

        public ICommand EliminarDocumentoCmd
        {
            get
            {
                return new RelayCommand(EliminarDocumento);
            }
        }

        public ICommand LimpiarCmd
        {
            get
            {
                return new RelayCommand(s => Limpiar());
            }
        }

        public ICommand GuardarCmd
        {
            get
            {
                return new RelayCommand(s => Guardar());
            }
        }

        private void Guardar()
        {
            try
            {
                if (Archivos.Count == 0)
                {
                    MessageBox.Show("No hay elementos a guardar");
                    return;
                }

                StringBuilder sb = new StringBuilder();

                sb.Append("<Documentos>");
                foreach (var item in Archivos)
                {
                    sb.Append("<documento>");
                    sb.Append("<tipo_doc>" + item.idTipo + "</tipo_doc>");
                    sb.Append("<id_Oc>" + this.IDOC + "</id_Oc>");
                    sb.Append("<ruta>" + item.NombreArchivo + "</ruta>");
                    sb.Append("</documento>");
                }
                sb.Append("</Documentos>");

                if (!Repository.GuardarDocumentoAdjunto(sb.ToString(), this.IDOC))
                {
                    MessageBox.Show("Error guardando registros");
                    return;
                }

                MessageBox.Show("Detalles guardandos registros");
                Limpiar();
            }
            catch (Exception ex)
            {

            }
        }

        private void Limpiar()
        {
            this.NombreArchivo = string.Empty;
            this.RutaArchivo = string.Empty;
            this.TipoArchivo = Tipos.FirstOrDefault();
            this.Archivos = new ObservableCollection<ArchivoAdjunto>();
        }

        private void AbrirDocumento(object param)
        {
            try
            {
                ArchivoAdjunto adj = param as ArchivoAdjunto;

                if (adj == null)
                    return;

                Process.Start(adj.NombreArchivo);
            }
            catch (Exception ex)
            {

            }
        }

        private void EliminarDocumento(object param)
        {
            try
            {
                ArchivoAdjunto adj = param as ArchivoAdjunto;

                this.Archivos.Remove(adj);
            }
            catch (Exception ex)
            {

            }
        }

        private void AbrirTomarFoto()
        {
            var tomarfoto = new foto();
            tomarfoto.ShowDialog();

            NombreArchivo = tomarfoto.Ruta;

        }

        private void Adjuntar()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (dialog.ShowDialog().Equals(System.Windows.Forms.DialogResult.Cancel))
                return;
            else
            {
                NombreArchivo = dialog.FileName;
                //RutaArchivo = dialog.FileName;
            }
        }

        private void OnAgregar()
        {
            if (TipoArchivo == null)
            {
                MessageBox.Show("Debe seleccionar el tipo de documento");
                return;
            }

            if (TipoArchivo.IdDocumento == -1)
            {
                MessageBox.Show("Debe seleccionar el tipo de documento");
                return;
            }

            if (String.IsNullOrEmpty(NombreArchivo))
            {
                MessageBox.Show("Debe seleccionar un tipo de archivo");
                return;
            }

            var item = new ArchivoAdjunto()
            {
                idTipo = this.TipoArchivo.IdDocumento,
                TipoArchivo = this.TipoArchivo.Nombre,
                NombreArchivo = this.NombreArchivo,
                IdOC = this.IDOC
                //TipoArchivo = this.TipoArchivo,
                //RutaArchivo = this.RutaArchivo,
                //NombreArchivo = this.NombreArchivo,
                //IdOC = IDOC
            };

            Archivos.Add(item);
            this.NombreArchivo = string.Empty;
            this.RutaArchivo = string.Empty;
            this.TipoArchivo = Tipos.FirstOrDefault();

        }

        private void OnAceptar()
        {
            if (Aceptar != null)
                Aceptar(this, new EventArgs());
        }
    }

}
