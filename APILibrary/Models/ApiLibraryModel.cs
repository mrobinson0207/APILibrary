using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 

namespace APILibrary.Models
{
    public class ApiLibraryItem
    {
        public int client_id { get; set; }
        public string api_key { get; set; }
        public string test_transaction { get; set; }
        public string date { get; set; }
        public string argBody { get; set; }
    }
}