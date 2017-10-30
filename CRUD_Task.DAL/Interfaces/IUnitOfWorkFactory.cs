namespace CRUD_Task.DAL.Interfaces
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork CreateUnitOfWork();
    }
}
