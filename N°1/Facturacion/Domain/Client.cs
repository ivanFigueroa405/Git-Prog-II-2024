using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Domain
{
   public  class Client
   {
        public int Id_Client { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public  string Shet_up {  get; set; }
        public string Height { get; set; }

        public override string ToString()
        {
            return Name+"  "+Surname;
        }

    }
}
