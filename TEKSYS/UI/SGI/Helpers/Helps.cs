using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Helpers
{
    public  static class Helps
    {
        public static string GetRandomFileName(string name)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Reporte_");
            sb.Append(name);
            sb.Append("_");
            sb.Append(DateTime.Now);
            sb.Replace("/", "-");
            sb.Replace(":", "-");
            sb.Append(".xls");
            return sb.ToString();
        }
    }
}
