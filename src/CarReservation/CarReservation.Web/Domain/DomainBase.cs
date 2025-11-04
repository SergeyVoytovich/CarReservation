namespace CarReservation.Web.Domain;

public abstract record DomainBase : IDomain
{
    public Guid Id { get; set; }
}