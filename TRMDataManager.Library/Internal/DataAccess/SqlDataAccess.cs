﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace TRMDataManager.Library.Internal.DataAccess
{
    internal class SqlDataAccess : IDisposable
    {
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public List<T> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<T> rows = connection
                    .Query<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).ToList();

                return rows;
            }
        }
        public void SaveData<T>(string storedProcedure, T parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

            }
        }

        private IDbConnection _connection;

        private IDbTransaction _transaction;
        // Open connect/start transaction method
        public void StartTransaction(string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();

            isClosed = false;
        }

        private bool isClosed = false;

        public void CommitTransaction()
        {
            _transaction?.Commit();
            _connection?.Close();

            isClosed = true;
        }

        public void RollbackTransaction()
        {
            _transaction?.Rollback();
            _connection?.Close();

            isClosed = true;
        }

        public void Dispose()
        {
            if (isClosed == false)
            {
                try
                {
                    CommitTransaction();
                }
                catch
                {
                   // TODO - log this issue
                }
            }

            _transaction = null;
            _connection = null;
        }
        // load using the transaction
        public List<T> LoadDataInTransaction<T, U>(string storedProcedure, U parameters)
        {
            List<T> rows = _connection.Query<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure, transaction: _transaction).ToList();

                return rows;
            
        }
        // Save using the transaction
        public void SaveDataInTransaction<T>(string storedProcedure, T parameters)
        {
            _connection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure, transaction: _transaction);
        }
        // Close connection/stop transaction method
        // Dispose

    }
}
