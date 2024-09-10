using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Domain
{
    public class Details_Invoice

    {
        public int Id_detail {  get; set; }
        public Invoice Nbr_Inovice { get; set; }
        public Article Article { get; set; }
        public int Quantity { get; set; }
        public override string ToString()
        {
            return "DETALLE: "+Id_detail+"   |" +"DE LA FACTURA:"+ Nbr_Inovice.Nro_Invoice +"   |"+"ARTICULO: "+Article.Name;
        }

        
    }
}
