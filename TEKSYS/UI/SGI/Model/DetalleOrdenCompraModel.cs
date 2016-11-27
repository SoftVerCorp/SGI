using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace SGI.Model
{
    public class DetalleOrdenCompraModel : ViewModelBase
    {
        private int recibido;
        private double taxes;
        private double unitprice;
        private int line;

        public int Id { get; set; }
        public int Id_OrderBuy { get; set; }
        public DateTime DateOutPut { get; set; }
        public int  Quantity { get; set; }

        public double Amount { get; set; }
        public int IdProduct { get; set; }
        public string ProductDescription { get; set; }
        public double Total { get; set; }
        public string Description { get; set; }
        public string Nombre { get; set; }
        public DateTime DateDelevery { get; set; }
        public string CveTecnobike { get; set; }
        public string CveProveedor { get; set; }

        public Dictionary<int, SerieModel> Series { get; set; }
        public string Comentario { get; set; }

        public string UOM { get; set; }

        public int Line
        {
            get { return line; }
            set
            {
                line = value;
                RaisePropertyChanged(() => Line);
            }
        }

        public double UnitPrice
        {
            get { return unitprice; }
            set 
            {
                unitprice = value;
                RaisePropertyChanged(() => UnitPrice);
                RaisePropertyChanged(() => Monto);
                RaisePropertyChanged(() => TotalCal);
            }
        }

        public int Recibido 
        {
            get {return recibido;}
            set 
            {
                recibido = value;
                RaisePropertyChanged(()=> Recibido);
                RaisePropertyChanged(()=> Monto);
                RaisePropertyChanged(() => Tax);
                RaisePropertyChanged(() => TotalCal);
            }
        }

        public double Tax
        {
            get { return taxes; }
            set 
            {
                taxes = value;
                RaisePropertyChanged(() => Monto);
                RaisePropertyChanged(() => Tax);
                RaisePropertyChanged(() => TotalCal);
            }
        }

        public double Monto 
        {
            get { return UnitPrice * recibido; }
        }

        public double TotalCal 
        {
            get { return Monto + Tax; }
        }
    }

    public class SerieModel
    {
        public string Nombre { get; set; }

        public string Valor { get; set; }
    }
}
