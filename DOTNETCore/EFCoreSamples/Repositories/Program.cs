using System;
using Repositories.Context;
using Repositories.Models;
using Repositories.Repos;

namespace Repositories;

class Program
{
    static void Main(string[] args)
    {
        var repo = new BlogRepo(new BloggingContext());
        repo.Add(new Blog {Name = "Foo"},false);
        Console.WriteLine("Hello World!");
    }
}