using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Emaar.Pier7.Website.Attribute
{
    public class SitecoreRegEx : ValidationAttribute, IClientValidatable
    {
        private static object lockObject = new object();
        private string path;
        private string fieldName;
       

        public string DefaultErrorMessage { get; set; }
        public string pattern { get; set; }

        public SitecoreRegEx(string fieldName, string RegExpattern)
        {
            this.fieldName = fieldName;
            this.path = ValidationErrorMsg.GetPath();
            this.pattern = RegExpattern;
        }

        public override bool IsValid(object value)
        {


            string input = value == null ? string.Empty : value.ToString();
            bool valid = true;
            Regex regex = new Regex(@pattern);
            if (!String.IsNullOrEmpty(input))
            {

                Match match = regex.Match(input);
                if (!match.Success)
                { 
                    valid = false;
                    ErrorMessage = ValidationErrorMsg.GetErrorMessage(path, fieldName, ErrorMessage);
                }
            }

            // use the base IsValid property to do the work
            return valid;
        }

       

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var modelClientValidationRule = new ModelClientValidationRule
            {
                ValidationType = "sitecoreregex",
                ErrorMessage = ValidationErrorMsg.GetErrorMessage( path, fieldName, ErrorMessage)
            };
            modelClientValidationRule.ValidationParameters.Add("regexpattern", @pattern);
            return new List<ModelClientValidationRule> { modelClientValidationRule };
        }
    }
}