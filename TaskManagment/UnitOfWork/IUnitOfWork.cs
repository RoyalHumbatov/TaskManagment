namespace TaskManagment.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();
        void CommitAsync();
    }
}
