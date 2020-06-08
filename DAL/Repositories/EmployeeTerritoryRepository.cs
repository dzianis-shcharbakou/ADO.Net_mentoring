using ADO.Net.Models;
using ADO.Net.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ADO.Net.Repositories
{
    class EmployeeTerritoryRepository : BaseRepository<EmployeeTerritory>
    {
        public EmployeeTerritoryRepository(string connectionString, string provider)
           : base(connectionString, provider)
        {

        }
        protected override void DeleteCommandParameters(int id, DbCommand cmd)
        {
            cmd.CommandText = "DeleteEmployeeTerritory";

            var paramId = cmd.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;

            cmd.Parameters.Add(paramId);
        }

        protected override void GetAllCommandParameters(DbCommand cmd)
        {
            cmd.CommandText = "GetAllEmployeeTerritory";
        }

        protected override void GetByIdCommandParameters(int id, DbCommand cmd)
        {
            cmd.CommandText = "GetByIdEmployeeTerritory";

            var paramId = cmd.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;

            cmd.Parameters.Add(paramId);

        }

        protected override void InsertCommandParameters(EmployeeTerritory entity, DbCommand cmd)
        {
            cmd.CommandText = "InsertEmployeeTerritory";

            var paramName = cmd.CreateParameter();
            paramName.ParameterName = "@EmployeeID";
            paramName.Value = entity.EmployeeID;

            var paramDescription = cmd.CreateParameter();
            paramDescription.ParameterName = "@TerritoryID";
            paramDescription.Value = entity.TerritoryID;

            cmd.Parameters.Add(paramName);
            cmd.Parameters.Add(paramDescription);
        }

        protected override EmployeeTerritory Map(DbDataReader reader)
        {
            EmployeeTerritory entity = new EmployeeTerritory();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    entity.EmployeeID = Convert.ToInt32(reader["EmployeeID"].ToString());
                    entity.TerritoryID = reader["TerritoryID"].ToString();
                }
            }
            return entity;
        }

        protected override List<EmployeeTerritory> Maps(DbDataReader reader)
        {
            List<EmployeeTerritory> entityList = new List<EmployeeTerritory>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    EmployeeTerritory entity = new EmployeeTerritory();
                    entity.EmployeeID = Convert.ToInt32(reader["EmployeeID"].ToString());
                    entity.TerritoryID = reader["TerritoryID"].ToString();
                    entityList.Add(entity);
                }
            }
            return entityList;
        }

        protected override void UpdateCommandParameters(EmployeeTerritory entity, DbCommand cmd)
        {
            cmd.CommandText = "UpdateEmployeeTerritory";

            var paramName = cmd.CreateParameter();
            paramName.ParameterName = "@EmployeeID";
            paramName.Value = entity.EmployeeID;

            var paramDescription = cmd.CreateParameter();
            paramDescription.ParameterName = "@TerritoryID";
            paramDescription.Value = entity.TerritoryID;

            cmd.Parameters.Add(paramName);
            cmd.Parameters.Add(paramDescription);
        }
    }
}
