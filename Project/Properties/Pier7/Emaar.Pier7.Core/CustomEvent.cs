using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emaar.Core
{
    public class CustomEvent 
    {
        public void OnItemSaved(object sender, EventArgs args)
        {
            var item = Sitecore.Events.Event.ExtractParameter(args, 0) as Sitecore.Data.Items.Item;
            Sitecore.Diagnostics.Assert.IsNotNull(item, "No item in parameters");
            
        }
    }
}

