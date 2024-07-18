using System;
using System.Collections.Generic;

namespace RestaurantApp.Models;

public partial class Restsurant
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Contact { get; set; }

    public string? Address { get; set; }
}
