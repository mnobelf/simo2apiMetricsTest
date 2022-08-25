using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using simo2api.Entities.Modul1;
using simo2api.Extensions;
using simo2api.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static simo2api.Helpers.HelperByQuery;

namespace simo2api.Models
{
    public class PegawaiModel
    {
        public string GetDataRefStatus(HttpRequest request)
        {
            string queryStr = "select * from dbo.REFSTATUS";
            ExcQuery listDist = new HelperByQuery().ExcecuteQuery(queryStr);
            var getDist = new HelperByQuery().DataTableToJSONWithJSONNetNew(request, listDist);
            return getDist;
        }
        //public string GetDataObatAll(HttpRequest request)
        //{
        //    DataTable inquiryObat = new HelperByQuery().getDataByQuery("select top 20 * from dbo.FOI");
        //    var getObat = new HelperByQuery().DataTableToJSONWithJSONNet(request, inquiryObat);
        //    return getObat;
        //}
        //public string GetDataObatById(HttpRequest request, int IdObat)
        //{
        //    DataTable inquiryObat = new HelperByQuery().getDataByQuery("select top 10 * from dbo.FOI where ID = '"+ IdObat + "'");
        //    var getObat = new HelperByQuery().DataTableToJSONWithJSONNet(request, inquiryObat);
        //    return getObat;
        //}
    }
}
