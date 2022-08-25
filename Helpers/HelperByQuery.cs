using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//using simo2api.Areas.SPO.Entities;
using simo2api.Entities;
using simo2api.Extensions;
using simo2api.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prometheus;
using Sentry;
using simo2api.MetricsNamespace;
using User = simo2api.Entities.User;

namespace simo2api.Helpers
{
    public class HelperByQuery
    {

        public ExcQuery ExcecuteQuery(string query)
        {
            ExcQuery exc = new ExcQuery();
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();

            exc.Inquiry = getDataByQuery(query);
            if (exc.Inquiry.Rows.Count > 0)
            {
                exc.success = 1;
                exc.error = null;
            }
            else
            {
                exc.success = 0;
                exc.error = "Data Kosong";
            }
            sw.Stop();

            string ExcTime = sw.Elapsed.TotalSeconds.ToString();
            ExcTime = ConvertTimeExc(ExcTime).Replace(" Second", "");
            double db = Math.Round(Convert.ToDouble(ExcTime), 2);
            exc.TimeQuery = db.ToString() + " Second";
            return exc;
        }
        public ExcQuery ExcecuteQueryNew(string query, List<FnParam> fnParams)
        {
            ExcQuery exc = new ExcQuery();
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();

            string CompletFn = CompletingFn(query, fnParams);
            exc.Inquiry = getDataByQuery(CompletFn);
            if (exc.Inquiry.Rows.Count > 0)
            {
                exc.success = 1;
                exc.error = null;
            }
            else
            {
                exc.success = 0;
                exc.error = "Data Kosong";
            }
            sw.Stop();

            string ExcTime = sw.Elapsed.TotalSeconds.ToString();
            ExcTime = ConvertTimeExc(ExcTime).Replace(" Second", "");
            double db = Math.Round(Convert.ToDouble(ExcTime), 2);
            exc.TimeQuery = db.ToString() + " Second";
            return exc;
        }
        public ExcQuery ExcecuteSP(string query)
        {
            ExcQuery exc = new ExcQuery();
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            try
            {
                exc.Inquiry = getDataByQuery(query);
                exc.success = 1;
                exc.error = "";
                sw.Stop();
            }
            catch (Exception ex)
            {
                AppMetrics.ExecuteSPErrorCounter.Inc();
                exc.success = 0;
                exc.error = ex.Message;
                SentrySdk.CaptureException(ex);
            }
            string ExcTime = sw.Elapsed.TotalSeconds.ToString();
            ExcTime = ConvertTimeExc(ExcTime).Replace(" Second", "");
            double db = Math.Round(Convert.ToDouble(ExcTime), 2);
            exc.TimeQuery = db.ToString() + " Second";
            return exc;
        }
        public ExcQuery ExcecuteSPNew(string query,List<SpParam> param)
        {
            ExcQuery exc = new ExcQuery();
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            try
            {
                string CompleteSp = CompletingSp(query, param);
                exc.Inquiry = getDataByQuery(CompleteSp);
                exc.success = 1;
                exc.error = "";
                sw.Stop();
            }
            catch (Exception ex)
            {
                AppMetrics.ExecuteSPNewErrorCounter.Inc();
                exc.success = 0;
                exc.error = ex.Message;
                SentrySdk.CaptureException(ex);
            }
            string ExcTime = sw.Elapsed.TotalSeconds.ToString();
            ExcTime = ConvertTimeExc(ExcTime).Replace(" Second", "");
            double db = Math.Round(Convert.ToDouble(ExcTime), 2);
            exc.TimeQuery = db.ToString() + " Second";
            return exc;
        }
        public DataTable getDataByQuery(string query)
        {
            SqlConnection conn = new SqlConnection(new ConfigConnection().getConnectionString());
            conn.Open();
            DataTable data = new DataTable();
            data.Clear();
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(data);
            conn.Close();

            //int rowCount = data.Rows.Count;
            //if(rowCount == 0)
            //{
            //    DataRow dr = data.NewRow();
            //    data.Clear();
            //    data.Columns.Add("Pesan");
            //    dr["Pesan"] = "null";
            //    data.Rows.Add(dr);
            //}
            return data;
        }
        public string DataTableToJSONWithJSONNetNew(HttpRequest request, ExcQuery item)
        {
            Output output = new Output();
            output.Error = item.error;

            var datas = new ResponseResult
            (
                HttpRequestExtension.GetHeader(request),
                item.Inquiry,
                item.TimeQuery,
                output
            );
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(datas);
            return JSONString;
        }
        public string DataTableToJSONWithJSONNetPaggingNew(HttpRequest request, ExcQuery item, int? offset, int? limit, int row)
        {
            Pagination paging = new Pagination();
            paging.PageNo = offset;
            paging.PageSize = limit;
            paging.RowCount = row;
            Output output = new Output();
            output.Error = item.error;

            var datas = new ResponseResult
            (
                HttpRequestExtension.GetHeader(request),
                paging,
                item.Inquiry,
                item.TimeQuery,
                output
            );
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(datas);
            return JSONString;
        }
        public string DtTableWithPaging(HttpRequest request, DataJsonCatch2 dataJson, Pagination? page = null)
        {
            StatusOutput output = new StatusOutput();
            if (dataJson.Output != null)
            {
                output = (StatusOutput)dataJson.Output;
            }
            else
            {
                output.Error = null;
                output.StatusData = null;
                output.StatusEmail = null;
            }
            var datas = new ResponseResult2
            (
                HttpRequestExtension.GetHeader(request),
                page,
                dataJson.Data,
                dataJson.TimeQuery,
                output
            );

            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(datas);
            return JSONString;
        }
        public string ObjectToJSONWithJSONNet(HttpRequest request, DataJsonCatch dataJson, Pagination? page = null)
        {
            StatusOutput output = new StatusOutput();
            if (dataJson.Output != null)
            {
                output = (StatusOutput)dataJson.Output;
            }
            else
            {
                output.Error = null;
                output.StatusData = null;
                output.StatusEmail = null;
            }
            var datas = new ResponseResultObject
            (
                HttpRequestExtension.GetHeader(request),
                page,
                dataJson.Data,
                dataJson.TimeQuery,
                output
            );

            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(datas);
            return JSONString;
        }
        public string TestJSON(Object objects)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(objects);
            return JSONString;
        }
        public User getUser(string query)
        {
            DataTable datas = getDataByQuery(query);
            User result = new User();
            foreach (DataRow dr in datas.Rows)
            {
                result.UserID = int.Parse(dr["UserID"].ToString());
                result.Nama = dr["Nama"].ToString();
                result.RoleName = dr["RoleName"].ToString();
                result.Email = dr["Email"].ToString();
                result.ProviderKD = dr["ProviderKD"].ToString();
                result.Password = dr["Password"].ToString();
                result.Username = dr["Username"].ToString();
                result.RoleID = dr["RoleID"].ToString();
                result.Prov_Nama = dr["Prov_Nama"].ToString();
                result.ProviderID = dr["ProviderID"].ToString();
                result.Dist_Nama = dr["Dist_Nama"].ToString();
                result.Dist_Email = dr["Dist_Email"].ToString();
                result.Cbng_Nama = dr["Cbng_Nama"].ToString();
                result.CbngID = dr["CbngId"].ToString();
                result.KodeKpm = dr["KodeKpm"].ToString();
                result.DistID = dr["DistId"].ToString();
                result.Kpm_Nama = dr["Kpm_Nama"].ToString();
            }
            return result;
        }
        public string AddParameterString(string strQuery, string param, string value)
        {
            strQuery = strQuery.Replace(param, value);
            return strQuery;
        }
        public string AddParameterSp(string strSp, string param, string value, int typeData = 1)
        {
            if (typeData == 1)
            {
                strSp = strSp + param + " = '" + value + "'"; // string
            }
            else if (typeData == 2) {
                strSp = strSp + param + " = " + value; // int
            }
            else
            {
                DateTime dt = new DateTime();
                strSp = strSp + param + " = " + value;
            }
            return strSp;
        }
        public string AddParameterSp2(string strSp, string param, string value)
        {
            bool cekString = IsDigitsOnly(value);

            if (!cekString)
            {
                strSp = strSp + param + " = '" + value + "'"; // string
            }
            else if (cekString)
            {
                strSp = strSp + param + " = " + value; // int
            }
            else
            {
                DateTime dt = new DateTime();
                strSp = strSp + param + " = " + value;
            }
            return strSp;
        }
        public bool IsDigitsOnly(string str)
        {
            if (str == null || str == "")
            {
                str = "null";
            }
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }
        public string ConvertTimeExc(string time,string ? extime = null)
        {
            if (time.Contains("Second"))
            {
                time = time.Replace(" Second", "");
            }
            double doub = Convert.ToDouble(time);
            if(extime != null)
            {
                if (extime.Contains("Second"))
                {
                    extime = extime.Replace(" Second", "");
                }
                doub =Convert.ToDouble(time) + Convert.ToDouble(extime);
            }

            return doub.ToString("0.00") + " Second";
        }
        public ObjectJSON DtTableToJSON(DataTable datas)
        {
            ObjectJSON objectJSON = new ObjectJSON();
            string JSONString = JsonConvert.SerializeObject(datas);
            dynamic ? data = JsonConvert.DeserializeObject<dynamic>(JSONString);
            objectJSON.Data = data;
            return objectJSON;
        }
        public FuncDataStopWatch DtTableToJSON2(DataTable datas)
        {
            FuncDataStopWatch objectJSON = new FuncDataStopWatch();
            string JSONString = JsonConvert.SerializeObject(datas);
            dynamic? data = JsonConvert.DeserializeObject<dynamic>(JSONString);
            objectJSON.Data = data;
            return objectJSON;
        }
        public FuncDataStopWatch DtTableToJSON3(DataTable datas)
        {
            FuncDataStopWatch objectJSON = new FuncDataStopWatch();
            string JSONString = JsonConvert.SerializeObject(datas);
            JArray dataArr = JArray.Parse(JSONString);
            JObject data = JObject.Parse(dataArr[0].ToString());
            objectJSON.Data = data;
            return objectJSON;
        }
        public string CompletingSp(string query,List<SpParam> param)
        {
            query = "Exec " + query + " ";
            bool first = true;
            foreach (var items in param)
            {
                if (first)
                {
                    query = AddParameterSp2(query,items.PName, items.PValue);
                    first = false;
                }
                else
                {
                    query = AddParameterSp2(query, " ,"+items.PName, items.PValue);
                }
            }
            return query;
        }
        public string CompletingFn(string query, List<FnParam> param)
        {
            foreach (var items in param)
            {
                    query = AddParameterString(query, items.PName, items.PValue);
            }
            return query;
        }

        public string ReadTextHtml(string path)
        {
            string root = System.IO.Directory.GetCurrentDirectory();
            string path_name = root + path + ".html";
            string HtmlContent = "";
            using (StreamReader streamReader = new StreamReader(path_name, Encoding.UTF8))
            {
                HtmlContent = streamReader.ReadToEnd();
            }
            return HtmlContent;
        }
        public string GetLastModified()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(assembly.Location);
            DateTime lastModified = fileInfo.LastWriteTime;
            return lastModified.ToString("dd-MMM-yyyy HH:mm:ss");
        }
    }
}
