using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tech.Common.dbmodel
{
    public class Result
    {
        public int ResultId { get; set; }
        public string Section { get; set; }
        public string Subsection { get; set; }
        public string Title { get; set; }        
        public string Url { get; set; }
        public string Uri { get; set; }
        public string Byline { get; set; }
        public string ItemType { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime PublishedDate { get; set; }
        public string MaterialTypeFacet { get; set; }
        public string Kicker { get; set; }
        public string ShortUrl { get; set; }

        // Foreign Key
        public int RootId { get; set; }

        // Navigation properties for facets and multimedia
        public ICollection<Multimedium> Multimedia { get; set; }
        public ICollection<DesFacet> DesFacets { get; set; }
        public ICollection<OrgFacet> OrgFacets { get; set; }
        public ICollection<PerFacet> PerFacets { get; set; }
        public ICollection<GeoFacet> GeoFacets { get; set; }
    }
}
