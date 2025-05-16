using System;

namespace ReStore.API.RequestHelpers;

public class PaginationMetadata //Part of the Response
{
    public int TotalCount{get;set;}
    public int PageSize{get;set;}
    public int CurrentPage{get;set;}
    public int TotalPages{get;set;}
}
