using System;

namespace ReStore.API.RequestHelpers;

public class ProductParams
{
    public string? OrderBy { get; set; }
    public string? SearchTerm { get; set; }
    public string? Brands { get; set; }
    public string? Types { get; set; }
}
