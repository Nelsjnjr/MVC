$.validator.unobtrusive.adapters.addSingleVal("sitecorerequiredfield", "required");
$.validator.addMethod('sitecorerequiredfield', function (value, element, params) {
    if (value != null && value != "") {
        return true;
    }
    else
        return false;
   
}, '');