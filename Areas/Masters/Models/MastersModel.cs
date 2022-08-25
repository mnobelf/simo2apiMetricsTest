using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using simo2api.Areas.Masters.Services;
//using simo2api.Areas.SPO.Entities;
//using simo2api.Areas.SPO.Models;
using simo2api.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using Prometheus;
using Sentry;
using simo2api.MetricsNamespace;

namespace simo2api.Areas.Masters.Models
{
    public class MastersModel
    {
        public string ? queryStr;

        public string GetDataDistributorAll(HttpRequest request)
        {
            DataJsonCatch dataJson = new DataJsonCatch();
            StatusOutput output = new StatusOutput();
            try
            {
                FuncDataStopWatch funcData = new MastersServices().GetDataDistributor();
                dataJson.Data = funcData.Data;
                dataJson.TimeQuery = funcData.TimeExc;
            }
            catch (Exception ex)
            {
                AppMetrics.GetDataDistributorAllErrorCounter.Inc();
                output.Error = ex.Message;
                dataJson.Output = output;
                SentrySdk.CaptureException(ex);
            }
            var getDist = new HelperByQuery().ObjectToJSONWithJSONNet(request,dataJson);
            return getDist;
        }
        public string GetDataCabangDistAll(HttpRequest request)
        {
            DataJsonCatch2 dataJson = new DataJsonCatch2();
            StatusOutput output = new StatusOutput();
            try
            {
                queryStr = "select * from spo.fn_GetListCabangDist()";
                ExcQuery listCb = new HelperByQuery().ExcecuteQuery(queryStr);
                dataJson.Data = listCb.Inquiry;
                dataJson.TimeQuery = listCb.TimeQuery;
            }
            catch (Exception ex)
            {
                AppMetrics.GetDataCabandDistAllErrorCounter.Inc();
                output.Error = ex.Message;
                dataJson.Output = output;
                SentrySdk.CaptureException(ex);
            }
            var getCb = new HelperByQuery().DtTableWithPaging(request, dataJson);
            return getCb;
        }
        public string GetDataCabangDistByDistId(HttpRequest request,string DistID,string ProvId)
        {
            DataJsonCatch2 dataJson = new DataJsonCatch2();
            StatusOutput output = new StatusOutput();
            try
            {
                queryStr = "select * from spo.fn_GetListCabangDistByID(@DistID,@ProvId)";
                queryStr = new HelperByQuery().AddParameterString(queryStr, "@DistID", DistID);
                queryStr = new HelperByQuery().AddParameterString(queryStr, "@ProvId", ProvId);
                ExcQuery listCb = new HelperByQuery().ExcecuteQuery(queryStr);
                dataJson.Data = listCb.Inquiry;
                dataJson.TimeQuery = listCb.TimeQuery;
            }
            catch (Exception ex)
            {
                AppMetrics.GetDataCabangByDistIdErrorCounter.Inc();
                output.Error = ex.Message;
                dataJson.Output = output;
                SentrySdk.CaptureException(ex);
            }
            var getCb = new HelperByQuery().DtTableWithPaging(request, dataJson);
            return getCb;
        }
        public string GetDataCabangDistByKdCabang(HttpRequest request, string KdCabang)
        {
            DataJsonCatch dataJson = new DataJsonCatch();
            StatusOutput output = new StatusOutput();
            try
            {
                FuncDataStopWatch funcData = new MastersServices().GetDataCabangDistByKdCabang(KdCabang);
                dataJson.Data = funcData.Data;
                dataJson.TimeQuery = funcData.TimeExc;
            }
            catch (Exception ex)
            {
                AppMetrics.GetDataCabangByKdCabangErrorCounter.Inc();
                output.Error = ex.Message;
                dataJson.Output = output;
                SentrySdk.CaptureException(ex);
            }
            var getCb = new HelperByQuery().ObjectToJSONWithJSONNet(request, dataJson);
            return getCb;
        }
        public string GetDataProviderAll(HttpRequest request,int offset, int limit)
        {
            DataJsonCatch2 dataJson = new DataJsonCatch2();
            StatusOutput output = new StatusOutput();
            try
            {
                queryStr = "select * from spo.fn_GetListProv() ORDER BY ID ASC OFFSET @offset ROWS FETCH NEXT @limit ROWS ONLY";
                queryStr = new HelperByQuery().AddParameterString(queryStr, "@offset", offset.ToString());
                queryStr = new HelperByQuery().AddParameterString(queryStr, "@limit", limit.ToString());

                ExcQuery inquiryProv = new HelperByQuery().ExcecuteQuery(queryStr);
                dataJson.Data = inquiryProv.Inquiry;
                dataJson.TimeQuery = inquiryProv.TimeQuery;
            }
            catch (Exception ex)
            {
                AppMetrics.GetDataProviderAllErrorCounter.Inc();
                output.Error = ex.Message;
                dataJson.Output = output;
                SentrySdk.CaptureException(ex);
            }
            var getProv = new HelperByQuery().DtTableWithPaging(request, dataJson);
            return getProv;
        }
        public string GetDataProviderByID(HttpRequest request, string id)
        {
            DataJsonCatch2 dataJson = new DataJsonCatch2();
            StatusOutput output = new StatusOutput();
            try
            {
                queryStr = "select * from spo.fn_GetListProv() WHERE ID = '@id'";
                queryStr = new HelperByQuery().AddParameterString(queryStr, "@id", id);
                ExcQuery inquiryProv = new HelperByQuery().ExcecuteQuery(queryStr);
                dataJson.Data = inquiryProv.Inquiry;
                dataJson.TimeQuery = inquiryProv.TimeQuery;
            }
            catch (Exception ex)
            {
                AppMetrics.GetDataProviderByIDErrorCounter.Inc();
                output.Error = ex.Message;
                dataJson.Output = output;
                SentrySdk.CaptureException(ex);
            }
            var getProv = new HelperByQuery().DtTableWithPaging(request, dataJson);
            return getProv;
        }
        public string GetDataRefStatus(HttpRequest request)
        {
            int i = 0;
            DataJsonCatch2 dataJson = new DataJsonCatch2();
            StatusOutput output = new StatusOutput();
            try
            {
                string x = "aku";
                i = Convert.ToInt32(x);
                queryStr = "select * from dbo.REFSTATUS";
                ExcQuery listDist = new HelperByQuery().ExcecuteQuery(queryStr);
                dataJson.Data = listDist.Inquiry;
                dataJson.TimeQuery = listDist.TimeQuery;
            }
            catch (Exception ex)
            {
                AppMetrics.GetDataRefStatusErrorCounter.Inc();
                output.Error = ex.Message;
                dataJson.Output = output;
                SentrySdk.CaptureException(ex);
            }
            var getDist = new HelperByQuery().DtTableWithPaging(request, dataJson);
            return getDist;
        }
        public string GetRejectList(HttpRequest request)
        {
            DataJsonCatch2 dataJson = new DataJsonCatch2();
            StatusOutput output = new StatusOutput();

            try
            {
                queryStr = "select * from dbo.RefTipeReject";
                ExcQuery listDist = new HelperByQuery().ExcecuteQuery(queryStr);
                dataJson.Data = listDist.Inquiry;
                dataJson.TimeQuery = listDist.TimeQuery;
            }
            catch (Exception ex)
            {
                AppMetrics.GetRejectListErrorCounter.Inc();
                output.Error = ex.Message;
                dataJson.Output = output;
                SentrySdk.CaptureException(ex);
            }
            var getDist = new HelperByQuery().DtTableWithPaging(request, dataJson);
            return getDist;
        }

