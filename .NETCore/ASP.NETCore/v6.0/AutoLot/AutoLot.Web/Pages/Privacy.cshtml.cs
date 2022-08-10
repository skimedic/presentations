// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - Privacy.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/08/09
// ==================================

namespace AutoLot.Web.Pages;

public class PrivacyModel : PageModel
{
    private readonly IAppLogging<PrivacyModel> _appLogging;

    public PrivacyModel(IAppLogging<PrivacyModel> appLogging)
    {
        _appLogging = appLogging;
    }

    public void OnGet()
    {
        _appLogging.LogAppDebug("Entered On Get");
    }
}

