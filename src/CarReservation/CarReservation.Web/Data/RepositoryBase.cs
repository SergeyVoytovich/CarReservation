

using CarReservation.Web.Domain;

namespace CarReservation.Web.Data;

public abstract class RepositoryBase<T>(IEnumerable<T> items) : IRepository<T> where T : IDomain
{
    protected virtual IEnumerable<T> Items { get; } = items;

    public Task<IList<T>> GetAsync() => Task.FromResult<IList<T>>(Items.ToList());

    public Task<T?> GetAsync(Guid id) => Task.FromResult<T?>(Items.SingleOrDefault(i => i.Id == id));

    public Task<IList<T>> GetAsync(IList<Guid> ids) => Task.FromResult<IList<T>>(Items.Where(i => ids.Contains(i.Id)).ToList());
}
