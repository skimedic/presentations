using Context;
using Microsoft.EntityFrameworkCore;

// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

//await new BlogsContext().Seed();

var db = new BlogsContext();

foreach (var auth in db.Authors)
{
    Console.WriteLine($"{auth.Name} {auth.Contact.Phone}");
}