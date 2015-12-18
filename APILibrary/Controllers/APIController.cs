using APILibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace APILibrary.Controllers
{
    public class APILibraryController : ApiController
    {
        ApiLibraryItem[] names = new ApiLibraryItem[]
        {
            new ApiLibraryItem { client_id = 1, api_key = "Order Submit" },
            new ApiLibraryItem { client_id = 2, api_key = "Merchant Managed Rebill"},
            new ApiLibraryItem { client_id = 3, api_key = "Order Settle" },
            new ApiLibraryItem { client_id = 4, api_key = "Order Credit" },
            new ApiLibraryItem { client_id = 5, api_key = "Order CFT" },
            new ApiLibraryItem { client_id = 6, api_key = "Payout/CFT Without Previous Order" },
            new ApiLibraryItem { client_id = 7, api_key = "Order Voapi_key" },
            new ApiLibraryItem { client_id = 8, api_key = "Payout" },
            new ApiLibraryItem { client_id = 9, api_key = "Order Rebill Instant Update" },
            new ApiLibraryItem { client_id = 10, api_key = "Order Cancel Rebilling" },
            new ApiLibraryItem { client_id = 11, api_key = "VBV/3D Secure Authentication" },
            new ApiLibraryItem { client_id = 12, api_key = "Add to Merchant Blacklist" },
            new ApiLibraryItem { client_id = 13, api_key = "Remove from Merchant Blacklist" },
            new ApiLibraryItem { client_id = 14, api_key = "Add to Merchant Whitelist" },
            new ApiLibraryItem { client_id = 15, api_key = "Remove from Merchant Whitelist" },
            new ApiLibraryItem { client_id = 16, api_key = "Create Customer" },
            new ApiLibraryItem { client_id = 17, api_key = "Update Customer" },
            new ApiLibraryItem { client_id = 18, api_key = "Get Customer Cards" },
            new ApiLibraryItem { client_id = 19, api_key = "Phone Verify" },
            new ApiLibraryItem { client_id = 20, api_key = "INPay - getbanks" },
            new ApiLibraryItem { client_id = 21, api_key = "INPay - getinstructions" },
            new ApiLibraryItem { client_id = 22, api_key = "api_keyEAL ABN - getbanks" },
            new ApiLibraryItem { client_id = 23, api_key = "Earthport - GetPayoutRequiredData" }
        };

        public IEnumerable<ApiLibraryItem> GetAllNames()
        {
            return names;
        }

        public IHttpActionResult GetApiName (int id)
        {
            var name = names.FirstOrDefault((a) => a.client_id == id);
            if (name == null)
            {
                return NotFound();
            }
            return Ok(name);
        }
    }
}
