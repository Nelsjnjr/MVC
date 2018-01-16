using Emaar.Models.Base;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emaar.Pier7.Website.Models.Component
{
    [SitecoreType(TemplateId = "{BCCB2DFC-B575-4121-800E-7D6A425C28D0}", AutoMap = true)]
    public class Social : BaseGlassItem
    {
        [SitecoreField("SocialMediaTitle")]
        public virtual string SocialMediaTitle { get; set; }
        [SitecoreField("SocialMediaUrl")]
        public virtual Link SocialMediaUrl { get; set; }
        [SitecoreField("SocialMediaIcon")]
        public virtual Image SocialMediaIcon { get; set; }
    }
}