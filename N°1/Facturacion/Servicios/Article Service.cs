using Facturacion.Datos.Interface;
using Facturacion.Datos.Repository;
using Facturacion.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Servicios
{
    public class ArticleService
    {
        private IArticle _repository;

        public ArticleService()
        {
            _repository = new ArticleRepository();
        }
        public List<Article> GetArticle()
        {
            return _repository.GetArticle();
        }
        public bool SaveArticle(Article oArticle)
        {
            return _repository.Save(oArticle);
        }
    }
}
