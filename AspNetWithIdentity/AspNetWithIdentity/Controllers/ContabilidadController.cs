using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AspNetWithIdentity.Controllers
{
    [Authorize]
    [CustomAuthAttribute(Roles = "Contabilidad")]
    public class ContabilidadController : Controller
    {
        // GET: Contabilidad
        public ActionResult Index()
        {
            return View();
        }
    }
}