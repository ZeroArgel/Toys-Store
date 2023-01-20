namespace ToysStore.Models.Filters
{
    using System;
    using System.Globalization;
    public class HeadersRequest : IHeadersRequest
    {
        public HeadersRequest(string cultureInfo, string zoneId)
        {
            CultureInfo = new CultureInfo(cultureInfo); // language.
            TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(zoneId); // timezone from request.
            RequestTime = DateTimeOffset.UtcNow; // Date in utc +00:00.
            // return date, var currentTime = TimeZoneInfo.ConvertTimeToUtc(RequestTime.DateTime, TimeZoneInfo);
        }
        public CultureInfo CultureInfo { get; }
        public DateTimeOffset RequestTime { get; }
        public TimeZoneInfo TimeZoneInfo { get; }
    }
}