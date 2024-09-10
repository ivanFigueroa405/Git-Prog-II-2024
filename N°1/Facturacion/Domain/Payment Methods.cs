using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Domain
{
    public class Payment_Methods
    {
        public int Id_Methods {  get; set; }
        public string Name {  get; set; }

        public override string ToString()
        {
            return "["+Id_Methods+"]"+" "+Name;
        }

    }
}
