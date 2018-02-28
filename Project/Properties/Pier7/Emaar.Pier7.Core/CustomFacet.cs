using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;
using Sitecore.Pipelines;
using Sitecore.Analytics.Model.Framework;

namespace Emaar.Core
{
    [Serializable]
    public class VisitorSubscriptionFacet : Facet, IVisitorSubscribtionFacet
    {       
        private const string VISITORSUBSCRIPTIONS = "Subscriptions";
        public VisitorSubscriptionFacet()
        {

            EnsureDictionary<IVisitorSubscriptionElement>(nameof(SubscriptionDetails));
        }
        public IElementDictionary<IVisitorSubscriptionElement> SubscriptionDetails
        {
            get
            {
                return GetDictionary<IVisitorSubscriptionElement>(nameof(SubscriptionDetails));
            }
        }
    }
    public interface IVisitorSubscribtionFacet : IFacet, IElement, IValidatable
    {

        IElementDictionary<IVisitorSubscriptionElement> SubscriptionDetails { get; }
    }

    public interface IVisitorSubscriptionElement : IElement
    {
        string Email { get; set; }
        string FullName { get; set; }
        string ContactNumber { get; set; }
        string Comments { get; set; }

    }
    [Serializable]
    public class CustomerDetailElement : Element, IVisitorSubscriptionElement
    {
        private const string FULLNAME = "FullName";
        private const string CONTACTNUMBER = "ContactNumber";
        private const string EMAIL = "Email";
        private const string COMMENTS = "Comments";

        public CustomerDetailElement()
        {
           
            this.EnsureAttribute<string>(nameof(FullName));
            this.EnsureAttribute<string>(nameof(ContactNumber));
            this.EnsureAttribute<string>(nameof(Email));
            this.EnsureAttribute<string>(nameof(Comments));

        }
        public string Comments
        {
            get { return GetAttribute<string>(nameof(Comments)); }
            set { SetAttribute<string>(nameof(Comments), value); }
        }
        public string Email
        {
            get { return GetAttribute<string>(nameof(Email)); }
            set { SetAttribute<string>(nameof(Email), value); }
        }
        public string ContactNumber
        {
            get { return GetAttribute<string>(nameof(ContactNumber)); }
            set { SetAttribute<string>(nameof(ContactNumber), value); }
        }
        public string FullName
        {
            get { return GetAttribute<string>(nameof(FullName)); }
            set { SetAttribute<string>(nameof(FullName), value); }
        }


    }
}
