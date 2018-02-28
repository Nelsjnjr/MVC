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
    [SitecoreType(TemplateId = "{C1E04B61-E275-4232-8E88-86D54E6C9C99}", AutoMap = true)]
    public class Footer : BaseGlassItem
    {  
        [SitecoreField("Copyright")]
        public virtual string Copyright { get; set; }
       
    }
}