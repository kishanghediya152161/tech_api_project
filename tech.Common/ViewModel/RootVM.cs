using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tech.Common.dbmodel;

namespace tech.Common.ViewModel
{
    public class RootVM
    {
        public string Status { get; set; }
        public string Copyright { get; set; }
        public string Section { get; set; }
        [JsonProperty("last_modified")]
        public DateTime LastUpdated { get; set; }
        [JsonProperty("num_results")]
        public int NumResults { get; set; }
        public List<ResultVM> Results { get; set; }
    }
}