        public EmailData GetDataEmail(string EmFor)
        {
            EmailData emailData = new EmailData();
            queryStr = "select* from masters.SendEmail where  Em_For = '@Em_For'";
            queryStr = new HelperByQuery().AddParameterString(queryStr, "@Em_For", EmFor);

            ExcQuery inquiryProv = new HelperByQuery().ExcecuteQuery(queryStr);

            foreach (DataRow item in inquiryProv.Inquiry.Rows)
            {
                emailData.Em_To = item["Em_To"].ToString();
                emailData.Em_Subject = item["Em_Subject"].ToString();
                emailData.Em_Body = item["Em_Body"].ToString();
                emailData.Em_Cc = item["Em_Cc"].ToString();
                emailData.Em_Bcc = item["Em_Bcc"].ToString();
            }
            return emailData;
        }
        public ICollection<ToEmail> GetEmailApprovalTo(string id)
        {
            List<ToEmail> emails = new List<ToEmail>();
            queryStr = "select top 1 Email from spo.fn_GetListVerifikator(@id)";
            queryStr = new HelperByQuery().AddParameterString(queryStr, "@id", id);
            ExcQuery excQuery = new HelperByQuery().ExcecuteQuery(queryStr);
            foreach (DataRow dr in excQuery.Inquiry.Rows)
            {
                ToEmail toEmail = new ToEmail();
                toEmail.To = dr["Email"].ToString();
                emails.Add(toEmail);
            }
            return emails;
        }
        public ICollection<ToEmail> GetEmailToDoReject(string KdKpm)
        {
            List<ToEmail> emails = new List<ToEmail>();
            queryStr = "select top 1 Email from users.UserInfo where KodeKpm = '@Id' AND RoleID in(9, 16, 17) AND Email is not null";
            queryStr = new HelperByQuery().AddParameterString(queryStr, "@Id", KdKpm);
            ExcQuery excQuery = new HelperByQuery().ExcecuteQuery(queryStr);
            foreach (DataRow dr in excQuery.Inquiry.Rows)
            {
                ToEmail toEmail = new ToEmail();
                toEmail.To = dr["Email"].ToString();
                emails.Add(toEmail);
            }
            return emails;
        }
        public ICollection<CcEmail> GetEmailDoRejectCc(string KdKpm)
        {
            List<CcEmail> emails = new List<CcEmail>();
            queryStr = "select distinct Email from users.UserInfo where KodeKpm = '@Id' AND RoleID in(9,16,17) AND Email is not null AND Status = 1 AND Approve = 1";
            queryStr = new HelperByQuery().AddParameterString(queryStr, "@Id", KdKpm);
            ExcQuery excQuery = new HelperByQuery().ExcecuteQuery(queryStr);
            foreach (DataRow dr in excQuery.Inquiry.Rows)
            {
                CcEmail ccEmail = new CcEmail();
                ccEmail.Cc = dr["Email"].ToString();
                emails.Add(ccEmail);
            }
            return emails;
        }
        public ICollection<CcEmail> GetEmailApprovalCc(string id)
        {
            List<CcEmail> emails = new List<CcEmail>();
            queryStr = "select Email from spo.fn_GetListVerifikator(@id)";
            queryStr = new HelperByQuery().AddParameterString(queryStr, "@id", id);
            ExcQuery excQuery = new HelperByQuery().ExcecuteQuery(queryStr);
            foreach (DataRow dr in excQuery.Inquiry.Rows)
            {
                CcEmail ccEmail = new CcEmail();
                ccEmail.Cc = dr["Email"].ToString();
                emails.Add(ccEmail);
            }
            return emails;
        }
        public ICollection<CcEmail> GetEmailAccApprovalCc(string DistId,string CbId)
        {
            List<CcEmail> emails = new List<CcEmail>();
            queryStr = "SELECT distinct Email FROM users.UserInfo WHERE CabangDistributor = '@CbDist' AND DistributorID = '@DistId' AND Status = 1 AND Approve = 1";
            queryStr = new HelperByQuery().AddParameterString(queryStr, "@DistId", DistId);
            queryStr = new HelperByQuery().AddParameterString(queryStr, "@CbId", CbId);
            ExcQuery excQuery = new HelperByQuery().ExcecuteQuery(queryStr);
            foreach (DataRow dr in excQuery.Inquiry.Rows)
            {
                CcEmail ccEmail = new CcEmail();
                ccEmail.Cc = dr["Email"].ToString();
                emails.Add(ccEmail);
            }
            return emails;
        }
        public ICollection<CcEmail> GetEmailDoSentCc(string KdKpm)
        {
            List<CcEmail> emails = new List<CcEmail>();
            queryStr = "select distinct Email from users.UserInfo where KodeKpm = '@Id' AND RoleID in(9,16,17) AND Email is not null AND Status = 1 AND Approve = 1";
            queryStr = new HelperByQuery().AddParameterString(queryStr, "@Id", KdKpm);
            ExcQuery excQuery = new HelperByQuery().ExcecuteQuery(queryStr);
            foreach (DataRow dr in excQuery.Inquiry.Rows)
            {
                CcEmail ccEmail = new CcEmail();
                ccEmail.Cc = dr["Email"].ToString();
                emails.Add(ccEmail);
            }
            return emails;
        }
        public ICollection<ToEmail> GetEmailDoReciveTo(string DistId,string CbId)
        {
            List<ToEmail> emails = new List<ToEmail>();
            queryStr = "select top 1 Email from users.fn_GetUserLoginAll() where DistId = @DistId and CbngId = '@CbId'";
            queryStr = new HelperByQuery().AddParameterString(queryStr, "@DistId", DistId);
            queryStr = new HelperByQuery().AddParameterString(queryStr, "@CbId", CbId);
            ExcQuery excQuery = new HelperByQuery().ExcecuteQuery(queryStr);
            foreach (DataRow dr in excQuery.Inquiry.Rows)
            {
                ToEmail toEmail = new ToEmail();
                toEmail.To = dr["Email"].ToString();
                emails.Add(toEmail);
            }
            return emails;
        }
        public ICollection<CcEmail> GetEmailDoReciveCc(string DistId, string CbId,string KdKpm)
        {
            List<CcEmail> emails = new List<CcEmail>();
            queryStr = "SELECT distinct Email FROM users.UserInfo WHERE CabangDistributor = '@CbDist' AND DistributorID = '@DistId' AND Status = 1 AND Approve = 1";
            queryStr = new HelperByQuery().AddParameterString(queryStr, "@DistId", DistId);
            queryStr = new HelperByQuery().AddParameterString(queryStr, "@CbId", CbId);
            ExcQuery dtDist = new HelperByQuery().ExcecuteQuery(queryStr);
            foreach (DataRow dr in dtDist.Inquiry.Rows)
            {
                CcEmail ccEmail = new CcEmail();
                ccEmail.Cc = dr["Email"].ToString();
                emails.Add(ccEmail);
            }

            queryStr = "select distinct Email from users.UserInfo where KodeKpm = '@KdKpm' AND RoleID in(9,16,17) AND Email is not null AND Status = 1 AND Approve = 1";
            queryStr = new HelperByQuery().AddParameterString(queryStr, "@KdKpm", KdKpm);
            ExcQuery dtKpm = new HelperByQuery().ExcecuteQuery(queryStr);
            foreach (DataRow dr in dtKpm.Inquiry.Rows)
            {
                CcEmail ccEmail = new CcEmail();
                ccEmail.Cc = dr["Email"].ToString();
                emails.Add(ccEmail);
            }
            return emails;
        }
        public List<CcEmail> GetEmailCc(string query)
        {
            List<CcEmail> ccEmails = new List<CcEmail>();
            queryStr = new HelperByQuery().AddParameterString(query, "`", "'");
            ExcQuery excQuery = new HelperByQuery().ExcecuteQuery(queryStr);
            foreach (DataRow dr in excQuery.Inquiry.Rows)
            {
                CcEmail ccEmail = new CcEmail();
                ccEmail.Cc = dr["Email"].ToString();
                ccEmails.Add(ccEmail);
            }

            return ccEmails;
        }
        public List<BccEmail> GetEmailBcc(string query)
        {
            List<BccEmail> bccEmails = new List<BccEmail>();
            queryStr = new HelperByQuery().AddParameterString(query, "`", "'");
            ExcQuery excQuery = new HelperByQuery().ExcecuteQuery(queryStr);
            foreach (DataRow dr in excQuery.Inquiry.Rows)
            {
                BccEmail bccEmail = new BccEmail();
                bccEmail.Bcc = dr["Email"].ToString();
                bccEmails.Add(bccEmail);
            }

            return bccEmails;
        }

        public string TestingParamSp()
        {
            List<SpParam> param = new List<SpParam>();
            queryStr = "users.sp_Userlogin";
            param.Add(new SpParam() { PName = "Username", PValue = "Gunn" });
            param.Add(new SpParam() { PName = "Password", PValue = "123" });

            string query = new HelperByQuery().CompletingSp(queryStr, param);
            
            return query;
        }
        
    }
}
