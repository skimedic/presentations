// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Web - Details.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/08/20
// ==================================

namespace AutoLot.Web.Areas.Admin.Pages.Makes;
public class DetailsModel : BasePageModel<Make,DetailsModel>
{
    public DetailsModel(IAppLogging<DetailsModel> appLogging, IMakeRepo makeRepo) 
        : base(appLogging, makeRepo,"Details")
    {
    }
    public void OnGet(int? id) => GetOne(id);
}