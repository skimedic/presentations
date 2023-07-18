// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - Program.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/08
// See License.txt for more information
// ==================================

using System;

namespace EfCoreBasics;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("****** Fun with EF Core ******");
        //Console.WriteLine("\r\n****** Change Tracking ******");
        //new ChangeTracking().RunSamples();
        //Console.WriteLine("\r\n****** Querying ******");
        //new SimpleQueries().RunSamples();
        //Console.WriteLine("\r\n****** Related Data and Projections ******");
        //new RelatedDataAndProjections().RunSamples();
        Console.WriteLine("\r\n****** Persisting Data ******");
        new PersistingData().RunSamples();
        Console.WriteLine("Complete");
        Console.ReadLine();
    }
}