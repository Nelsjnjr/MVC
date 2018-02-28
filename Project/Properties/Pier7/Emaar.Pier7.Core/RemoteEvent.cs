using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Events;
using Sitecore.Pipelines;
using Sitecore.SecurityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emaar.Core
{
    public class MyEventRemote : EventArgs, IPassNativeEventArgs
    {
        public string Param1 { get; set; }
    }

    public class EventRaiser
    {
        public void RaiseEvent()
        {
            var parameters = new object[] { "param1", "param2" };
            Sitecore.Events.Event.RaiseEvent("testing:myevent", parameters);
            //Sitecore.Eventing.EventManager.QueueEvent<MyEventRemote>(new MyEventRemote());
            Sitecore.Diagnostics.Log.Info("============================Events from CD Custom Populated==========================", this);
            Sitecore.Context.Database.Properties["RemoteEventRaisedCustom"] = "Hi Remote event raised from CD custom";
        }
    }

    public class EventHandlers
    {
        public virtual void InitializeFromPipeline(PipelineArgs args)
        {
            var action = new Action<MyEventRemote>(RaiseRemoteEvent);
            Sitecore.Eventing.EventManager.Subscribe<MyEventRemote>(action);
        }

        private void RaiseRemoteEvent(MyEventRemote myEvent)
        {
            Sitecore.Events.Event.RaiseEvent("testing:myevent:remote",
                                             new object[] { myEvent.Param1 });
            Sitecore.Diagnostics.Log.Info("============================Events from CM triggered==========================", this);
        }

        protected virtual void OnMyEventRemote(object sender, EventArgs args)
        {
            Sitecore.Context.Database.Properties["RemoteEventRaisedCustom"] = "Hi Remote event raised from CM";

            var master = Sitecore.Configuration.Factory.GetDatabase("master");

            using (new SecurityDisabler())
            {
                var args1 = args as MyEventRemote;
                var itemOnMaster = master.GetItem("/sitecore/content/Home");

                using (new EditContext(itemOnMaster))
                {
                    itemOnMaster["Title"] = args1.Param1;
                }
            }
            Log.Info("Tadaa", this);
            Sitecore.Diagnostics.Log.Info("============================Events from CM Populated==========================", this);
        }

        protected virtual void OnMyEvent(object sender, EventArgs args)
        {
            var s1 = Sitecore.Events.Event.ExtractParameter<string>(args, 0);
            var e = new MyEventRemote() { Param1 = s1  };
            Sitecore.Eventing.EventManager.QueueEvent<MyEventRemote>(e);
            Sitecore.Diagnostics.Log.Info("============================Events from CD triggered==========================",this);
            Sitecore.Context.Database.Properties["RemoteEventRaisedCustom"] = "Hi Remote event raised from CD";
        }
    }
}
