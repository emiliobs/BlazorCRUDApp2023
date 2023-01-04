using Blazor.Shared.Models;

namespace Blazor.Shared.Services
{
    public interface IStudentServices
    {
        IEnumerable<StudentEntity> GetAllStudent();
        void AddStudent(StudentEntity student);
        void UpdateStudent(StudentEntity student);
        void DeleteStudent(int studentId);
    }
}