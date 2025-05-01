using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tech.Common.dbmodel;

namespace tech.Common.ViewModel
{
    public class ResultVM
    {
        public string Section { get; set; }
        public string Subsection { get; set; }
        public string Title { get; set; }        
        public string Url { get; set; }
        public string Uri { get; set; }
        public string Byline { get; set; }
        [JsonProperty("item_type")]
        public string ItemType { get; set; }
        [JsonProperty("updated_date")]
        public DateTime UpdatedDate { get; set; }
        [JsonProperty("created_date")]
        public DateTime CreatedDate { get; set; }
        [JsonProperty("published_date")]
        public DateTime PublishedDate { get; set; }
        [JsonProperty("material_type_facet")]
        public string MaterialTypeFacet { get; set; }
        public string Kicker { get; set; }
        [JsonProperty("des_facet")]
        public List<string> DesFacet { get; set; }
        [JsonProperty("org_facet")]
        public List<string> OrgFacet { get; set; }
        [JsonProperty("per_facet")]
        public List<string> PerFacet { get; set; }
        [JsonProperty("geo_facet")]
        public List<string> GeoFacet { get; set; }
        public List<MultimediumVM> Multimedia { get; set; }
        [JsonProperty("short_url")]
        public string ShortUrl { get; set; }
    }
}
