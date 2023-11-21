﻿using SqlViewer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlViewer.Dal
{
    static class Repository
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

        private static string? cs;

        internal static IEnumerable<Database> GetDatabases()
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
        internal static IEnumerable<Procedure> GetProcedures(Database database)
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


        internal static IEnumerable<Column> GetColumns(DbEntity entity)
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

        internal static IEnumerable<DbEntity> GetDbEntityes(Database database, DbEntityType entity)
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

        internal static void Login(
            string server, string username, string password)
        {
            using SqlConnection con = new SqlConnection(
                string.Format(ConnectionString, server, username, password));
            cs = con.ConnectionString;
            con.Open();
        }
    }
}