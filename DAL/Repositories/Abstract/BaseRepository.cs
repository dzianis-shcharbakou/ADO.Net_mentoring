using ADO.Net.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Data.SqlClient;

namespace ADO.Net.Repositories.Abstract
{
    public abstract class BaseRepository<T> : IRepository<T> where T : new()
    {
        protected readonly DbProviderFactory ProviderFactory;
        protected readonly string ConnectionString;

        public BaseRepository(string connectionString, string provider)
        {
            this.ProviderFactory =
            DbProviderFactories.GetFactory(provider);
            this.ConnectionString = connectionString;
        }

        public virtual object Add(T entity)
        {
            object res;
            using (var connection = ProviderFactory.CreateConnection())
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();

                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    InsertCommandParameters(entity, cmd);
                    res =  cmd.ExecuteScalar();
                }
            }

            return res;
        }

        public virtual void Change(T entity)
        {
            using (var connection = ProviderFactory.CreateConnection())
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();

                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    UpdateCommandParameters(entity, cmd);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public virtual void Delete(int id)
        {
            using (var connection = ProviderFactory.CreateConnection())
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();

                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    DeleteCommandParameters(id, cmd);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public virtual IEnumerable<T> GetAll()
        {
            using (var connection = ProviderFactory.CreateConnection())
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();

                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    GetAllCommandParameters(cmd);
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        return Maps(reader);
                    }
                }
            }
        }

        public virtual T GetById(int id)
        {
            using (var connection = ProviderFactory.CreateConnection())
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();

                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    GetByIdCommandParameters(id, cmd);
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        return Map(reader);
                    }
                }
            }
        }

        protected abstract void InsertCommandParameters(T entity, DbCommand cmd);
        protected abstract void UpdateCommandParameters(T entity, DbCommand cmd);
        protected abstract void DeleteCommandParameters(int id, DbCommand cmd);
        protected abstract void GetByIdCommandParameters(int id, DbCommand cmd);
        protected abstract void GetAllCommandParameters(DbCommand cmd);
        protected abstract T Map(DbDataReader reader);
        protected abstract List<T> Maps(DbDataReader reader);
    }
}
