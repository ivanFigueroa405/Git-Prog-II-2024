using Facturacion.Datos;
using Facturacion.Datos.Interface;
using Facturacion.Datos.Repository;
using Facturacion.Datos.utils;
using Facturacion.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Servicios
{
    public class Client_Service
    {
        private IClient _repository;

        public Client_Service()
        {
            _repository = new Client_Repository();
        }

        public List <Client> GetALlClient()
        {
            return _repository.GetAll();
        }

        public bool DeletClient(int id)
        {
            return _repository.Delete(id);
        }

        public bool SaveClient(Client oClient)
        {
            return _repository.Save(oClient);
        }
        public Client GetByIdClient(int id)
        {
            return _repository.GetById(id);
        }
    }
}
