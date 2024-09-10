using Facturacion.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Datos.Interface
{
    public interface IClient
    {
        public abstract bool Save(Client oCliente);
        public abstract bool Delete(int id);
        List<Client> GetAll();
        Client GetById(int id);

    }
}
