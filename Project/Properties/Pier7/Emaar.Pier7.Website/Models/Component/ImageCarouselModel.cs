using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Emaar.Models.Base;

namespace Emaar.Pier7.Website.Models.Component
{
    public class ImageCarouselModel:BaseGlassItem
    {
        [SitecoreField("CarouselImage")]
        public virtual Image CarouseForelmage { get; set; }
        [SitecoreField("CarouselBackImage")]
        public virtual Image CarouselBackImage { get; set; }
        [SitecoreField("MobileCarouselImage")]
        public virtual Image MobileCarouselImage { get; set; }
        
        [SitecoreField("CallToAction")]

        public virtual Link CallToAction { get; set; }
        [SitecoreField("ImageTitle")]
        public virtual string ImageTitle { get; set; }
        [SitecoreField("CallToActionTitle")]
        public virtual string CallToActionTitle { get; set; }
   
    }
}