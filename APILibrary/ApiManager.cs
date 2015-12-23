using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APILibrary.Models;

namespace APILibrary
{
    public class ApiManager
    {
        private string managerId;
        private string apiToken;

        public ApiManager(string managerId, string apiToken)
        {
            this.managerId = managerId;
            this.apiToken = apiToken;
        }

        public SearchRequest GetSearchResquest()
        {
            SearchRequest searchRequest = new SearchRequest(managerId, apiToken);
            return searchRequest;
        }
    }
}