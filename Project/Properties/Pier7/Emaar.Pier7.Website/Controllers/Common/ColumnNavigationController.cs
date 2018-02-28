using Emaar.Core;
using Emaar.Pier7.Data;
using Emaar.Pier7.GlobalConstants;
using Emaar.Pier7.Website.Models.Common;
using Emaar.Pier7.Website.Models.Component;
using Emaar.Pier7.Website.ViewModel;
using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Analytics;
using Sitecore.Analytics.Data;
using Sitecore.Analytics.DataAccess;
using Sitecore.Analytics.Model;
using Sitecore.Analytics.Model.Entities;
using Sitecore.Analytics.Tracking;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.ListManagement;
using Sitecore.ListManagement.ContentSearch;
using Sitecore.ListManagement.ContentSearch.Model;

using Sitecore.Mvc.Presentation;
using Sitecore.Pipelines;
using Sitecore.SecurityModel;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Emaar.Models.Base;
using Glass.Mapper.Sc;

namespace Emaar.Pier7.Website.Controllers.Common
{
    public class ColumnNavigationController : Controller
    {
        private const int _MAX_RETRIES = 10;
        private int _retries;

        // GET: ColumnNavigation
        public ActionResult Index()
        {

            //ContactRepository contactRepository = Sitecore.Configuration.Factory.CreateObject("tracking/contactRepository", true) as ContactRepository;

            ////var contactRepository = new ContactRepository();
            //var contact = contactRepository.LoadContactReadOnly("nels_jnjr@yahoo.com");
            //ContactManager contactManager = Sitecore.Configuration.Factory.CreateObject("tracking/contactManager", true) as ContactManager;
            //LockAttemptResult<Contact> lockResult;
            //if (contact == null)
            //{
            //    lockResult = new LockAttemptResult<Contact>(LockAttemptStatus.NotFound, null, null);
            //    contact = contactRepository.CreateContact(Sitecore.Data.ID.NewID);
            //    contact.Identifiers.AuthenticationLevel = Sitecore.Analytics.Model.AuthenticationLevel.None;
            //    contact.Identifiers.Identifier = "nels_jnjr@yahoo.com";
            //    contact.Identifiers.IdentificationLevel = ContactIdentificationLevel.Known;
            //    contact.System.Value = 0;
            //    contact.System.VisitCount = 0;
            //    contact.ContactSaveMode = ContactSaveMode.AlwaysSave;
            //    contactManager.FlushContactToXdb(contact);

            //}
            //else
            //{
            //    lockResult = contactManager.TryLoadContact(contact.ContactId);
            //    contact = lockResult.Object;
            //}
            ////CustomerDetailElement hh = new CustomerDetailElement();

            ////contact.Tags.Add("ContactLists", "test");

            //var contactEmailAddresses = contact.GetFacet<IContactCommentsFacet>("Contact Details");

            //if (!contactEmailAddresses.CustomerDetails.Contains("Contact Details"))
            //{
            //    contactEmailAddresses.CustomerDetails.Create("Contact Details");
            //    contactEmailAddresses.CustomerDetails["Contact Details"].Age = "12";
            //    contactEmailAddresses.CustomerDetails["Contact Details"].Company = "Companydfd";
            //    contactEmailAddresses.CustomerDetails["Contact Details"].Designation = "Designationdsddf";
            //    contactEmailAddresses.CustomerDetails["Contact Details"].Email = "Emaila";
            //}
            //var leaseOwner = new LeaseOwner(GetType() + Guid.NewGuid().ToString(), LeaseOwnerType.OutOfRequestWorker);
            //Tracker.Current.Session.Identify("nels_jnjr@yahoo.com");
            ////contactManager.MergeContacts(contact, Tracker.Current.Contact);
            //// var options = new ContactSaveOptions(true, leaseOwner);
            //// Session.Abandon();
            //// repository.SaveContact(myContact, options);


            //ContactListManager listManager = Sitecore.Configuration.Factory.CreateObject("contactListManager", false) as ContactListManager;
            ////var list = listManager.FindById("{35858223-52DC-4785-E865-E164A01B0314}");
            ////List<ContactData> contactList = new List<ContactData>();

            ////var contacts = listManager.GetContacts(list); //this is how to get all contacts
            ////ContactData a = new ContactData() { Identifier = contact.Identifiers.Identifier };
            ////contactList.Add(a);
            ////listManager.AssociateContacts(list, contactList);
            ////contactManager.SaveAndReleaseContactToXdb(contact);


            ////listManager.AssociateContacts(list, contactList);
            //Item managerRoot = Sitecore.Data.Database.GetDatabase("master").GetItem("/sitecore/content/Email Campaign");

            //var recipientId = new Sitecore.Modules.EmailCampaign.Xdb.XdbContactId(contact.ContactId);
            //Sitecore.Modules.EmailCampaign.ClientApi.UpdateSubscriptions(recipientId, new[] { "{35858223-52DC-4785-E865-E164A01B0314}" }, new string[] { }, managerRoot.ID.ToString(), false);
            ////Sitecore.Modules.EmailCampaign.ClientApi.SendStandardMessage()


            ////ListManager<ContactList, ContactData> listManager = Factory.CreateObject("contactListManager", false) as ListManager<ContactList, ContactData>;
            ////using (new SecurityDisabler())
            ////{
            ////    using (IEnumerator<ContactList> enumerator = ((IEnumerable<ContactList>)listManager.GetAll((string)null, true)).GetEnumerator())
            ////    {
            ////        while (((IEnumerator)enumerator).MoveNext())
            ////        {
            ////            ContactList current = enumerator.Current;
            ////            //   output.AppendLine(current.Id.ToString());
            ////            Item obj = Factory.GetDatabase("master").GetItem(current.Id);
            ////            //this.Response.Write("List: " + current.get_DisplayName() + ", list id: (" + current.get_Id() + "), contacts in index: " + (object)listManager.GetContacts(current).Count<ContactData>() + ", contacts in field: " + ((BaseItem)obj).get_Item("Recipients"));
            ////            if (obj != null && listManager.GetContacts(current).Count<ContactData>() > int.Parse(((BaseItem)obj).Fields["Recipients"].ToString()))
            ////            {
            ////                obj.Editing.BeginEdit();
            ////                //  output.AppendLine(listManager.GetContacts(current).Count<ContactData>().ToString());
            ////                ((BaseItem)obj).Fields["Recipients"].Value = listManager.GetContacts(current).Count<ContactData>().ToString();
            ////                obj.Editing.EndEdit();
            ////                //this.Response.Write("</br>List field was updated");
            ////            }
            ////            //this.Response.Write("</br></br>");
            ////        }
            ////    }
            ////}

            //////var contact1 = Tracker.Current.Contact;
            //////var data1 = contact1.GetFacet<IEmployeeData>("Employee Data");
            //////data1.EmployeeId = "ABC123";
            ////new EventRaiser().RaiseEvent();
            ////new TriggerEvent().Trigger();
            ////CustomPipelineArgs pipelineArgs = new CustomPipelineArgs(Sitecore.Mvc.Presentation.PageContext.Current.Item);
            ////CorePipeline.Run("CustomPipeline", pipelineArgs);
            ////if (!pipelineArgs.Valid && !string.IsNullOrEmpty(pipelineArgs.Message))
            ////{
            ////    // Execute code here to deal with failed validation
            ////}



            //List<ColumnNavigationItem> navigation = new List<ColumnNavigationItem>();
            //Item homeItem = SitecoreHelper.GetSitecoreDB().GetItem("/sitecore/content/pier/pier7home", Sitecore.Context.Language);
            //foreach (Item childItem in homeItem.Children)
            //{
            //    Item checkItem = SitecoreHelper.GetSitecoreDB().GetItem(childItem.ID, Sitecore.Context.Language);
            //    var columnNavItem = SitecoreHelper.GetItem<ColumnNavigationItem>(checkItem.ID.ToGuid(), Sitecore.Context.Language);
            //    var pageMetaData = SitecoreHelper.GetItem<ExternalMetadata>(checkItem.ID.ToGuid(), Sitecore.Context.Language);

            //    if (checkItem != null && checkItem.Versions.Count > 0 && pageMetaData.IncludeInSitemap)
            //    {
            //        navigation.Add(columnNavItem);
            //    }
            //}
            //ColumnNavigationViewModel Navigation = new ColumnNavigationViewModel() { ColumnNavigationItems = navigation };

            var sitecoreService = new SitecoreService("web");
            var items = Sitecore.Context.Item;
            var model1 = sitecoreService.Cast<MenuItem>(items);
            var model2 = sitecoreService.CreateType<ExternalMetadata>(items);

            List<ColumnNavigationItem> navigation = new List<ColumnNavigationItem>();
            var data = SitecoreHelper.GetItems<ColumnNavigationItem>(new Guid(GlobalGuids.ColumnNavigationItem),
                                                       String.Format("{0}{1}", GlobalProperties.NavigationRootFolder, RenderingContext.CurrentOrNull.Rendering.Item.Name));
            foreach (var item in data)
            {
                Item checkItem = SitecoreHelper.GetSitecoreDB().GetItem(new Sitecore.Data.ID(item.Id), Sitecore.Context.Language);
                if (checkItem != null && checkItem.Versions.Count > 0)
                    navigation.Add(item);
            }
            ColumnNavigationViewModel Navigation = new ColumnNavigationViewModel() { ColumnNavigationItems = navigation };
            return View("~/Views/Common/ColumnNavigation.cshtml", Navigation);

           

        }
        public ContactData ConvertContactToContactData(Sitecore.Analytics.Tracking.Contact contact)
        {
            return new ContactData()
            {
                Identifier = contact.Identifiers.Identifier
            };
        }
        private bool IsContactInSession(string userName)
        {
            var tracker = Tracker.Current;

            if (tracker != null &&
                tracker.IsActive &&
                tracker.Session != null &&
                tracker.Session.Contact != null &&
                tracker.Session.Contact.Identifiers != null &&
                tracker.Session.Contact.Identifiers.Identifier != null &&
                tracker.Session.Contact.Identifiers.Identifier.Equals(userName, StringComparison.InvariantCultureIgnoreCase))
                return true;

            return false;
        }
    }
}