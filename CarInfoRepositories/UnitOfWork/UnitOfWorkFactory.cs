namespace CarInfoRepositories.UnitOfWork
{
    public class UnitOfWorkFactory: IUnitOfWorkFactory
    {
        public IUnitOfWork CreateUnitOfWork()
        {
            return new UnitOfWork();
        }
    }
}
