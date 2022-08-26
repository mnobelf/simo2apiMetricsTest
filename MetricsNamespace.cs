using Prometheus;

namespace simo2api.MetricsNamespace
{
    public class AppMetrics
    {
        public static readonly Counter GetDataDistributorAllErrorCounter =
            Metrics.CreateCounter("simo2app_GetDataDistributorAll_total_errors", "total number of errors of GetDataDistributorAll method");
        public static readonly Counter GetDataCabandDistAllErrorCounter =
            Metrics.CreateCounter("simo2app_GetDataCabangDistAll_total_errors", "total number of errors of GetDataCabangDistAll method");
        public static readonly Counter GetDataCabangByDistIdErrorCounter =
            Metrics.CreateCounter("simo2app_GetDataCabangDistByDist_total_errors", "total number of errors of GetDataCabangDistByDistId method");
        public static readonly Counter GetDataCabangByKdCabangErrorCounter =
            Metrics.CreateCounter("simo2app_GetDataCabangDistByKdCabang_total_errors", "total number of errors of GetDataCabangDistByKdCabang method");
        public static readonly Counter GetDataProviderAllErrorCounter =
            Metrics.CreateCounter("simo2app_GetDataProviderAll_total_errors", "total number of errors of GetDataProviderAll method");
        public static readonly Counter GetDataProviderByIDErrorCounter =
            Metrics.CreateCounter("simo2app_GetDataProviderByID_total_errors", "total number of errors of GetDataProviderByID method");
        public static readonly Counter GetDataRefStatusErrorCounter =
            Metrics.CreateCounter("simo2app_GetDataRefStatus_total_errors", "total number of errors of GetDataRefStatus method");
        public static readonly Counter GetRejectListErrorCounter =
            Metrics.CreateCounter("simo2app_GetRejectList_total_errors", "total number of errors of GetRejectList method");
        public static readonly Counter GetAppVersionCounter =
            Metrics.CreateCounter("simo2api_GetAppVersion_total_calls", "total number of calls of GetAppVersion method");
        public static readonly Counter CreatePasswordCounter =
            Metrics.CreateCounter("simo2api_CreatePassword_total_calls", "total number of calls of CreatePassword method");
        public static readonly Counter VerifyPasswordCounter =
            Metrics.CreateCounter("simo2api_VerifyPassword_total_calls", "total number of calls of VerifyPassword method");
        public static readonly Counter AuthenticateCounter =
            Metrics.CreateCounter("simo2api_AuthenticateCounter_total_calls", "total number of calls of AutheticateCounter method");
        public static readonly Counter OnAuthorizationErrorCounter =
            Metrics.CreateCounter("simo2api_OnAuthorization_total_errors", "total number of OnAuthorization errors");
        public static readonly Summary AuthorizationSummary =
            Metrics.CreateSummary("simo2api_OnAuthorization_histogram", "total number of successful authorization");
        public static readonly Counter OnAuthorizationCounter =
            Metrics.CreateCounter("simo2api_OnAuthorization_total", "total number of successful authorization");
        public static readonly Counter ExecuteSPNewErrorCounter =
            Metrics.CreateCounter("simo2app_ExecuteSPNew_total_errors", "total number of errors of ExecuteSPNew method");
        public static readonly Counter ExecuteSPErrorCounter =
            Metrics.CreateCounter("simo2app_ExecuteSP_total_errors", "total number of errors of ExecuteSP method");
        public static readonly Counter DecryptErrorCounter =
            Metrics.CreateCounter("simo2api_UserService_Decrypt_total_errors", "total number of errors of Decrypt method");
        public static readonly Gauge AuthorizationLatencyGauge =
            Metrics.CreateGauge("simo2api_Authorization_latency_gauge", "authorization last latency");
        public static readonly Histogram GetRefStatusAllLatencyGauge =
            Metrics.CreateHistogram("simo2api_Get_RefStatusAll_latency_gauge", "GetRefStatusAll last latency");
        public static readonly Gauge GetDistributorAllLatencyGauge =
            Metrics.CreateGauge("simo2api_Get_DistributorAll_latency_gauge", "GetDistributorAll last latency");
        public static readonly Gauge Get_CabangDistAllLatencyGauge =
            Metrics.CreateGauge("simo2api_Get_CabangDistAll_latency_gauge", "Get_CabangDistAll last latency");
        public static readonly Gauge Get_CabangDistByDistIdlatencygauge =
            Metrics.CreateGauge("simo2api_Get_CabangDistByDistId_latency_gauge", "Get_CabangDistByDistId last latency");
        public static readonly Gauge Get_CabangDistByKdCabanglatencygauge =
            Metrics.CreateGauge("simo2api_Get_CabangDistByKdCabang_latency_gauge", "Get_CabangDistByKdCabang last latency");
        public static readonly Gauge Get_ProviderByIDlatencygauge =
            Metrics.CreateGauge("simo2api_Get_ProviderByID_latency_gauge", "Get_ProviderByID last latency");
        public static readonly Gauge Get_RejectListAlllatencygauge =
            Metrics.CreateGauge("simo2api_Get_RejectListAll_latency_gauge", "Get_RejectListAll last latency");
        public static readonly Gauge Get_ProviderAlllatencygauge =
            Metrics.CreateGauge("simo2api_Get_ProviderAll_latency_gauge", "Get_ProviderAll last latency");
        public static readonly Counter Get_RefStatusAllErrorCounter =
            Metrics.CreateCounter("simo2api_Get_RefStatusAll_total_errors", "total number of errors of Get_RefStatusAll method");
        public static readonly Counter AppExceptions =
            Metrics.CreateCounter("simo2api_total_errors", "total number of errors");



        public static void InitializeMetrics()
        {
            GetDataDistributorAllErrorCounter.IncTo(0);
            GetDataCabandDistAllErrorCounter.IncTo(0);
            GetDataCabangByDistIdErrorCounter.IncTo(0);
            GetDataCabangByKdCabangErrorCounter.IncTo(0);
            GetDataProviderAllErrorCounter.IncTo(0);
            GetDataProviderByIDErrorCounter.IncTo(0);
            GetDataProviderByIDErrorCounter.IncTo(0);
            GetRejectListErrorCounter.IncTo(0);
            GetAppVersionCounter.IncTo(0);
            CreatePasswordCounter.IncTo(0);
            VerifyPasswordCounter.IncTo(0);
            AuthenticateCounter.IncTo(0);
            OnAuthorizationErrorCounter.IncTo(0);
            OnAuthorizationCounter.IncTo(0);
            ExecuteSPErrorCounter.IncTo(0);
            ExecuteSPErrorCounter.IncTo(0);
            DecryptErrorCounter.IncTo(0);
            AuthorizationLatencyGauge.IncTo(0);
        }
        
    }
}
