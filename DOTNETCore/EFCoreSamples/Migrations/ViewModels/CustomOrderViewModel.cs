﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Migrations.ViewModels;

public class CustomOrderViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Color { get; set; }
    public string PetName { get; set; }
    public string Make { get; set; }

    [NotMapped]
    public string FullDetail =>$"{FirstName} {LastName} ordered a {Color} {Make} named {PetName}";
    public override string ToString() => FullDetail;
}