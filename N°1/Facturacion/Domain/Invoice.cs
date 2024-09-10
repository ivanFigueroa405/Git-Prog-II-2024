using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Domain
{
    public class  Invoice
    {
        public int Nro_Invoice {  get; set; }
        public DateTime Date { get; set; }
        public  Payment_Methods Payment { get; set; }
       public Client Client { get; set; }
        public List<Details_Invoice> Details { get; set; } //lista de detalles...

        public Invoice()
        {
            Details = new List<Details_Invoice>();//inicializamos la lista...
        }

        public void AddDetail(Details_Invoice oDetail)
        {
            Details.Add(oDetail);
        }
        public void RemoveDeatail(int Index)
        {
            Details.RemoveAt(Index);//remove at borra el indice y el remove borra objetos
        }
        public override string ToString()
        {
            return "DLDLDLLD:" +Nro_Invoice+"|"+"DIA DE EMISION: "+Date.ToShortDateString() +" - |FORMA DE PAGO: "+Payment.Name+"  - |  CLIENTE: "+Client.Name  ;
        }

    }
}
