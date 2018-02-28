using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Events;
using Sitecore.Events.Hooks;
using Sitecore.SecurityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Emaar.Core
{

    [DataContract]
    public class ClearCacheEvent
    {
        public ClearCacheEvent(string cacheName)
        {
            this.CacheName = cacheName;
        }

        // Properties
        [DataMember]
        public string CacheName { get; protected set; }

    }



    [Serializable]
    public class ClearCacheEventArgs : EventArgs, IPassNativeEventArgs
    {
        public string CacheName { get; set; }

        public ClearCacheEventArgs(string cacheName)
        {
            this.CacheName = cacheName;
        }
    }





    public class ClearCacheEventHandler
    {
        public virtual void OnClearCacheRemote(object sender, EventArgs e)
        {
            Sitecore.Context.Database.Properties["RemoteEventRaisedCustom"] = "Hi Remote event raised from CM";
            var master = Sitecore.Configuration.Factory.GetDatabase("master");

            using (new SecurityDisabler())
            {
                var args = e as ClearCacheEventArgs;
                var itemOnMaster = master.GetItem("/sitecore/content/Home");

                using (new EditContext(itemOnMaster))
                {
                    itemOnMaster["Title"] = args.CacheName;
                }
            }
            Log.Info("Tadaa", this);
        }
        /// 

        /// This methos is used to raise the local event
        /// 

        /// 
        public static void Run(ClearCacheEvent @event)
        {
            Log.Info("ClearCacheEventHandler - Run", typeof(ClearCacheEventHandler));
            ClearCacheEventArgs args = new ClearCacheEventArgs(@event.CacheName);
            Event.RaiseEvent("clearcache:remote", new object[] { args });
        }
    }



    public class ClearCacheHook : IHook
    {
        public void Initialize()
        {
            var action = new Action<ClearCacheEvent>(ClearCacheEventHandler.Run);
            Sitecore.Eventing.EventManager.Subscribe(action);
        }
    }


    public class TriggerEvent
    {
        public void Trigger()
        {
            ClearCacheEvent inst = new ClearCacheEvent("Navigation");
            Sitecore.Eventing.EventManager.QueueEvent(inst);
        }
    }
}