$.validator.addMethod("greaterthanzero",
    function(value, element, params) {
        return value > 0;
    });

$.validator.unobtrusive.adapters.add("greaterthanzero",
    function(options) {
        options.rules["greaterthanzero"] = true;
        options.messages["greaterthanzero"] = options.message;
    });

$.validator.addMethod("notgreaterthan",
    function(value, element, params) {
        return +value <= +$(params).val();
    });

$.validator.unobtrusive.adapters.add("notgreaterthan",
    ["otherpropertyname", "prefix"],
    function(options) {
        var rule = "#" + options.params.otherpropertyname;
        if (options.params.prefix !== undefined && options.params.prefix !== null && options.params.prefix !== '') {
            rule = "#" + options.params.prefix + "_" + options.params.otherpropertyname;
        }
        options.rules["notgreaterthan"] = rule;
        options.messages["notgreaterthan"] = options.message;
    });

function reValidate(ctl) {
    var form = ctl.form;
    $(form).valid();
}