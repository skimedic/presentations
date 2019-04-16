$.validator.addMethod("greaterthanzero", function (value, element, params) {
    return value > 0;
}); 
$.validator.unobtrusive.adapters.add("greaterthanzero", function (options) {
    options.rules["greaterthanzero"] = true;
    options.messages["greaterthanzero"] = options.message;
});

$.validator.addMethod("notgreaterthan", function (value, element, params) {
    return +value <= +$(params).val();
});
$.validator.unobtrusive.adapters.add("notgreaterthan", ["otherpropertyname","prefix"], function (options) {
    options.rules["notgreaterthan"] = "#" + options.params.prefix + options.params.otherpropertyname;
    options.messages["notgreaterthan"] = options.message;
});

