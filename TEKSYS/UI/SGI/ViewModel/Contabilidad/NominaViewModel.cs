using SGI.Helpers;
using SGI.Model;
using SGI.Stuffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.ViewModel.Contabilidad
{
    public class NominaViewModel : ViewModelBase
    {
        #region Contructor

        public NominaViewModel()
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
            SelectedDate = DateTime.Now;
            //Repository.EmpleadosCache = Repository.GetEmployees("", ManejadorUbicacion.IdUbicacion);
        }

        #endregion

        private DateTime _selectedDate;

        public DateTime SelectedDate
        {
            get
            {
                return _selectedDate;
            }
            set
            {
                _selectedDate = value;
                if (value != null)
                {
                    RaisePropertyChanged(() => this.SelectedDate);
                    GetBeginEndDate();
                }
            }
        }

        private void GetBeginEndDate()
        {
            int selectedmonth = _selectedDate.Month;
            int selectedday = _selectedDate.Day;
            YearNomina = _selectedDate.Year;

            if (selectedday > 14)
            {
                int totalDay = DateTime.DaysInMonth(_selectedDate.Year, _selectedDate.Month);
                BeginDate = new DateTime(_selectedDate.Year, selectedmonth, 15);
                EndDate = new DateTime(_selectedDate.Year, selectedmonth, totalDay - 1);
                FechaPago = new DateTime(_selectedDate.Year, selectedmonth, totalDay);
                WeekNomina = 2;
            }
            else
            {
                BeginDate = new DateTime(_selectedDate.Year, selectedmonth, 1).AddDays(-1);
                EndDate = new DateTime(_selectedDate.Year, selectedmonth, 14);
                FechaPago = new DateTime(_selectedDate.Year, selectedmonth, 15);
                WeekNomina = 1;
            }
        }

        private DateTime _fechaPago;

        public DateTime FechaPago
        {
            get
            {
                return _fechaPago;
            }
            set
            {
                _fechaPago = value;
                RaisePropertyChanged(() => this.FechaPago);
            }
        }

        private DateTime _beginDate;

        public DateTime BeginDate
        {
            get
            {
                return _beginDate;
            }
            set
            {
                _beginDate = value;
                RaisePropertyChanged(() => this.BeginDate);
            }
        }

        private int _yearNomina;

        public int YearNomina
        {
            get
            {
                return _yearNomina;
            }
            set
            {
                _yearNomina = value;
                RaisePropertyChanged(() => this.YearNomina);
            }
        }

        private int _weekNomina;

        public int WeekNomina
        {
            get
            {
                return _weekNomina;
            }
            set
            {
                _weekNomina = value;
                RaisePropertyChanged(() => this.WeekNomina);
            }
        }

        private DateTime _endDate;

        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                _endDate = value;
                RaisePropertyChanged(() => this.EndDate);
            }
        }

    }
}
