// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Web - Details.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/08/02
// ==================================

namespace AutoLot.Web.Pages.Cars;

public class DetailsModel(IAppLogging<DetailsModel> appLogging, ICarRepo repo)
    : BasePageModel<Car, DetailsModel>(appLogging, repo, "Details")
{
    public void OnGet(int? id) => GetOne(id);
}