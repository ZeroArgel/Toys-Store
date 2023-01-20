namespace ToysStore.Models.Filters
{
    using System;
    using System.Globalization;
    public interface IHeadersRequest
    {
        CultureInfo CultureInfo { get; }
        DateTimeOffset RequestTime { get; }
        TimeZoneInfo TimeZoneInfo { get; }
    }
}