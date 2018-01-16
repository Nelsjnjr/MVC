using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Emaar.Pier7.Data;
using Emaar.Models.Base;
namespace Emaar.Pier7.Website.Models.Common
{
    [SitecoreType(TemplateId = "{D74D1DDE-7C70-4130-8979-8321B60EBC1D}", AutoMap = true)]
    public class HeaderModel:BaseGlassItem,ILogo
    {
     
        [SitecoreField("Logo")]
        public virtual Image Logo { get; set; }
        [SitecoreField("LogoUrl")]        
        public virtual Link LogoUrl { get; set; }
        [SitecoreField("Subscribe me Title")]
        public virtual string SubscribeMeTitle { get; set; }
        [SitecoreField("Subscribe me Link")]
        public virtual Link SubscribeMeLink { get; set; }
 
    }
}