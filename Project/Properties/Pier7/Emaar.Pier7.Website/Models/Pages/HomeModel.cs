using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Emaar.Pier7.Website.Models.Component;
using Emaar.Pier7.Data;
using Emaar.Models.Base;
namespace Emaar.Pier7.Website.Models.Pages
{
    public class HomeModel:BaseGlassItem
    {
        [SitecoreField("Page Title")]
        public virtual string PageTitle { get; set; }
        [SitecoreField("Page Carousel")]
        public virtual IEnumerable<ImageCarouselModel> PageCarousel { get; set; }
    }
}