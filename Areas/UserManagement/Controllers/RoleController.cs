using Microsoft.AspNetCore.Mvc;
using simo2api.Areas.UserManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simo2api.Areas.UserManagement.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : Controller
    {
        [HttpGet]
        public ContentResult GetRoleAll()
        {
            var dtProvider = new RoleModel().GetDataRoleAll(this.Request);
            return Content(dtProvider, "application/json");
        }
    }
}
