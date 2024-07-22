using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abstract
{
    public interface IStudentService
    {
        public void GetAllStudents() { }
        public void GetStudentById() { }
        public void AddStudent() { }
        public void UpdateStudent() { }
        public void DeleteStudent() { }
    }
}
