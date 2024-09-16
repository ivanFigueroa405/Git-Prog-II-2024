using FacturacionApi.Entity;
using FacturacionApi.Interface;
using FacturacionApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace FacturacionApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]


    public class ArticleControllers:ControllerBase
    {

        private ArticleService service;


        public ArticleControllers()
        {
          
            service = new ArticleService();
        }


        [HttpGet]
        public IActionResult Get()
        {
            List<Article> lArticle = service.GetArticle();
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
        [HttpPut("{id}")]
        public IActionResult Update([FromBody]Article oArt)
        {
            if (oArt == null)
            {
                return BadRequest();
            }
            else
                service.UpdateArticle(oArt);
                return Ok("se agrego mortal");
        }

    }
}
