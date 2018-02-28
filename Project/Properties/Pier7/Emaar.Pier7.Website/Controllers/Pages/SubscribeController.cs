using Emaar.Core;
using Emaar.Pier7.Website.Models.Pages;
using Sitecore.Analytics;
using Sitecore.Analytics.Data;
using Sitecore.Analytics.DataAccess;
using Sitecore.Analytics.Model;
using Sitecore.Analytics.Tracking;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.ListManagement.ContentSearch;
using Sitecore.Modules.EmailCampaign.Recipients;
using Sitecore.SecurityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Emaar.Pier7.GlobalConstants;
using Emaar.Pier7.Data;
using Emaar.Pier7.Website.Email;

namespace Emaar.Pier7.Website.Controllers.Pages
{
    public class SubscribeController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            SubscribeModel subscribe = new SubscribeModel();
            subscribe.IsFormEnabled = true;
            subscribe.IsError = false;
            return View("~/Views/Pages/Subscribe.cshtml", subscribe);
        }
        [HttpPost]
        public ActionResult Index(SubscribeModel subscribe)
        {
            if (ModelState.IsValid)
            {
                using (new SecurityDisabler())
                {
                    try
                    {
                        string emailAddress = subscribe.Email;
                        EmailHelper emailhelper = new EmailHelper();
                        ContactRepository contactRepository = Sitecore.Configuration.Factory.CreateObject("tracking/contactRepository", true) as ContactRepository;
                        var contact = contactRepository.LoadContactReadOnly(emailAddress);
                        ContactManager contactManager = Sitecore.Configuration.Factory.CreateObject("tracking/contactManager", true) as ContactManager;
                        LockAttemptResult<Contact> lockResult;
                        if (contact == null)
                        {
                            lockResult = new LockAttemptResult<Contact>(LockAttemptStatus.NotFound, null, null);
                            contact = contactRepository.CreateContact(Sitecore.Data.ID.NewID);
                            contact.Identifiers.AuthenticationLevel = Sitecore.Analytics.Model.AuthenticationLevel.None;
                            contact.Identifiers.Identifier = emailAddress;
                            contact.Identifiers.IdentificationLevel = ContactIdentificationLevel.Known;
                            contact.System.Value = 0;
                            contact.System.VisitCount = 0;
                            contact.ContactSaveMode = ContactSaveMode.AlwaysSave;
                            contactManager.FlushContactToXdb(contact);
                        }
                        else
                        {
                            lockResult = contactManager.TryLoadContact(contact.ContactId);
                            contact = lockResult.Object;
                        }
                        var personal = contact.GetFacet<Sitecore.Analytics.Model.Entities.IContactPersonalInfo>("Personal");
                        personal.FirstName = subscribe.FullName;
                        var emailAddresses = contact.GetFacet<Sitecore.Analytics.Model.Entities.IContactEmailAddresses>("Emails");
                        if (!emailAddresses.Entries.Contains("Email"))
                        {
                            emailAddresses.Entries.Create("Email");
                        }
                        var email = emailAddresses.Entries["Email"];
                        email.SmtpAddress = emailAddress;
                        emailAddresses.Preferred = "Email";
                        var contactEmailAddresses = contact.GetFacet<IVisitorSubscribtionFacet>("Contact Details");
                        if (!contactEmailAddresses.SubscriptionDetails.Contains("Subscriber Details"))
                        {
                            contactEmailAddresses.SubscriptionDetails.Create("Subscriber");
                            contactEmailAddresses.SubscriptionDetails["Subscriber"].FullName = subscribe.FullName;
                            contactEmailAddresses.SubscriptionDetails["Subscriber"].ContactNumber = subscribe.ContactNumber;
                            contactEmailAddresses.SubscriptionDetails["Subscriber"].Email = subscribe.Email;
                            contactEmailAddresses.SubscriptionDetails["Subscriber"].Comments = subscribe.Comments;
                        }
                        ContactListManager listManager = Sitecore.Configuration.Factory.CreateObject("contactListManager", false) as ContactListManager;
                        contactManager.SaveAndReleaseContactToXdb(contact);
                        Tracker.Current.Session.Identify(subscribe.Email);
                        //Getting the Email Campaign ManagerRoot
                        Item managerRoot = Sitecore.Data.Database.GetDatabase(SitecoreHelper.GetSitecoreDB().ToString()).GetItem(GlobalProperties.EmailCampaignMangerRoot);
                        RecipientId recipient = RecipientRepository.GetDefaultInstance().ResolveRecipientId("xdb:" + contact.ContactId);
                        var recipientId = new Sitecore.Modules.EmailCampaign.Xdb.XdbContactId(contact.ContactId);
                        Sitecore.Modules.EmailCampaign.ClientApi.UpdateSubscriptions(recipientId, new[] { GlobalGuids.ContactList }, new string[] { }, managerRoot.ID.ToString(), false);
                        emailhelper.SendEmail(subscribe);
                        subscribe.IsFormEnabled = false;
                    }
                    catch (Exception ex)
                    {
                        subscribe.IsError = true;
                        subscribe.IsFormEnabled = false;
                        Sitecore.Diagnostics.Log.Error(ex.Message, this);
                    }
                }
                return View("~/Views/Pages/Subscribe.cshtml", subscribe);
            }
            subscribe.IsError = false;
            subscribe.IsFormEnabled = true;
            return View("~/Views/Pages/Subscribe.cshtml", subscribe);
        }

    }
}