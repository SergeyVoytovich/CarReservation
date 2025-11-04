
namespace CarReservation.Web.Data;

public abstract class RepositoryBase<T>(IEnumerable<T> items) : IRepository<T>
{
    protected virtual IEnumerable<T> Items { get; } = items;

    public Task<IList<T>> GetAsync() => Task.FromResult<IList<T>>(Items.ToList());
}
