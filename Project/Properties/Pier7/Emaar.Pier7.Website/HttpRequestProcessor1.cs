using System.Linq;
using Sitecore;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Pipelines.HttpRequest;
using System;
using System.Web;
using Sitecore.Links;
using Sitecore.Buckets.Managers;
using Sitecore.Buckets.Extensions;
using Sitecore.IO;
using Sitecore.Data;
using Sitecore.Layouts;

namespace Emaar.Pier7.Website
{



    // TODO: \App_Config\include\HttpRequestProcessor1.config created automatically when creating HttpRequestProcessor1 class.


    /// <summary>
    /// Requested Url http://xxxxx.com/product/car/
    /// </summary>
    public class CustomItemResolver : HttpRequestProcessor
    {
        /// <summary>
        /// This method used to resolve the item in sitecore using index based on the item name
        /// </summary>
        /// <param name="args"></param>
        public override void Process(HttpRequestArgs args)
        {
            if (Context.Item != null || Context.Database == null || args.Url.ItemPath.Length == 0)
                return;

            //http://domainname/en/chicken/
            var requestUrl = args.Url.ItemPath.TrimEnd('/');

            //http://domainname/en/chicken
            var index = requestUrl.LastIndexOf('/');
           //Gets the item name "chicken"
            var itemName = requestUrl.Substring(index + 1);
            using (var searchContext = ContentSearchManager.GetIndex("sitecore_web_index").CreateSearchContext())
            {
                //Find the item from the index using name and template id
                ID itemTemplateID = new Sitecore.Data.ID(new Guid("{AAECA0F0-87E7-42F1-9278-24C2C9250A06}"));
                var result = searchContext.GetQueryable<SearchResultItem>().
                    Where(
                        x => x.TemplateId == itemTemplateID &&
                        x.Name == itemName
                    ).FirstOrDefault();

                if (result != null)
                {
                    var item = result.GetItem();
                    if (item.Language == Context.Language)
                    {
                        Context.Item = result.GetItem();
                    }
                }
                else
                {
                    var langItem = Sitecore.Context.Database.GetItem(result.ItemId, Context.Language);
                    if (langItem != null)
                    {
                        Context.Item = langItem;
                    }
                }

            }

        }
    }
    /// <summary>
    /// This class is used to create custom url for the item based on the particular template
    /// </summary>
    public class CustomLinkManager : LinkProvider
    {
        public override string GetItemUrl(Sitecore.Data.Items.Item item, UrlOptions options)
        {
            //Only update the url's for the template items
            if (item.TemplateID == ID.Parse("{AAECA0F0-87E7-42F1-9278-24C2C9250A06}"))
            {
                var bucketUrl = base.GetItemUrl(item.Parent, options);
                return FileUtil.MakePath(item.Name, string.Empty).Replace(" ", "-");
            }
            return Sitecore.StringUtil.EnsurePostfix('/', base.GetItemUrl(item, options));
        }
    }

}