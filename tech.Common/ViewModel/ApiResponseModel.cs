using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace tech.Common.ViewModel
{
    public class ApiResponseModel
    {
        public ApiResponseModel()
        {
            Code = (int)HttpStatusCode.OK;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public dynamic Data { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int Code { get; set; }
        public int recordsFiltered { get; set; }
        public int recordsTotal { get; set; }
    }
}
