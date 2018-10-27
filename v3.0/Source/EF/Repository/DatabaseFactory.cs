namespace Kigg.LinqToSql.Repository
{

    using DomainObjects;
    
    public class DatabaseFactory : DisposableResource, IDatabaseFactory
    {
        //private readonly string _connectionString;
        private readonly System.Data.IDbConnection _connection;
        private IDatabase _database;

        public DatabaseFactory(IConnectionString connectionString)
        {
            Check.Argument.IsNotNull(connectionString, "connectionString");
            _connection = new System.Data.SqlClient.SqlConnection(connectionString.Value);
        }

        public virtual IDatabase Get()
        {
            if (_database == null)
            {
                _database = new dotnetomaniakContext();
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