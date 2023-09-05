namespace ApiEmployees.Repository
{
    public interface IDataAccess<TObject> where TObject : class
    {
        public Task<TObject> Get(int id);

        public Task<TObject> GetAll();
    }
}