using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using simo2api.Extensions;
using simo2api.Models;
using simo2api.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using simo2api.Entities.Modul1;
using simo2api.Areas.Masters.Models;
using System.Security.Cryptography;
using System.Text;
using System.Web.Helpers;
using simo2api.Helpers;
using Prometheus;
using simo2api.MetricsNamespace;

namespace simo2api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NoTokenController : Controller
    {

        [HttpGet]
        public ContentResult CreatePassword(string password)
        {
            AppMetrics.CreatePasswordCounter.Inc();

            DataJsonCatch dataJson = new DataJsonCatch();
            GeneratePassword pass = new GeneratePassword();
            pass.Password = password;
            pass.HashPassword = Crypto.HashPassword(password);
            bool check = Crypto.VerifyHashedPassword(pass.HashPassword, password);
            pass.IsVerify = check;
            dataJson.Data = pass;
            var dtPass = new HelperByQuery().ObjectToJSONWithJSONNet(this.Request, dataJson);

            return Content(dtPass, "application/json");
        }

        [HttpGet]
        public ContentResult VerifyPassword(string HashPass,string Password)
        {
            AppMetrics.VerifyPasswordCounter.Inc();

            DataJsonCatch dataJson = new DataJsonCatch();
            bool check = Crypto.VerifyHashedPassword(HashPass, Password);
            //
            GeneratePassword pass = new GeneratePassword();
            pass.Password = Password;
            pass.HashPassword = HashPass;
            pass.IsVerify = check;
            dataJson.Data = pass;
            var dtPass = new HelperByQuery().ObjectToJSONWithJSONNet(this.Request, dataJson);

            return Content(dtPass, "application/json");
        }

        //[HttpGet]
        //public ContentResult MasterData()
        //{
        //    var dataPeg = new PegawaiModel().GetPegawai(this.Request,"1");
        //    return Content(dataPeg, "application/json");
        //}
        //[HttpGet]
        //public ContentResult MasterObatAll()
        //{
        //    var dataPeg = new PegawaiModel().GetDataObatAll(this.Request);
        //    return Content(dataPeg, "application/json");
        //}
        //[HttpPost]
        //public ContentResult MasterObatById(DataObatGetById dtObat)
        //{
        //    var mObat = new PegawaiModel().GetDataObatById(this.Request, dtObat.IdObat);
        //    return Content(mObat, "application/json");
        //}
    }
}
