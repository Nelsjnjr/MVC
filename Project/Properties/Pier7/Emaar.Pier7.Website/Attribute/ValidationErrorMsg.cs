using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emaar.Pier7.Website.Attribute
{
    public class ValidationErrorMsg
    {
        public static string GetPath()
        {
            return "/sitecore/Content/Pier/Data/Subscribe";
        }
        public static string GetErrorMessage(string path, string fieldName, string ErrorMessage)
        {
            string message = null;
            Item item = Sitecore.Context.Database.GetItem(path, Sitecore.Context.Language);
            if (item != null && item.Versions.Count > 0)
            {
                message = item[fieldName];
            }
            if (string.IsNullOrWhiteSpace(message))
            {
                message = ErrorMessage;
            }
            return message;
        }
    }
}