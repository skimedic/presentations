// Copyright Information
// ==================================
// EFCoreExamples - 13_JsonColumns - Visits.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/11/11
// ==================================

using System.ComponentModel.DataAnnotations;

namespace JsonColumns.Models;

public class Visits
{
    public Visits(double latitude, double longitude, int count)
    {
        Latitude = latitude;
        Longitude = longitude;
        Count = count;
    }
    [Key]
    public int Id { get; set; }
    public double Latitude { get; private set; }
    public double Longitude { get; private set; }
    public int Count { get; private set; }
    public List<string> Browsers { get; set; }
}