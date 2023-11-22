using SqlViewer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SqlViewer.Dal
{
    class SQLRepository : IRepository
    {
        #region constans
        private const string ConnectionString = "Server={0};Uid={1};Pwd={2}";
        private const string SelectDatabases = "SELECT name As Name FROM sys.databases";
        private const string SelectEntities = "SELECT TABLE_SCHEMA AS [Schema], TABLE_NAME AS Name FROM {0}.INFORMATION_SCHEMA.{1}S";
        private const string SelectProcedures = "SELECT SPECIFIC_NAME as Name, ROUTINE_DEFINITION as Definition FROM {0}.INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = 'PROCEDURE'";
        private const string SelectColumns = "SELECT COLUMN_NAME as Name, DATA_TYPE as DataType FROM {0}.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{1}'";
        private const string SelectProcedureParameters = "SELECT PARAMETER_NAME as Name, PARAMETER_MODE as Mode, DATA_TYPE as DataType FROM {0}.INFORMATION_SCHEMA.PARAMETERS WHERE SPECIFIC_NAME='{1}'";
        private const string SelectQuery = "SELECT * FROM {0}.{1}.{2}";
        #endregion

        private string? cs;

        public IEnumerable<Database> GetDatabases()
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = SelectDatabases;
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                yield return new Database
                {
                    Name = dr[nameof(Database.Name)].ToString()
                };
            }
        }
        public IEnumerable<Procedure> GetProcedures(Database database)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = string.Format(SelectProcedures, database.Name);
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                yield return new Procedure
                {
                    Name = dr[nameof(Procedure.Name)].ToString(),
                    Definition = dr[nameof(Procedure.Definition)].ToString(),
                    Database = database
                };
            }
        }


        public IEnumerable<Column> GetColumns(DbEntity entity)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = string.Format(SelectColumns, entity.Database?.Name, entity.Name);
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                yield return new Column
                {
                    Name = dr[nameof(Column.Name)].ToString(),
                    DataType = dr[nameof(Column.DataType)].ToString()
                };
            }
        }

        public IEnumerable<Parameter> GetParameters(Procedure procedure)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = string.Format(SelectProcedureParameters, procedure.Database?.Name, procedure.Name);
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                yield return new Parameter
                {
                    Name = dr[nameof(Parameter.Name)].ToString(),
                    Mode = dr[nameof(Parameter.Mode)].ToString(),
                    DataType = dr[nameof(Parameter.DataType)].ToString()
                };
            }
        }

        public IEnumerable<DbEntity> GetDbEntityes(Database database, DbEntityType entity)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = string.Format(SelectEntities, database.Name, entity.ToString());
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                yield return new DbEntity
                {
                    Name = dr[nameof(DbEntity.Name)].ToString(),
                    Schema = dr[nameof(DbEntity.Schema)].ToString(),
                    Database = database,
                };
            }
        }

        public void Login(
            string server, string username, string password)
        {
            using SqlConnection con = new SqlConnection(
                string.Format(ConnectionString, server, username, password));
            cs = con.ConnectionString;
            con.Open();
        }

        public DataSet CreateDataset(DbEntity dbEntity)
        {
            using SqlConnection con = new(cs);
            SqlDataAdapter da = new(
                string.Format(SelectQuery, dbEntity.Database?.Name, dbEntity.Schema, dbEntity.Name),
                con
                );
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        private string? message;
        private string? catalog = "master";

        public DataSet? ExecuteQuery(string query)
        {
            var UpperQuery = query.ToUpper();
            Debug.WriteLine(catalog);
            try
            {
                using SqlConnection con = new($"{cs}; Initial Catalog={catalog}");
                con.Open();

                if (UpperQuery.Contains("SELECT"))
                {
                    return ExecuteSelectQuery(query, con);
                }

                if (UpperQuery.Contains("USE"))
                {

                    return ExecuteUse(query, con);
                }
                else
                {
                    return ExecuteNonQuery(query, con);
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return null;
            }
        }

        private DataSet? ExecuteSelectQuery(string query, SqlConnection con)
        {
            SqlDataAdapter da = new(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            message = $"{ds.Tables[0].Rows.Count} row(s) affected.";
            return ds;
        }
        private DataSet? ExecuteUse(string query, SqlConnection con)
        {
            catalog = query.Remove(0, 4);
            message = GetSuccesMessage;
            return null;
        }

        private DataSet? ExecuteNonQuery(string query, SqlConnection con)
        {
            using SqlCommand cmd = new SqlCommand(query, con);
            int rowAffected = cmd.ExecuteNonQuery();
            var UpperQuery = query.ToUpper();
            if (UpperQuery.Contains("CREATE") || UpperQuery.Contains("ALTER") || UpperQuery.Contains("DROP"))
            {
                message = GetSuccesMessage;
            }
            else
            {
                message = $"{rowAffected} row(s) affected.";
            }
            return null;
        }

        public string? GetMessage() => message;
        public string? GetCurrentDatabase() => catalog;
        private static string? GetSuccesMessage => $"Commands completed successfully.{Environment.NewLine}Completion time: {DateTime.Now}";



    }
}
