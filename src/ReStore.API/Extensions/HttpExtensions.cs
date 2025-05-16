using System;
using System.Text.Json;
using ReStore.API.RequestHelpers;

namespace ReStore.API.Extensions;

public static class HttpExtensions
{
    public static void AddPaginationHeader(this HttpResponse response, PaginationMetadata metaData)
    {
        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

        response.Headers.Append("Pagination", JsonSerializer.Serialize(metaData, options));
        response.Headers.Append("Access-Control-Expose-Headers", "Pagination");
    }
}
