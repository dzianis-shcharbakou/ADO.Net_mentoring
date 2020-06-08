using ADO.Net.Models;
using ADO.Net.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ADO.Net.Repositories
{
    class TerritoryRepository : BaseRepository<Territory>
    {
        public TerritoryRepository(string connectionString, string provider)
            : base(connectionString, provider)
        {

        }
        protected override void DeleteCommandParameters(int id, DbCommand cmd)
        {
            cmd.CommandText = "DeleteTerritory";

            var paramId = cmd.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;

            cmd.Parameters.Add(paramId);
        }

        protected override void GetAllCommandParameters(DbCommand cmd)
        {
            cmd.CommandText = "GetAllTerritory";
        }

        protected override void GetByIdCommandParameters(int id, DbCommand cmd)
        {
            cmd.CommandText = "GetByIdTerritory";

            var paramId = cmd.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;

            cmd.Parameters.Add(paramId);
        }

        protected override void InsertCommandParameters(Territory entity, DbCommand cmd)
        {
            cmd.CommandText = "InsertTerritory";

            var paramName = cmd.CreateParameter();
            paramName.ParameterName = "@TerritoryID";
            paramName.Value = entity.TerritoryID;

            var paramDescription = cmd.CreateParameter();
            paramDescription.ParameterName = "@TerritoryDescription";
            paramDescription.Value = entity.TerritoryDescription;

            var paramPicture = cmd.CreateParameter();
            paramPicture.ParameterName = "@RegionID";
            paramPicture.Value = entity.RegionID;

            cmd.Parameters.Add(paramPicture);
            cmd.Parameters.Add(paramName);
            cmd.Parameters.Add(paramDescription);
        }

        protected override Territory Map(DbDataReader reader)
        {
            Territory entity = new Territory();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    entity.TerritoryID = reader["CategoryID"].ToString();
                    entity.TerritoryDescription = reader["CategoryName"].ToString();
                    entity.RegionID = Convert.ToInt32(reader["Description"].ToString());
                }
            }
            return entity;
        }

        protected override List<Territory> Maps(DbDataReader reader)
        {
            List<Territory> entityList = new List<Territory>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Territory entity = new Territory();
                    entity.TerritoryID = reader["CategoryID"].ToString();
                    entity.TerritoryDescription = reader["CategoryName"].ToString();
                    entity.RegionID = Convert.ToInt32(reader["Description"].ToString());
                    entityList.Add(entity);
                }
            }
            return entityList;
        }

        protected override void UpdateCommandParameters(Territory entity, DbCommand cmd)
        {
            cmd.CommandText = "UpdateTerritory";

            var paramId = cmd.CreateParameter();
            paramId.ParameterName = "@TerritoryID";
            paramId.Value = entity.TerritoryID;

            var paramName = cmd.CreateParameter();
            paramName.ParameterName = "@TerritoryDescription";
            paramName.Value = entity.TerritoryDescription;

            var paramDescription = cmd.CreateParameter();
            paramDescription.ParameterName = "@RegionID";
            paramDescription.Value = entity.RegionID;

            cmd.Parameters.Add(paramId);
            cmd.Parameters.Add(paramName);
            cmd.Parameters.Add(paramDescription);
        }
    }
}
