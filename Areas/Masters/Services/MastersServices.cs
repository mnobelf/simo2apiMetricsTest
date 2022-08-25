using simo2api.Areas.Masters.Entities;
//using simo2api.Areas.SPO.Entities;
using simo2api.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static simo2api.Helpers.HelperByQuery;

namespace simo2api.Areas.Masters.Services
{
    public class MastersServices
    {
        public string queryStr;

        public FuncDataStopWatch GetDataCabangDistByKdCabang(string KdCabang)
        {
            FuncDataStopWatch funcData = new FuncDataStopWatch();
            queryStr = "select * from spo.fn_GetListCabangDist() where KodeCabang = '@KdCabang'";
            queryStr = new HelperByQuery().AddParameterString(queryStr, "@KdCabang", KdCabang);
            ExcQuery listCb = new HelperByQuery().ExcecuteQuery(queryStr);
            CabangDistributor cabang = new CabangDistributor();
            if (listCb.Inquiry.Rows.Count > 0)
            {
                foreach (DataRow item in listCb.Inquiry.Rows)
                {
                    cabang.CabangId = Int32.Parse(item["ID"].ToString());
                    cabang.KodeCabang = item["KodeCabang"].ToString();
                    cabang.NamaCabang = item["NamaCabang"].ToString();
                }
                funcData.Data = cabang;
            }
            else
            {
                funcData.Data = null;
            }

            funcData.TimeExc = listCb.TimeQuery;

            return funcData;
        }
    
        public FuncDataStopWatch GetDataDistributor(string ? id = null)
        {
            queryStr = "select * from spo.fn_GetListDistributor() @id";
            queryStr = new HelperByQuery().AddParameterString(queryStr, "@id", id == null ? "" : "where id = " + id);
            ExcQuery excQuery = new HelperByQuery().ExcecuteQuery(queryStr);
            FuncDataStopWatch funcData = id == null ? new HelperByQuery().DtTableToJSON2(excQuery.Inquiry) : new HelperByQuery().DtTableToJSON3(excQuery.Inquiry);
            funcData.TimeExc = new HelperByQuery().ConvertTimeExc(excQuery.TimeQuery);
            return funcData;
        }
    }
}
