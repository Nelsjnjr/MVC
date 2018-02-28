using Emaar.Pier7.Data;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System.Collections.Generic;
using System.Web;
using Emaar.Models.Base;
using Sitecore.Data.Items;

namespace Emaar.Pier7.Website.Models.Common
{
    
    public class ImageCaurosel:BaseGlassItem
    {
        [SitecoreField("DineImages")]
        public virtual Item DineImages { get; set; }
        [SitecoreField("ImageFile")]
        public virtual Image ImageFile { get; set; }
        [SitecoreChildren]      
        public virtual IEnumerable<ImageCaurosel> CauroselImages { get; set; }
    }
}

