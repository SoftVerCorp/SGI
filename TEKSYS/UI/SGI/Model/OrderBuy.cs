using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Model
{
    public class OrderBuy
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int IdProvider { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ProviderName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int IdEmployeeBuyer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string EmployeeBuyeerName { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public int IdEmployeeValidator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string EmployeeValidatorName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int IdPaymentCondition { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ConditionPayment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NumberOrderBuy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? DateColocation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? DateValidation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int IdBuyStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsNotifyBuyStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string StatusName { get; set; }

        public string Direccion_Envio { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int Dias { get; set; }

        public int idGenerador { get; set; }
        public int? IdAutoriza { get; set; }
        public int? IdRecibe { get; set; }

        public string Genera { get; set; }
        public string Autoriza { get; set; }
        public string Recibe { get; set; }

        public int IdUbicacion { get; set; }
    }
}
