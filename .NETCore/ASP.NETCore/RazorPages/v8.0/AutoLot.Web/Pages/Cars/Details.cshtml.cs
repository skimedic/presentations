// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Web - Details.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/08/20
// ==================================

namespace AutoLot.Web.Pages.Cars;
public class DetailsModel : BasePageModel<Car,DetailsModel>
{
    public DetailsModel(IAppLogging<DetailsModel> appLogging, ICarRepo repo) 
        : base(appLogging, repo,"Details") { }
    public void OnGet(int? id) => GetOne(id);
}