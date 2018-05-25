using APIProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIProject.Controllers
{
    [Produces("application/json")]
    [Route("/practices")]
    public class PracticesController : Controller
    {
        // GET: /practices
        [HttpGet]
        public JsonResult Get()
        {
            DBContext context = HttpContext.RequestServices.GetService(typeof(DBContext)) as DBContext;
            return Json(context.GetPractices(Request.Query));
        }
    }
}
