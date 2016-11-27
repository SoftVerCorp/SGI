using SGI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Classes
{
    public class SelectedEmployeeEventArgs : EventArgs
    {
        public SelectedEmployeeEventArgs(Empleado model)
        {
            this.SelectedEmployee = model;
        }

        public Empleado SelectedEmployee { get; set; }
    }
}
