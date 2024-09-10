using Facturacion.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Datos.Interface
{
    public interface IArticle
    {
        List<Article> GetArticle();
        bool Save(Article oArticulo);
    }
}
