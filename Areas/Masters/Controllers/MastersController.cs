using Microsoft.AspNetCore.Mvc;
using simo2api.Areas.Masters.Entities;
using simo2api.Areas.Masters.Models;
using simo2api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebMatrix.WebData;
using Prometheus;
using simo2api.MetricsNamespace;
using Microsoft.AspNetCore.Http;

namespace simo2api.Areas.Masters.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MastersController : Controller
    {
        private void AppCountExceptions(Action action)
        {
            AppMetrics.AppExceptions.CountExceptions(action);
        }
        [HttpGet]
        public ContentResult Get_RefStatusAll()
        {
            string dtDist = "";
            AppCountExceptions(() =>
            {
                using (AppMetrics.GetRefStatusAllLatencyGauge.NewTimer())
                {
                    dtDist = new MastersModel().GetDataRefStatus(this.Request);
                }
            });


            return Content(dtDist, "application/json");
        }


        [HttpGet]
        public ContentResult Get_DistributorAll()
        {
            string dtDist = "";
            AppCountExceptions(() =>
            {
                using (AppMetrics.GetDistributorAllLatencyGauge.NewTimer())
                {
                    dtDist = new MastersModel().GetDataDistributorAll(this.Request);
                }
            });

            return Content(dtDist, "application/json");
        }
        [HttpGet]
        public ContentResult Get_CabangDistAll()
        {
            string dtDist = "";
            AppCountExceptions(() =>
            {
                using (AppMetrics.Get_CabangDistAllLatencyGauge.NewTimer())
                {
                    dtDist = new MastersModel().GetDataCabangDistAll(this.Request);
                }
            });
            return Content(dtDist, "application/json");
        }
        [HttpGet]
        public ContentResult Get_CabangDistByDistId(string DistID, string ProvId)
        {
            string dtDist = "";
            AppCountExceptions(() =>
            {
                using (AppMetrics.Get_CabangDistByDistIdlatencygauge.NewTimer())
                {
                    dtDist = new MastersModel().GetDataCabangDistByDistId(this.Request, DistID, ProvId);
                }
            });

            return Content(dtDist, "application/json");
        }
        [HttpGet]
        public ContentResult Get_CabangDistByKdCabang(string KdCabang)
        {
            string dtDist = "";
            AppCountExceptions(() =>
            {
                using (AppMetrics.Get_CabangDistByKdCabanglatencygauge.NewTimer())
                {
                    dtDist = new MastersModel().GetDataCabangDistByKdCabang(this.Request, KdCabang);
                }
            });
            return Content(dtDist, "application/json");
        }
        [HttpGet]
        public ContentResult Get_ProviderByID(string provID)
        {
            string dtDist = "";
            AppCountExceptions(() =>
            {
                using (AppMetrics.Get_ProviderAlllatencygauge.NewTimer())
                {
                    dtDist = new MastersModel().GetDataProviderByID(this.Request, provID);
                }
            });
            return Content(dtDist, "application/json");
        }
        [HttpGet]
        public ContentResult Get_RejectListAll()
        {
            string dtDist = "";
            AppCountExceptions(() =>
            {
                using (AppMetrics.Get_RejectListAlllatencygauge.NewTimer())
                {
                    dtDist = new MastersModel().GetRejectList(this.Request);
                }
            });
            return Content(dtDist, "application/json");
        }
        [HttpPost]
        public ContentResult Get_ProviderAll(Provider prov)
        {
            string dtDist = "";
            AppCountExceptions(() =>
            {
                using (AppMetrics.Get_ProviderAlllatencygauge.NewTimer())
                {
                    dtDist = new MastersModel().GetDataProviderAll(this.Request, prov.Offset, prov.Limit);
                }
            });
            return Content(dtDist, "application/json");
        }
        //[HttpPost]
        //public ContentResult LoginUser()
        //{
        //    var dtDist = "apotik_kf_jayapura";

        //    using MD5 md5Hash = MD5.Create();
        //    byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(dtDist));
        //    StringBuilder sBuilder = new StringBuilder();

        //    for (int i = 0; i < data.Length; i++)
        //    {
        //        sBuilder.Append(data[i].ToString("x2"));
        //    }
        //    //bool dtDist = WebSecurity.Login(request.Username, request.Password);
        //    return Content(sBuilder.ToString(), "application/json");
        //}
    }
}
