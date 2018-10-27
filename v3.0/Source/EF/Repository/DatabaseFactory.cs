namespace Kigg.LinqToSql.Repository
{

    using DomainObjects;
    
    public class DatabaseFactory : DisposableResource, IDatabaseFactory
    {
        private readonly IConnectionString _connectionString;

        //private readonly string _connectionString;
        private IDatabase _database;

        public DatabaseFactory(IConnectionString connectionString)
        {
            _connectionString = connectionString;
            Check.Argument.IsNotNull(connectionString, "connectionString");
        }

        public virtual IDatabase Get()
        {
            if (_database == null)
            {
                _database = new dotnetomaniakContext(_connectionString.Value);
            }

            return _database;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_database != null)
                {
                    _database.Dispose();
                }
            }

            base.Dispose(disposing);
        }
    }
}