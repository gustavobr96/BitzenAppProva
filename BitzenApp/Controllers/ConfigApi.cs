using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitzenApp.Controllers
{
    public class ConfigApi
    {
        public string UrlAPI { get; set; }

        public ConfigApi()
        {
            // LocalHost
            UrlAPI = "https://localhost:44336/api/";

        }
    }
}
