using SGI.Helpers;
using SGI.Model;
using SGI.Model.Entidades;
using SGI.Stuffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.ViewModel.CreditoYCobranza
{
    public class VisorDeAbonosVM : ViewModelBase
    {
        private List<Cliente> clientes;
        private Cliente selectedCliente;
        private List<VentasAdeudos> adeudos;


        public VisorDeAbonosVM()
        {
            try
            {
                Repository.ClientesCache = Repository.GetClientes(ManejadorUbicacion.IdUbicacion);
                this.Clientes = Repository.ClientesCache;

                Adeudos = Repository.ObtenerAdeudos(ManejadorUbicacion.IdUbicacion, -1);
            }
            catch (Exception ex)
            {

            }
        }

        #region Public Properties

        public List<VentasAdeudos> Adeudos
        {
            get { return adeudos; }
            set
            {
                adeudos = value;
                RaisePropertyChanged(() => Adeudos);
            }
        }

        public List<Cliente> Clientes
        {
            get
            {
                return clientes;
            }

            set
            {
                clientes = value;
                RaisePropertyChanged(() => Clientes);
            }
        }

        public Cliente SelectedCliente
        {
            get
            {
                return selectedCliente;
            }

            set
            {
                selectedCliente = value;
                RaisePropertyChanged(() => SelectedCliente);
            }
        }


        #endregion
    }
}
