using APIProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIProject.Controllers
{
    [Produces("application/json")]
    [Route("/appointments")]
    public class AppointmentsController : Controller
    {
        // GET: /appointments
        [HttpGet]
        public JsonResult Get()
        {
            DBContext context = HttpContext.RequestServices.GetService(typeof(DBContext)) as DBContext;
            return Json(context.GetAppointments(Request.Query));
        }
    }
}
