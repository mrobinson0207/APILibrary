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
            new ApiLibraryItem { id = 1, API_Name = "Order Submit" },
            new ApiLibraryItem { id = 2, API_Name = "Merchant Managed Rebill"},
            new ApiLibraryItem { id = 3, API_Name = "Order Settle" },
            new ApiLibraryItem { id = 4, API_Name = "Order Credit" },
            new ApiLibraryItem { id = 5, API_Name = "Order CFT" },
            new ApiLibraryItem { id = 6, API_Name = "Payout/CFT Without Previous Order" },
            new ApiLibraryItem { id = 7, API_Name = "Order VoAPI_Name" },
            new ApiLibraryItem { id = 8, API_Name = "Payout" },
            new ApiLibraryItem { id = 9, API_Name = "Order Rebill Instant Update" },
            new ApiLibraryItem { id = 10, API_Name = "Order Cancel Rebilling" },
            new ApiLibraryItem { id = 11, API_Name = "VBV/3D Secure Authentication" },
            new ApiLibraryItem { id = 12, API_Name = "Add to Merchant Blacklist" },
            new ApiLibraryItem { id = 13, API_Name = "Remove from Merchant Blacklist" },
            new ApiLibraryItem { id = 14, API_Name = "Add to Merchant Whitelist" },
            new ApiLibraryItem { id = 15, API_Name = "Remove from Merchant Whitelist" },
            new ApiLibraryItem { id = 16, API_Name = "Create Customer" },
            new ApiLibraryItem { id = 17, API_Name = "Update Customer" },
            new ApiLibraryItem { id = 18, API_Name = "Get Customer Cards" },
            new ApiLibraryItem { id = 19, API_Name = "Phone Verify" },
            new ApiLibraryItem { id = 20, API_Name = "INPay - getbanks" },
            new ApiLibraryItem { id = 21, API_Name = "INPay - getinstructions" },
            new ApiLibraryItem { id = 22, API_Name = "API_NameEAL ABN - getbanks" },
            new ApiLibraryItem { id = 23, API_Name = "Earthport - GetPayoutRequiredData" }
        };

        public IEnumerable<ApiLibraryItem> GetAllNames()
        {
            return names;
        }

        public IHttpActionResult GetApiName (int id)
        {
            var name = names.FirstOrDefault((a) => a.id == id);
            if (name == null)
            {
                return NotFound();
            }
            return Ok(name);
        }
    }
}
