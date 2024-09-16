using FacturacionApi.Entity;

namespace FacturacionApi.Interface
{
    public interface IAplicacioncs
    {
        bool PostArticle(Article oArticle);
        bool DeleteArticle(int id);
        bool PutArticle(Article oart);
        List<Article> GetArticles();
    }
}
