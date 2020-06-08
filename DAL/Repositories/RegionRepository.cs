using ADO.Net.Models;
using ADO.Net.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ADO.Net.Repositories
{
    class RegionRepository : BaseRepository<Region>
    {
        public RegionRepository(string connectionString, string provider)
           : base(connectionString, provider)
        {

        }

        protected override void DeleteCommandParameters(int id, DbCommand cmd)
        {
            cmd.CommandText = "DeleteRegion";

            var paramId = cmd.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;

            cmd.Parameters.Add(paramId);

        }

        protected override void GetAllCommandParameters(DbCommand cmd)
        {
            cmd.CommandText = "GetAllRegion";
        }

        protected override void GetByIdCommandParameters(int id, DbCommand cmd)
        {
            cmd.CommandText = "GetByIdRegion";

            var paramId = cmd.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;

            cmd.Parameters.Add(paramId);

        }

        protected override void InsertCommandParameters(Region entity, DbCommand cmd)
        {
            cmd.CommandText = "InsertRegion";

            var paramName = cmd.CreateParameter();
            paramName.ParameterName = "@RegionID";
            paramName.Value = entity.RegionID;

            var paramDescription = cmd.CreateParameter();
            paramDescription.ParameterName = "@RegionDescription";
            paramDescription.Value = entity.RegionDescription;

            cmd.Parameters.Add(paramName);
            cmd.Parameters.Add(paramDescription);


        }

        protected override Region Map(DbDataReader reader)
        {
            Region entity = new Region();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    entity.RegionID = Convert.ToInt32(reader["RegionID"].ToString());
                    entity.RegionDescription = reader["RegionDescription"].ToString();
                }
            }
            return entity;
        }

        protected override List<Region> Maps(DbDataReader reader)
        {
            List<Region> entityList = new List<Region>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Region entity = new Region();
                    entity.RegionID = Convert.ToInt32(reader["RegionID"].ToString());
                    entity.RegionDescription = reader["RegionDescription"].ToString();
                    entityList.Add(entity);
                }
            }
            return entityList;
        }

        protected override void UpdateCommandParameters(Region entity, DbCommand cmd)
        {
            cmd.CommandText = "UpdateRegion";

            var paramName = cmd.CreateParameter();
            paramName.ParameterName = "@RegionID";
            paramName.Value = entity.RegionID;

            var paramDescription = cmd.CreateParameter();
            paramDescription.ParameterName = "@RegionDescription";
            paramDescription.Value = entity.RegionDescription;

            cmd.Parameters.Add(paramName);
            cmd.Parameters.Add(paramDescription);
        }
    }
}
