using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using simo2api.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prometheus;
using simo2api.MetricsNamespace;

namespace simo2api.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class AboutController : Controller
    {

        [HttpGet]
        public ContentResult GetAppVersion()
        {
            AppMetrics.GetAppVersionCounter.Inc();

            DataJsonCatch dataJson = new DataJsonCatch();
            AppVersion app = new AppVersion();

            JObject appset = new ConfigConnection().getAppSettings();
            app.LastModified = new HelperByQuery().GetLastModified();
            app.Version = appset["AppVersion"].ToString();
            dataJson.Data = app;
            var dtPass = new HelperByQuery().ObjectToJSONWithJSONNet(this.Request, dataJson);

            return Content(dtPass, "application/json");
        }
    }
}
