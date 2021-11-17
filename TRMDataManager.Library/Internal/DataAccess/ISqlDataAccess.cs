using System;
using System.Collections.Generic;

namespace TRMDataManager.Library.Internal.DataAccess
{
    public interface ISqlDataAccess
    {
        string GetConnectionString(string name);
        List<T> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName);
        void SaveData<T>(string storedProcedure, T parameters, string connectionStringName);
        void StartTransaction(string connectionStringName);
        void CommitTransaction();
        void RollbackTransaction();

        List<T> LoadDataInTransaction<T, U>(string storedProcedure, U parameters);
        void SaveDataInTransaction<T>(string storedProcedure, T parameters);
    }
}