using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Sitecore.Data.Items;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Emaar.Pier7.Website.Attribute
{
    public class SitecoreRequiredField : RequiredAttribute, IClientValidatable
    {
        private static object lockObject = new object();
        private string path;
        private string fieldName;
        private Dictionary<string, string> errorMessages = new Dictionary<string, string>();

        /// public string DefaultErrorMessage { get; set; }

        public SitecoreRequiredField(string fieldName)
        {
            // The path is the GUID of the item that holds the validation messages
            this.path = ValidationErrorMsg.GetPath();

            // The fieldname is the name of the Sitecore field on the "path" item that relates
            // to this property
            this.fieldName = fieldName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            // Get the error message for this property in the current language
            ErrorMessage = ValidationErrorMsg.GetErrorMessage( path, fieldName, ErrorMessage);

            // use the base IsValid property to do the work
            return base.IsValid(value, validationContext);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var modelClientValidationRule = new ModelClientValidationRule
            {
                ValidationType = "sitecorerequiredfield",
                ErrorMessage = ValidationErrorMsg.GetErrorMessage( path, fieldName, ErrorMessage)
            };
            modelClientValidationRule.ValidationParameters.Add("param", metadata.PropertyName);
            return new List<ModelClientValidationRule> { modelClientValidationRule };
        }
    }
}
   