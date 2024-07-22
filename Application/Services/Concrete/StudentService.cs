using Application.Services.Abstract;
using Core.Entities;
using Data.Repositories.Abstract;
using Data.UnitOfWork.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Concrete
{
    public class StudentService:IStudentService
    {
        private readonly UnitOfWork _unitOfWork;

        public StudentService()
        {

            _unitOfWork = new UnitOfWork();
        }
        public void GetAllStudents()
        {
            foreach (var student in _unitOfWork.Students.GetAll())
            {
                Console.WriteLine(student);
            }
        }
        public void GetStudentById(int id)
        {
            _unitOfWork.Students.Get(id);
        }
        public void AddStudent(Student student)
        {
            _unitOfWork.Students.Add(student);
        }
        public void RemoveGroup(Student student)
        {
            _unitOfWork.Students.Delete(student);
        }
        public void UpdateGroup(Student student)
        {
            _unitOfWork.Students.Update(student);
        }
    }
}
