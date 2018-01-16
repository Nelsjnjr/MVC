using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emaar.Pier7.Website.Interface
{
    public interface ILeftContainer
    {
        [SitecoreId]
        Guid Id { get; }
        [SitecoreField("leftImage")]
         Image leftImage { get; set; }
        [SitecoreField("RelImage")]
         Image RelImage { get; set; }
        [SitecoreField("IsLeftArrowAvailable")]
         bool IsLeftArrowAvailable { get; set; }

        [SitecoreField("IsRightArrowAvailable")]
        bool IsRightArrowAvailable { get; set; }
        [SitecoreField("LeftArrowLink")]
         Link LeftArrowLink { get; set; }
        [SitecoreField("RightArrowLink")]
         Link RightArrowLink { get; set; }
    }
}
