using FacturacionApi.Entity;
using FacturacionApi.Interface;
using FacturacionApi.Repository;

namespace FacturacionApi.Service
{
    public class ArticleService
    {
        private IAplicacioncs _repository;

        public ArticleService()
        {
            _repository = new ArticleRepository();
        }
        public List<Article> GetArticle()
        {
            return _repository.GetArticles();
        }
        public bool SaveArticle(Article oArticle)
        {
            return _repository.PostArticle(oArticle);
        }
        public bool DeleteArticle(int id)
        {
            return _repository.DeleteArticle(id);
        }
        public bool UpdateArticle(Article oAR)
        {
            return _repository.PutArticle(oAR);
        }
    }
}
