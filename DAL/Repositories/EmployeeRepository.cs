using ADO.Net.Models;
using ADO.Net.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ADO.Net.Repositories
{
    class EmployeeRepository : BaseRepository<Employee>
    {
        public EmployeeRepository(string connectionString, string provider)
            : base(connectionString, provider)
        {

        }
        protected override void DeleteCommandParameters(int id, DbCommand cmd)
        {
            cmd.CommandText = "DeleteEmployee";

            var paramId = cmd.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;

            cmd.Parameters.Add(paramId);
        }

        protected override void GetAllCommandParameters(DbCommand cmd)
        {
            cmd.CommandText = "GetAllEmployee";
        }

        protected override void GetByIdCommandParameters(int id, DbCommand cmd)
        {
            cmd.CommandText = "GetByIdEmployee";

            var paramId = cmd.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;

            cmd.Parameters.Add(paramId);
        }

        protected override void InsertCommandParameters(Employee entity, DbCommand cmd)
        {
            cmd.CommandText = "InsertEmployee";

            var paramName = cmd.CreateParameter();
            paramName.ParameterName = "@LastName";
            paramName.Value = entity.LastName;

            var paramDescription = cmd.CreateParameter();
            paramDescription.ParameterName = "@FirstName";
            paramDescription.Value = entity.FirstName;

            var paramPicture = cmd.CreateParameter();
            paramPicture.ParameterName = "@Title";
            paramPicture.Value = entity.Title;


            var param2 = cmd.CreateParameter();
            param2.ParameterName = "@TitleOfCourtesy";
            param2.Value = entity.TitleOfCourtesy;

            var param3 = cmd.CreateParameter();
            param3.ParameterName = "@BirthDate";
            param3.Value = entity.BirthDate;

            var param4 = cmd.CreateParameter();
            param4.ParameterName = "@HireDate";
            param4.Value = entity.HireDate;

            var param5 = cmd.CreateParameter();
            param5.ParameterName = "@Address";
            param5.Value = entity.Address;

            var param6 = cmd.CreateParameter();
            param6.ParameterName = "@City";
            param6.Value = entity.City;

            var param7 = cmd.CreateParameter();
            param7.ParameterName = "@Region";
            param7.Value = entity.Region;

            var param8 = cmd.CreateParameter();
            param8.ParameterName = "@PostalCode";
            param8.Value = entity.PostalCode;

            var param9 = cmd.CreateParameter();
            param9.ParameterName = "@Country";
            param9.Value = entity.Country;

            var param10 = cmd.CreateParameter();
            param10.ParameterName = "@HomePhone";
            param10.Value = entity.HomePhone;

            var param11 = cmd.CreateParameter();
            param11.ParameterName = "@Extension";
            param11.Value = entity.Extension;

            var param12 = cmd.CreateParameter();
            param12.ParameterName = "@Photo";
            param12.Value = entity.Photo;

            var param13 = cmd.CreateParameter();
            param13.ParameterName = "@Notes";
            param13.Value = entity.Notes;

            var param14 = cmd.CreateParameter();
            param14.ParameterName = "@ReportsTo";
            param14.Value = entity.ReportsTo;

            var param15 = cmd.CreateParameter();
            param15.ParameterName = "@PhotoPath";
            param15.Value = entity.PhotoPath;

            cmd.Parameters.Add(paramName);
            cmd.Parameters.Add(paramDescription);
            cmd.Parameters.Add(paramPicture);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);
            cmd.Parameters.Add(param5);
            cmd.Parameters.Add(param6);
            cmd.Parameters.Add(param7);
            cmd.Parameters.Add(param8);
            cmd.Parameters.Add(param9);
            cmd.Parameters.Add(param10);
            cmd.Parameters.Add(param11);
            cmd.Parameters.Add(param12);
            cmd.Parameters.Add(param13);
            cmd.Parameters.Add(param14);
            cmd.Parameters.Add(param15);
        }

        protected override Employee Map(DbDataReader reader)
        {
            Employee entity = new Employee();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    entity.EmployeeID = Convert.ToInt32(reader["EmployeeID"].ToString());
                    entity.LastName = reader["LastName"].ToString();
                    entity.FirstName = reader["FirstName"].ToString();
                    entity.Title = reader["Title"].ToString();
                    entity.TitleOfCourtesy = reader["TitleOfCourtesy"].ToString();
                    entity.BirthDate = Convert.ToDateTime(reader["BirthDate"].ToString());
                    entity.HireDate = Convert.ToDateTime(reader["HireDate"].ToString());
                    entity.Address = reader["Address"].ToString();
                    entity.City = reader["City"].ToString();
                    entity.Region = reader["Region"].ToString();
                    entity.PostalCode = reader["PostalCode"].ToString();
                    entity.Country = reader["Country"].ToString();
                    entity.HomePhone = reader["HomePhone"].ToString();
                    entity.Extension = reader["Extension"].ToString();
                    entity.Photo = Convert.FromBase64String(reader["Photo"].ToString());
                    entity.Notes = reader["Notes"].ToString();
                    entity.ReportsTo = Convert.ToInt32(reader["ReportsTo"].ToString());
                    entity.PhotoPath = reader["PhotoPath"].ToString();
                }
            }
            return entity;
        }

        protected override List<Employee> Maps(DbDataReader reader)
        {
            List<Employee> entityList = new List<Employee>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Employee entity = new Employee();
                    entity.EmployeeID = Convert.ToInt32(reader["EmployeeID"].ToString());
                    entity.LastName = reader["LastName"].ToString();
                    entity.FirstName = reader["FirstName"].ToString();
                    entity.Title = reader["Title"].ToString();
                    entity.TitleOfCourtesy = reader["TitleOfCourtesy"].ToString();
                    entity.BirthDate = Convert.ToDateTime(reader["BirthDate"].ToString());
                    entity.HireDate = Convert.ToDateTime(reader["HireDate"].ToString());
                    entity.Address = reader["Address"].ToString();
                    entity.City = reader["City"].ToString();
                    entity.Region = reader["Region"].ToString();
                    entity.PostalCode = reader["PostalCode"].ToString();
                    entity.Country = reader["Country"].ToString();
                    entity.HomePhone = reader["HomePhone"].ToString();
                    entity.Extension = reader["Extension"].ToString();
                    entity.Photo = Convert.FromBase64String(reader["Photo"].ToString());
                    entity.Notes = reader["Notes"].ToString();
                    entity.ReportsTo = Convert.ToInt32(reader["ReportsTo"].ToString());
                    entity.PhotoPath = reader["PhotoPath"].ToString();
                    entityList.Add(entity);
                }
            }
            return entityList;
        }

        protected override void UpdateCommandParameters(Employee entity, DbCommand cmd)
        {
            cmd.CommandText = "UpdateEmployee";

            var paramID = cmd.CreateParameter();
            paramID.ParameterName = "@EmployeeID";
            paramID.Value = entity.EmployeeID;

            var paramName = cmd.CreateParameter();
            paramName.ParameterName = "@LastName";
            paramName.Value = entity.LastName;

            var paramDescription = cmd.CreateParameter();
            paramDescription.ParameterName = "@FirstName";
            paramDescription.Value = entity.FirstName;

            var paramPicture = cmd.CreateParameter();
            paramPicture.ParameterName = "@Title";
            paramPicture.Value = entity.Title;


            var param2 = cmd.CreateParameter();
            param2.ParameterName = "@TitleOfCourtesy";
            param2.Value = entity.TitleOfCourtesy;

            var param3 = cmd.CreateParameter();
            param3.ParameterName = "@BirthDate";
            param3.Value = entity.BirthDate;

            var param4 = cmd.CreateParameter();
            param4.ParameterName = "@HireDate";
            param4.Value = entity.HireDate;

            var param5 = cmd.CreateParameter();
            param5.ParameterName = "@Address";
            param5.Value = entity.Address;

            var param6 = cmd.CreateParameter();
            param6.ParameterName = "@City";
            param6.Value = entity.City;

            var param7 = cmd.CreateParameter();
            param7.ParameterName = "@Region";
            param7.Value = entity.Region;

            var param8 = cmd.CreateParameter();
            param8.ParameterName = "@PostalCode";
            param8.Value = entity.PostalCode;

            var param9 = cmd.CreateParameter();
            param9.ParameterName = "@Country";
            param9.Value = entity.Country;

            var param10 = cmd.CreateParameter();
            param10.ParameterName = "@HomePhone";
            param10.Value = entity.HomePhone;

            var param11 = cmd.CreateParameter();
            param11.ParameterName = "@Extension";
            param11.Value = entity.Extension;

            var param12 = cmd.CreateParameter();
            param12.ParameterName = "@Photo";
            param12.Value = entity.Photo;

            var param13 = cmd.CreateParameter();
            param13.ParameterName = "@Notes";
            param13.Value = entity.Notes;

            var param14 = cmd.CreateParameter();
            param14.ParameterName = "@ReportsTo";
            param14.Value = entity.ReportsTo;

            var param15 = cmd.CreateParameter();
            param15.ParameterName = "@PhotoPath";
            param15.Value = entity.PhotoPath;

            
            cmd.Parameters.Add(paramID);
            cmd.Parameters.Add(paramName);
            cmd.Parameters.Add(paramDescription);
            cmd.Parameters.Add(paramPicture);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);
            cmd.Parameters.Add(param5);
            cmd.Parameters.Add(param6);
            cmd.Parameters.Add(param7);
            cmd.Parameters.Add(param8);
            cmd.Parameters.Add(param9);
            cmd.Parameters.Add(param10);
            cmd.Parameters.Add(param11);
            cmd.Parameters.Add(param12);
            cmd.Parameters.Add(param13);
            cmd.Parameters.Add(param14);
            cmd.Parameters.Add(param15);
        }
    }
}
