namespace CarReservation.Web.Domain;

public static class DomainExtensions
{
    public static IEnumerable<T> ById<T>(this IEnumerable<T> source, Guid id) where T : IDomain
        => source.Where(i => i.Id == id);
}