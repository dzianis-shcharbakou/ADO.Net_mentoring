using ADO.Net.Models;
using ADO.Net.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ADO.Net.Repositories
{
    public class CategoryRepository : BaseRepository<Category>
    {
        public CategoryRepository(string connectionString, string provider) 
            : base(connectionString, provider)
        {

        }
        protected override void DeleteCommandParameters(int id, DbCommand cmd)
        {
            cmd.CommandText = "DeleteCategory";

            var paramId = cmd.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;

            cmd.Parameters.Add(paramId);
        }

        protected override void GetAllCommandParameters(DbCommand cmd)
        {
            cmd.CommandText = "GetAllCategory";
        }

        protected override void GetByIdCommandParameters(int id, DbCommand cmd)
        {
            cmd.CommandText = "GetByIdCategory";

            var paramId = cmd.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;

            cmd.Parameters.Add(paramId);
        }

        protected override void InsertCommandParameters(Category entity, DbCommand cmd)
        {
            cmd.CommandText = "InsertCategory";

            var paramName = cmd.CreateParameter();
            paramName.ParameterName = "@CategoryName";
            paramName.Value = entity.CategoryName;

            var paramDescription = cmd.CreateParameter();
            paramDescription.ParameterName = "@Description";
            paramDescription.Value = entity.Description;

            var paramPicture = cmd.CreateParameter();
            paramPicture.ParameterName = "@Picture";
            paramPicture.Value = entity.Picture;

            cmd.Parameters.Add(paramName);
            cmd.Parameters.Add(paramDescription);
            cmd.Parameters.Add(paramPicture);
        }

        protected override Category Map(DbDataReader reader)
        {
            Category entity = new Category();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    entity.CategoryID = Convert.ToInt32(reader["CategoryID"].ToString());
                    entity.CategoryName = reader["CategoryName"].ToString();
                    entity.Description = reader["Description"].ToString();
                    entity.Picture = ((byte[])reader["Picture"]).Skip(78).ToArray();
                }
            }
            return entity;
        }

        protected override List<Category> Maps(DbDataReader reader)
        {
            List<Category> entityList = new List<Category>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Category entity = new Category
                    {
                        CategoryID = Convert.ToInt32(reader["CategoryID"].ToString()),
                        CategoryName = reader["CategoryName"].ToString(),
                        Description = reader["Description"].ToString(),
                        Picture = ((byte[])reader["Picture"]).Skip(78).ToArray()
                };
                    entityList.Add(entity);
                }
            }
            return entityList;
        }

        protected override void UpdateCommandParameters(Category entity, DbCommand cmd)
        {
            cmd.CommandText = "UpdateCategory";

            var paramId = cmd.CreateParameter();
            paramId.ParameterName = "@CategoryID";
            paramId.Value = entity.CategoryID;

            var paramName = cmd.CreateParameter();
            paramName.ParameterName = "@CategoryName";
            paramName.Value = entity.CategoryName;

            var paramDescription = cmd.CreateParameter();
            paramDescription.ParameterName = "@Description";
            paramDescription.Value = entity.Description;

            var paramPicture = cmd.CreateParameter();
            paramPicture.ParameterName = "@Picture";
            paramPicture.Value = entity.Picture;

            cmd.Parameters.Add(paramId);
            cmd.Parameters.Add(paramName);
            cmd.Parameters.Add(paramDescription);
            cmd.Parameters.Add(paramPicture);
        }
    }
}
