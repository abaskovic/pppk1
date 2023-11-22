using SqlViewer.Models;
using System.Data;

namespace SqlViewer.Dal
{
    internal interface IRepository
    {
        DataSet CreateDataset(DbEntity dbEntity);
        DataSet? ExecuteQuery(string query);
        string? GetMessage();
        string? GetCurrentDatabase();
        IEnumerable<Column> GetColumns(DbEntity entity);
        IEnumerable<Database> GetDatabases();
        IEnumerable<DbEntity> GetDbEntityes(Database database, DbEntityType entity);
        IEnumerable<Parameter> GetParameters(Procedure procedure);
        IEnumerable<Procedure> GetProcedures(Database database);
        void Login(string server, string username, string password);
    }
}