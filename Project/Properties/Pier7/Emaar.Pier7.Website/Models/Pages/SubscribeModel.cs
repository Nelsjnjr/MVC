using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Emaar.Pier7.Website.Attribute;
namespace Emaar.Pier7.Website.Models.Pages
{
    [SitecoreType(TemplateId = "{A87A00B1-E6DB-45AB-8B54-636FEC3B5523}")]
    public class SubscribeModel
    {
     
        [SitecoreField("FullName")]
        [SitecoreRequiredField("FullNameRequiredMsg", ErrorMessage = "Please enter full name.")]
        [SitecoreRegEx("FullNameValidationMsg", "^[a-zA-z .]*$", ErrorMessage = "Alphabet only in the Name.")]
        public virtual string FullName { get; set; }

        [SitecoreField("ContactNumber")]
        [SitecoreRequiredField("ContactNumberRequiredMsg", ErrorMessage = "Please enter contact number.")]
        [SitecoreRegEx("ContactNumberValidationMsg", "^[0-9 ]*$", ErrorMessage = "Numeric only for Phone number")]
        public virtual string ContactNumber { get; set; }

        [SitecoreField("Email")]
        [SitecoreRequiredField("EmailRequiredMsg", ErrorMessage = "Valid Email address required.")]
        [SitecoreRegEx("EmailValidationMsg", @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Valid Email address required.")]
      
        public virtual string Email { get; set; }

        [SitecoreField("Comments")]      
        [SitecoreRegEx("CommentsValidationMsg", "[a-zA-Z0-9.,;:()\\r\\n |\\s]{1,500}", ErrorMessage = "Number and Alphabet only in the Message")]
        public virtual string Comments { get; set; }

        public virtual bool IsFormEnabled { get; set; }
        public virtual bool IsError { get; set; }
    }
}