using Microsoft.AspNetCore.Http;
using simo2api.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static simo2api.Helpers.HelperByQuery;

namespace simo2api.Areas.UserManagement.Models
{
    public class RoleModel
    {
        public string queryStr;
        public string GetDataRoleAll(HttpRequest request)
        {
            queryStr = "select* from users.webpages_Roles";
            ExcQuery inquiryRole = new HelperByQuery().ExcecuteQuery(queryStr);
            var getRole = new HelperByQuery().DataTableToJSONWithJSONNetNew(request, inquiryRole);
            return getRole;
        }
    }
}
