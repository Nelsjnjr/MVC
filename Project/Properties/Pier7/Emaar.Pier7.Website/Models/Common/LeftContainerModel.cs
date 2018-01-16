using Emaar.Pier7.Data;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Emaar.Models.Base;
namespace Emaar.Pier7.Website.Models.Common
{
    public class LeftContainerModel:BaseGlassItem
    {
        [SitecoreField("leftImage")]
        public virtual Image leftImage { get; set; }
        [SitecoreField("RelImage")]
        public virtual Image RelImage { get; set; }
        [SitecoreField("IsLeftArrowAvailable")]
        public virtual bool IsLeftArrowAvailable { get; set; }

        [SitecoreField("IsRightArrowAvailable")]
        public virtual bool IsRightArrowAvailable { get; set; }
        [SitecoreField("LeftArrowLink")]
        public virtual Link LeftArrowLink { get; set; }
        [SitecoreField("RightArrowLink")]
        public virtual Link RightArrowLink { get; set; }      

    }
}