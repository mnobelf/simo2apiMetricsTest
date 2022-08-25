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
using System.Diagnostics;
using simo2api.MetricsNamespace;
using Prometheus;
using Microsoft.AspNetCore.Http

namespace simo2api.Areas.Masters.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MastersController : Controller
    {
        private string MeasureLatency(Func<HttpRequest,string> functioncall, HttpRequest request,Gauge latency)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string result = functioncall(request);
            stopwatch.Stop();
            latency.IncTo(stopwatch.ElapsedMilliseconds);
            return result;
        }

        [HttpGet]
        public ContentResult Get_RefStatusAll()
        {
            Func<HttpRequest,string> functionCall = delegate (HttpRequest Request) { return new MastersModel().GetDataRefStatus(Request); };
            string dtDist = MeasureLatency(functionCall, this.Request, AppMetrics.GetRefStatusAllLatencyGauge);
            return Content(dtDist, "application/json");
        }
        [HttpGet]
        public ContentResult Get_DistributorAll()
        {
            Func<HttpRequest, string> functionCall = delegate (HttpRequest Request) { return new MastersModel().GetDataDistributorAll(Request); };
            string dtDist = MeasureLatency(functionCall, this.Request, AppMetrics.GetDistributorAllLatencyGauge);
            return Content(dtDist, "application/json");
        }
        [HttpGet]
        public ContentResult Get_CabangDistAll()
        {
            Func<HttpRequest, string> functionCall = delegate (HttpRequest Request) { return new MastersModel().GetDataCabangDistAll(Request); };
            string dtDist = MeasureLatency(functionCall, this.Request, AppMetrics.Get_CabangDistAllLatencyGauge);
            return Content(dtDist, "application/json");
        }
        [HttpGet]
        public ContentResult Get_CabangDistByDistId(string DistID,string ProvId)
        {
            Func<HttpRequest, string> functionCall = delegate (HttpRequest Request) { return new MastersModel().GetDataCabangDistByDistId(Request,DistID,ProvId); };
            string dtDist = MeasureLatency(functionCall, this.Request, AppMetrics.Get_CabangDistByDistIdlatencygauge);
            return Content(dtDist, "application/json");
        }
        [HttpGet]
        public ContentResult Get_CabangDistByKdCabang(string KdCabang)
        {
            Func<HttpRequest, string> functionCall = delegate (HttpRequest Request) { return new MastersModel().GetDataCabangDistByKdCabang(Request,KdCabang); };
            string dtDist = MeasureLatency(functionCall, this.Request, AppMetrics.Get_CabangDistByKdCabanglatencygauge);
            return Content(dtDist, "application/json");
        }
        [HttpGet]
        public ContentResult Get_ProviderByID(string provID)
        {
            Func<HttpRequest, string> functionCall = delegate (HttpRequest Request) { return new MastersModel().GetDataProviderByID(Request,provID); };
            string dtDist = MeasureLatency(functionCall, this.Request, AppMetrics.Get_ProviderByIDlatencygauge);
            return Content(dtDist, "application/json");
        }
        [HttpGet]
        public ContentResult Get_RejectListAll()
        {
            Func<HttpRequest, string> functionCall = delegate (HttpRequest Request) { return new MastersModel().GetRejectList(Request); };
            string dtDist = MeasureLatency(functionCall, this.Request, AppMetrics.Get_RejectListAlllatencygauge);
            return Content(dtDist, "application/json");
        }
        [HttpPost]
        public ContentResult Get_ProviderAll(Provider prov)
        {
            Func<HttpRequest, string> functionCall = delegate (HttpRequest Request) { return new MastersModel().GetDataProviderAll(Request,prov.Offset,prov.Limit); };
            string dtDist = MeasureLatency(functionCall, this.Request, AppMetrics.Get_ProviderAlllatencygauge);
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
