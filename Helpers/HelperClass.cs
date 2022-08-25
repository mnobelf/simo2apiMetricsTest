using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace simo2api.Helpers
{
    public class StatusAddData
    {
        public string? StatusAdd { get; set; }
        public string? StatusEmail { get; set; }
        public string? Error{ get; set; }

    }
    public class StatusDelData
    {
        public string? StatusDel { get; set; }
        public string? Error_Msg { get; set; }
    }
    public class PageData
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
        public int RowCount { get; set; }

    }
    public class StatusOutput
    {
        public string? StatusData { get; set; }
        public string? StatusEmail { get; set; }
        public string? Error { get; set; }

    }
    public class ExcQuery
    {
        public string? TimeQuery;
        public DataTable? Inquiry { get; set; }
        public int? success { get; set; }
        public string? error { get; set; }
    }
    public class DataJsonCatch2
    {
        public DataTable? Data;
        public Object? Output { get; set; }
        public String? TimeQuery { get; set; }

    }
    public class DataJsonCatch
    {
        public Object? Data;
        public Object? Output { get; set; }
        public String? TimeQuery { get; set; }

    }
    public class FuncDataStopWatch
    {
        public string? TimeExc { get; set; }
        public Object? Data { get; set; }
    }
    public class FuncDataStopWatch2
    {
        public string? TimeExc { get; set; }
        public String ? Data { get; set; }
    }
    public class ObjectJSON
    {
        public Object ? Data { get; set; }
    }
    public class PembuatanDo
    {
        public Object ? DataHeader { get; set; }
        public Object ? DataObat { get; set; }
        public Object? DoGrup { get; set; }
    }
    public class SpParam
    {
        public string ? PName;
        public string ? PValue;
        public SpParam Add(string PName, string PValue)
        {
            SpParam param = new SpParam();
            param.PName = PName;
            param.PValue = PValue;
            return param;
        }
    }
    public class FnParam
    {
        public string? PName;
        public string? PValue;
        public FnParam Add(string PName, string PValue)
        {
            FnParam param = new FnParam();
            param.PName = PName;
            param.PValue = PValue;
            return param;
        }
    }
    public class GeneratePassword
    {
        public string ? Password { get; set; }
        public string? HashPassword { get; set; }
        public bool IsVerify  { get; set; }

    }

    public class AppVersion
    {
        public string ? LastModified { get; set; }
        public string? Version { get; set; }
    }
}
