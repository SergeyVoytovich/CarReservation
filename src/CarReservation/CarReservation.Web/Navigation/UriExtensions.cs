using Microsoft.AspNetCore.WebUtilities;
using System.Runtime.CompilerServices;

namespace CarReservation.Web.Navigation;

public static class UriExtensions
{
    public static string AddQueryString(this string uri, string key, string value)
        => string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(key) ? uri : QueryHelpers.AddQueryString(uri, key, value);

    public static string AddQueryString(this string uri, string key, Guid value)
        => uri.AddQueryString(key, value.ToString());

    public static string AddQueryString(this string uri, string key, DateTime date)
        => uri.AddQueryString(key, date.ToString());
}
