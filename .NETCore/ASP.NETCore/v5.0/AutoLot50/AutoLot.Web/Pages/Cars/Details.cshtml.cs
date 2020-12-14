// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - Details.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/12/13
// ==================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoLot.Dal.EfStructures;
using AutoLot.Dal.Repos.Interfaces;
using AutoLot.Models.Entities;

namespace AutoLot.Web.Pages.Cars
{
    public class DetailsModel : PageModel
    {
        private readonly ICarRepo _repo;

        public DetailsModel(ICarRepo repo)
        {
            _repo = repo;
        }

        public Car Car { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            Car = _repo.Find(id.Value);
            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
