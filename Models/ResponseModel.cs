using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using simo2api.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text.Json.Serialization;

namespace simo2api.Models
{
    public class WhoAmI
    {
        public string ? IpAddress { get; set; }
        public string ? UserAgent { get; set; }
        public string ? UserLanguages { get; set; }
        public string ? xUserID { get; set; }
    }

        public class Pagination
    {
        public int? PageNo { get; set; }
        public int? PageSize { get; set; }
        public int? RowCount { get; set; }
    }

    public class Output
    {
        public string? Error { get; set; }
        public string? StatusData { get; set; }
        public string? StatusEmail { get; set; }

    }
    public class OutputObject
    {
        public Object? Output { get; set; }

    }
    public class ResponseResult
    {
        public WhoAmI ? Whoami { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Pagination ? Paging { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public String ? TimeExc { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]

        public DataTable ? Data { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]

        public Output ? Output { get; set; }


        public ResponseResult(WhoAmI _Whoami, Pagination _paging, DataTable _data, String _time, Output _output)
        {
            Whoami = _Whoami;
            TimeExc = _time;
            Paging = _paging;
            Data = _data;
            Output = _output;
        }

        public ResponseResult(WhoAmI _Whoami, DataTable _data, String _time,Output _output)
        {
            Whoami = _Whoami;
            TimeExc = _time;
            Data = _data;
            Output = _output;
        }

        public ResponseResult(WhoAmI _Whoami, Output _output, String _time)
        {
            Whoami = _Whoami;
            TimeExc = _time;
            Output = _output;
        }
    }

    public class ResponseResult2
    {
        public WhoAmI? Whoami { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Pagination? Paging { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public String? TimeExc { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]

        public DataTable? Data { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]

        public StatusOutput? Output { get; set; }


        public ResponseResult2(WhoAmI _Whoami, Pagination _paging, DataTable _data, String _time, StatusOutput _output)
        {
            Whoami = _Whoami;
            TimeExc = _time;
            Paging = _paging;
            Data = _data;
            Output = _output;
        }

        public ResponseResult2(WhoAmI _Whoami, DataTable _data, String _time, StatusOutput _output)
        {
            Whoami = _Whoami;
            TimeExc = _time;
            Data = _data;
            Output = _output;
        }

        public ResponseResult2(WhoAmI _Whoami, StatusOutput _output, String _time)
        {
            Whoami = _Whoami;
            TimeExc = _time;
            Output = _output;
        }
    }

    public class ResponseResultObject
    {
        public WhoAmI ? Whoami { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Pagination ? Paging { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public String ? TimeExc { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Object  ? Data { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Object ? Output { get; set; }
        public ResponseResultObject(WhoAmI _Whoami, Pagination _paging, Object _object, String _time, Object _output)
        {
            Whoami = _Whoami;
            Paging = _paging;
            TimeExc = _time;
            Data = _object;
            Output = _output;
        }
        public ResponseResultObject(WhoAmI _Whoami, Object _object, String _time)
        {
            Whoami = _Whoami;
            TimeExc = _time;
            Data = _object;
        }

        public ResponseResultObject(WhoAmI _Whoami, Output _output, String _time)
        {
            Whoami = _Whoami;
            TimeExc = _time;
            Output = _output;

        }
    }
}
