using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoLot.Dal.EfStructures;
using AutoLot.Dal.Repos.Interfaces;
using AutoLot.Models.Entities;
using AutoLot.Services.Logging;

namespace AutoLot.Web.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly ICarRepo _repo;
        private readonly IAppLogging<IndexModel> _appLogging;

        public IndexModel(ICarRepo repo, IAppLogging<IndexModel> appLogging)
        {
            _repo = repo;
            _appLogging = appLogging;
            _appLogging.LogAppError("Another Test");
        }

        public string MakeName { get; set; }
        public int? MakeId { get; set; }
        public IEnumerable<Car> Cars { get;set; }

        public void OnGet(int? makeId, string makeName)
        {

            MakeId = makeId;
            MakeName = makeName;
            Cars = makeId.HasValue 
                ? _repo.GetAllBy(makeId.Value) 
                : _repo.GetAllIgnoreQueryFilters();
        }
    }
}
