using ADO.Net.Models;
using ADO.Net.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ADO.Net.Repositories
{
    class ShipperRepository : BaseRepository<Shipper>
    {
        public ShipperRepository(string connectionString, string provider)
            : base(connectionString, provider)
        {

        }
        protected override void DeleteCommandParameters(int id, DbCommand cmd)
        {
            cmd.CommandText = "DeleteShipper";

            var paramId = cmd.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;

            cmd.Parameters.Add(paramId);

        }

        protected override void GetAllCommandParameters(DbCommand cmd)
        {
            cmd.CommandText = "GetAllShipper";
        }

        protected override void GetByIdCommandParameters(int id, DbCommand cmd)
        {
            cmd.CommandText = "GetByIdShipper";

            var paramId = cmd.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;

            cmd.Parameters.Add(paramId);
        }

        protected override void InsertCommandParameters(Shipper entity, DbCommand cmd)
        {
            cmd.CommandText = "InsertShipper";

            var paramName = cmd.CreateParameter();
            paramName.ParameterName = "@CompanyName";
            paramName.Value = entity.CompanyName;

            var paramDescription = cmd.CreateParameter();
            paramDescription.ParameterName = "@Phone";
            paramDescription.Value = entity.Phone;

            cmd.Parameters.Add(paramName);
            cmd.Parameters.Add(paramDescription);
        }

        protected override Shipper Map(DbDataReader reader)
        {
            Shipper entity = new Shipper();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    entity.ShipperID = Convert.ToInt32(reader["ShipperID"].ToString());
                    entity.CompanyName = reader["CompanyName"].ToString();
                    entity.Phone = reader["Phone"].ToString();
                }
            }
            return entity;
        }

        protected override List<Shipper> Maps(DbDataReader reader)
        {
            List<Shipper> entityList = new List<Shipper>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Shipper entity = new Shipper();
                    entity.ShipperID = Convert.ToInt32(reader["ShipperID"].ToString());
                    entity.CompanyName = reader["CompanyName"].ToString();
                    entity.Phone = reader["Phone"].ToString();
                    entityList.Add(entity);
                }
            }
            return entityList;
        }

        protected override void UpdateCommandParameters(Shipper entity, DbCommand cmd)
        {
            cmd.CommandText = "UpdateShipper";

            var param1 = cmd.CreateParameter();
            param1.ParameterName = "@ShipperID";
            param1.Value = entity.ShipperID;

            var paramName = cmd.CreateParameter();
            paramName.ParameterName = "@CompanyName";
            paramName.Value = entity.CompanyName;

            var paramDescription = cmd.CreateParameter();
            paramDescription.ParameterName = "@Phone";
            paramDescription.Value = entity.Phone;

            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(paramName);
            cmd.Parameters.Add(paramDescription);
        }
    }
}
