using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emaar.Models.Base
{
    public class ExternalMetadata : BaseGlassItem
    {
        [SitecoreField("OpenGraphDescription")]
        public virtual string OpenGraphDescription { get; set; }

        [SitecoreField("OpenGraphImage")]
        public virtual Image OpenGraphImage { get; set; }

        [SitecoreField("OpenGraphSiteName")]
        public virtual string OpenGraphSiteName { get; set; }

        [SitecoreField("OpenGraphTitle")]
        public virtual string OpenGraphTitle { get; set; }

        [SitecoreField("OpenGraphType")]
        public virtual string OpenGraphType { get; set; }
    }
}
