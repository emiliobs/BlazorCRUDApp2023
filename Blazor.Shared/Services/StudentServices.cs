using Blazor.Shared.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Blazor.Shared.Services
{
    public class StudentServices : IStudentServices
    {
        string _connectionString = "Data Source=EMILIO\\EMILIO;Initial Catalog=BLazorCRUD;Integrated Security=True;TrustServerCertificate=True";
        //string _connectionString = string.Empty;
        private readonly IConfiguration _configuration;

        //public StudentServices(IConfiguration configuration)
        //{
        //    _connectionString = _configuration.GetConnectionString("DBConnection");
        //}

        public IEnumerable<StudentEntity> GetAllStudent()
        {
            List<StudentEntity> lstStudent = new List<StudentEntity>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetStudentsRecord", con);
                cmd.CommandType = CommandType.StoredProcedure;

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

        //-- Method for creating new student record
        public void AddStudent(StudentEntity student)
        {
            using SqlConnection con = new(_connectionString);

            SqlCommand cmd = new("AddNewStudent", con)
            {
                CommandType = CommandType.StoredProcedure
            };


            _ = cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
            _ = cmd.Parameters.AddWithValue("@LastName", student.LastName);
            _ = cmd.Parameters.AddWithValue("@EmailAddress", student.EmailAddress);
            _ = cmd.Parameters.AddWithValue("@Gender", student.Gender);

            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();
        }


        public void UpdateStudent(StudentEntity student)
        {
            using SqlConnection con = new(_connectionString);

            SqlCommand cmd = new("UpdateStudentRecord", con)
            {

                CommandType = CommandType.StoredProcedure

            };

            _ = cmd.Parameters.AddWithValue("@StudentId", student.StudentId);
            _ = cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
            _ = cmd.Parameters.AddWithValue("@LastName", student.LastName);
            _ = cmd.Parameters.AddWithValue("@EmailAddress", student.EmailAddress);
            _ = cmd.Parameters.AddWithValue("@Gender", student.Gender);


            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();


        }

        public void DeleteStudent(StudentEntity student)
        {
            using SqlConnection con = new(_connectionString);

            SqlCommand cmd = new("DeleteStudentRecord", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@StudentId", student.StudentId);

            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();

        }

    }
}
