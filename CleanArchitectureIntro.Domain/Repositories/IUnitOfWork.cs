namespace CleanArchitectureIntro.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync(CancellationToken cancellationToken);
        void SaveChanges();
    }
}
