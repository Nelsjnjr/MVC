using Emaar.Models.Base;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emaar.Pier7.Website.Models.Pages
{
    [SitecoreType(TemplateId = "{3A514A6B-525B-41C6-874F-83E4B45582C0}", AutoMap = true)]
    public class ContactUs:BaseGlassItem
    {
        [SitecoreField("Description")]
        public virtual string Description { get; set; }
        [SitecoreField("PhoneNumber")]
        public virtual string PhoneNumber { get; set; }
        [SitecoreField("Email")]
        public virtual string Email { get; set; }
    }
}