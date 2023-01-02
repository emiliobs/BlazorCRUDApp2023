using Blazor.Shared.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Blazor.Shared.Services
{
    public class StudentServices
    {
        private readonly string _connectionString = string.Empty;
        private readonly IConfiguration _configuration;

        public StudentServices(IConfiguration configuration)
        {
            _connectionString = _configuration.GetConnectionString("DBConnection");
        }

        public IEnumerable<StudentEntity> GetAllStudent()
        {
            List<StudentEntity> lstStudent = new();

            using (SqlConnection con = new(_connectionString))
            {
                SqlCommand cmd = new("GetStudentsRecord", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    StudentEntity student = new()
                    {
                        StudentId = Convert.ToInt32(rdr["StudentId"]),
                        FirstName = rdr["FirstName"].ToString(),
                        LastName = rdr["LastName"].ToString(),
                        EmailAddress = rdr["EmailAddress"].ToString(),
                        Gender = rdr["Gender"].ToString(),
                        CreateOn = Convert.ToDateTime(rdr["CreateOn"].ToString())
                    };

                    lstStudent.Add(student);
                }

                con.Close();
            }

            return lstStudent;
        }


    }
}
