using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Domain
{
    public class Article
    {
        public int Id_Article { get; set; }
        public string Name { get; set; }
        public double Price_Unitary { get; set; }

        public override string ToString()
        {
            return "[ "+Id_Article+"]" +" "+Name +"  $"+Price_Unitary; 
        }
    }
}
