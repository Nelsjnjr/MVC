using Emaar.Models.Base;
using Emaar.Pier7.Website.Models.Component;
using Emaar.Pier7.Website.Models.Component;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emaar.Pier7.Website.Models.Pages
{
    [SitecoreType(TemplateId = "{1A4895CB-29BA-46A9-AEC5-15728575C8F9}", AutoMap = true)]
    public class DineDetails : BaseGlassItem
    {
        [SitecoreField("DineTitle")]
        public virtual string DineTitle { get; set; }
        [SitecoreField("Description")]
        public virtual string Description { get; set; }


        [SitecoreField("MobileNumber")]
        public virtual string MobileNumber { get; set; }
        [SitecoreField("Email")]
        public virtual string Email { get; set; }
        [SitecoreField("WebsiteAddress")]
        public virtual Link WebsiteAddress { get; set; }
        [SitecoreField("Download Title")]
        public virtual string DownloadTitle { get; set; }
        [SitecoreField("DownloadUrl")]
        public virtual Link DownloadUrl { get; set; }
        [SitecoreField("SocialMediaItems")]
        public virtual IEnumerable<Social> SocialMediaItems { get; set; }
        [SitecoreField("DineImages")]
        public virtual IEnumerable<ImageComponent> DineImages { get; set; }
    }
}