using FacturacionApi.Entity;
using FacturacionApi.Interface;
using FacturacionApi.Service;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FacturacionApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]


    public class ArticleControllers:ControllerBase
    {

        private ArticleService service;
        List<Article> lArticle = new List<Article>();


        public ArticleControllers()
        {
          
            service = new ArticleService();

        }


        [HttpGet]
        public IActionResult Get()
        {
            lArticle= service.GetArticle();
            if (lArticle.Count > 0)
            {
                return Ok(lArticle);
            }
            else
                return Ok("No hay Articulos cargados");
           
            
        }
        [HttpPost]
        public IActionResult Save([FromBody]Article article)
        {
            if (article == null)
            {
                return BadRequest();
            }
            var result = service.SaveArticle(article);
            return Ok("se agrego exitosamente");
        }
        [HttpDelete("{idArt}")]
        public IActionResult Delete([FromRoute]int idArt)
        {
            if (service.DeleteArticle(idArt))
                return Ok("SE ELIMINO CORRECTAMENTE");
            else
                return BadRequest();
        }
        [HttpPut]
        public IActionResult Update([FromBody]Article oArt)
        {
            lArticle = service.GetArticle();

                if (lArticle == null || oArt == null)
                {
                        return BadRequest("NO EXISTE ESE ID");
                }
            else
            service.UpdateArticle(oArt);
            return Ok("se agrego correctamente");
        }

    }
}
