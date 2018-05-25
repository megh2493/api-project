using APIProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIProject.Controllers
{
    [Produces("application/json")]
    [Route("/patients")]
    public class PatientsController : Controller
    {
        // GET /patients
        [HttpGet]
        public JsonResult Get()
        {
            DBContext context = HttpContext.RequestServices.GetService(typeof(DBContext)) as DBContext;
            return Json(context.GetPatients(Request.Query));
        }
    }
}
