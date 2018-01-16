using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emaar.Models.Base
{
    public interface ILogo
    {
        [SitecoreField("Logo")]
        Image Logo { get; }

        [SitecoreField("LogoUrl")]
        Link LogoUrl { get; }
    }
}