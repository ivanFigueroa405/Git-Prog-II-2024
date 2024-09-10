using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Datos.utils
{
    public class Parameters
    {
        public string Name { get; set; }
        public object Value { get; set; }

        public Parameters(string name,object value)
        { 
           this.Name = name;
           this.Value = value;
        }

    }
}
