$.validator.unobtrusive.adapters.addSingleVal("sitecoreregex", "regexpattern");
$.validator.addMethod('sitecoreregex', function (value, element, params) {
    if (value != null && value != "") {
        var patternMatch = new RegExp(params);
        if (patternMatch.test(value)) {
            return true;
        }
        else
            return false;
    }    
    return true;
}, '');