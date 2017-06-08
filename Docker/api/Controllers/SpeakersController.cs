using System.Collections.Generic;
using System.Linq;
using Kcdc.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
  [Route("api/[controller]")]
  public class SpeakersController
  {
    private readonly KcdcContext context;
    public SpeakersController(KcdcContext context)
    {
      this.context = context;
    }

    // GET api/speakers
    [HttpGet]
    public IEnumerable<Speaker> Get()
    {
      var speakers = this.context.Speakers.ToList();
      speakers.Add(new Speaker(){
        Id = 10,
        First = "Jim",
        Last = "Beam",
        EmailAddress = "Need@itNow.com"
      });
      return speakers;
    }

    [HttpGet, Route("{id}")]
    public Speaker GetById(int id)
    {
      System.Console.WriteLine($"Getting speaker id {id}");
      var speaker = this.context.Speakers.FirstOrDefault(x=>x.Id == id);
      return speaker;
    }
  }
}