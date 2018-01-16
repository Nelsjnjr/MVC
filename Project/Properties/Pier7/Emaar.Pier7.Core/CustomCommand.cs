using Sitecore.Diagnostics;
using Sitecore.EmailCampaign.Cm.sitecore_modules.Shell.EmailCampaign.UI.Dialogs;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emaar.Core
{
   public class CustomCommand:Command
    {
        public override void Execute(CommandContext context)
        {
            SheerResponse.Alert("im command");
     
        }
    }
}
