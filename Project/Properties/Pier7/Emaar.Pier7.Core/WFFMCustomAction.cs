using log4net;
using Sitecore.Analytics;
using Sitecore.Analytics.Data;
using Sitecore.Analytics.DataAccess;
using Sitecore.Analytics.Model;
using Sitecore.Analytics.Tracking;
using Sitecore.Data;
using Sitecore.WFFM.Abstractions.Actions;
using Sitecore.WFFM.Actions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Sitecore.WFFM.Abstractions.Analytics;
using Sitecore.WFFM.Abstractions.Shared;
using Sitecore.SecurityModel;

namespace Emaar.Core
{

    public class WFFMCustomAction : WffmSaveAction
    {
        private ILog _log;

        public override void Execute(ID formId, AdaptedResultList adaptedFields, ActionCallContext actionCallContext = null, params object[] data)
        {
          

            _log = Sitecore.Diagnostics.LoggerFactory.GetLogger("LogFileAppender");

            var name = adaptedFields.GetEntryByName("Full Name");
            var contactno = adaptedFields.GetEntryByName("Contact Number");
            var email = adaptedFields.GetEntryByName("Email Address");

            var Age = adaptedFields.GetEntryByName("Age");
            var Company = adaptedFields.GetEntryByName("Company");
            var Designation = adaptedFields.GetEntryByName("Designation");

            _log.Info("Writing comment to database");
            HttpContext.Current.Session["Email"] = email;

            /// var goal = new PageEventData("My Custom Goal", Guid.Parse("{47FF654B-76B2-49EF-A6AA-C61AE6093768}"));
            // Tracker.Current.CurrentPage.Register(goal);
            LockAttemptResult<Contact> lockResult;
            ContactRepository contactRepository = Sitecore.Configuration.Factory.CreateObject("tracking/contactRepository", true) as ContactRepository;
            ContactManager contactManager = Sitecore.Configuration.Factory.CreateObject("tracking/contactManager", true) as ContactManager;

            var contact = Tracker.Current?.Contact;
            if (contact == null)
            {
                lockResult = new LockAttemptResult<Contact>(LockAttemptStatus.NotFound, null, null);
                contact = contactRepository.CreateContact(Sitecore.Data.ID.NewID);
                contact.Identifiers.AuthenticationLevel = Sitecore.Analytics.Model.AuthenticationLevel.None;
                contact.Identifiers.Identifier = "nels_jnjr@yahoo.com";
                contact.Identifiers.IdentificationLevel = ContactIdentificationLevel.Known;
                contact.System.Value = 0;
                contact.System.VisitCount = 0;
                contact.ContactSaveMode = ContactSaveMode.AlwaysSave;
                contactManager.FlushContactToXdb(contact);
                //  VisitorIdentification s = new VisitorIdentification();
            }
            else
            {
                lockResult = contactManager.TryLoadContact(contact.ContactId);


                contact = lockResult.Object;
            }
            if (contact != null)
            {
                var contactEmailAddresses = contact.GetFacet<IContactCommentsFacet>("Contact Details");

                if (!contactEmailAddresses.CustomerDetails.Contains("Contact Details"))
                {
                    contactEmailAddresses.CustomerDetails.Create("Contact Details");
                    contactEmailAddresses.CustomerDetails["Contact Details"].Age = "18";
                    contactEmailAddresses.CustomerDetails["Contact Details"].Company = "Companyemarr";
                    contactEmailAddresses.CustomerDetails["Contact Details"].FullName = "Designationdsddf";
                    contactEmailAddresses.CustomerDetails["Contact Details"].Email = "Emailaddress";
                }
                var leaseOwner = new LeaseOwner(GetType() + Guid.NewGuid().ToString(), LeaseOwnerType.OutOfRequestWorker);
               
                contactManager.SaveAndReleaseContactToXdb(contact);



            }
        }
    }
    public class AddContactToContactList : Sitecore.WFFM.Actions.SaveActions.AddContactToContactList
    {
        private readonly IAnalyticsTracker _analyticsTracker;

        public AddContactToContactList(IAnalyticsTracker analyticsTracker, IContactRepository contactRepository) : base(analyticsTracker, contactRepository)
        {
            _analyticsTracker = analyticsTracker;
        }
        public override void Execute(ID formId, AdaptedResultList adaptedFields, ActionCallContext actionCallContext = null, params object[] data)
        {
           

            if (!adaptedFields.IsTrueStatement(ExecuteWhen))
                return;

            var lists = ContactsLists.Split(',').Select(x => ID.Parse(x).ToString()).ToArray();

            using (new SecurityDisabler())
            {
                Contact currentContact = _analyticsTracker.CurrentContact;

                if (currentContact.Identifiers.IdentificationLevel != ContactIdentificationLevel.Known)
                {
                    var emailAddresses = currentContact.GetFacet<Sitecore.Analytics.Model.Entities.IContactEmailAddresses>("Emails");
                    if (emailAddresses.Entries.Contains("Preferred"))
                    {
                        var email = emailAddresses.Entries["Preferred"];
                        _analyticsTracker.Current.Session.Identify(email.SmtpAddress);
                    }
                }
//
                //var recipientId = new Sitecore.Modules.EmailCampaign.Xdb.XdbContactId(currentContact.ContactId);

               // var rootList = (Sitecore.Context.ContentDatabase ?? Sitecore.Context.Database).GetItem(RootListPath);

                //Assert.IsNotNull(rootList, "Empty root list.");

             //   var managerRootId = (rootList[ManagerRootsFieldName] ?? string.Empty).Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();

               // Assert.IsNotNullOrEmpty(managerRootId, "Empty manager root id.");

               // Log.Info($"AddContactToContactList [{currentContact.ContactId}, {ContactsLists}, {managerRootId}]", this);

               // ClientApi.UpdateSubscriptions(recipientId, lists, new string[] { }, managerRootId, false);
            }
        }
    

}

}
