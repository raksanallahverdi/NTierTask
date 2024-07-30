using Application.Services.Abstract;
using Core.Constants;
using Core.Entities;
using Data.Repositories.Abstract;
using Data.UnitOfWork.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Concrete;

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
            Console.WriteLine($"Name: {student.Name} Surname: {student.Surname}");
        }
    }
    public void GetStudentById()
    {
    InputIdSection:
        Messages.InputMessage("id");
        string inputId = Console.ReadLine();
        if (!int.TryParse(inputId, out int id))
        {
            Messages.InvalidInputMessage("id");
            goto InputIdSection;
        }
        Student student = _unitOfWork.Students.Get(id);
        if (student == null)
        {
            Messages.NotFoundMessage("Student");
        }
        else
        {
            Console.WriteLine($"Name: {student.Name} Surname: {student.Surname}");
        }

    }
    public void AddStudent()
    {
    NameInput:
        Messages.InputMessage("name");
        string name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            Messages.InvalidInputMessage("Name");
            goto NameInput;
        }

    SurNameInput:
        Messages.InputMessage("surname");
        string surname = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(surname))
        {
            Messages.InvalidInputMessage("Surname");
            goto SurNameInput;
        }

        Student student = new Student
        {
            Name = name,
            Surname = surname
        };
        _unitOfWork.Students.Add(student);
        Messages.SuccessMessage("Student","Added");
        _unitOfWork.Commit();

    }
    public void RemoveStudent()
    {
    InputIdSection:
        Messages.InputMessage("id");
        string inputId = Console.ReadLine();
        if (!int.TryParse(inputId, out int id))
        {
            Messages.InvalidInputMessage("id");
            goto InputIdSection;
        }

        Student student = _unitOfWork.Students.Get(id);
        if (student == null)
        {
            Messages.NotFoundMessage("Student");
        }
        else
        {
            _unitOfWork.Students.Delete(student);
            Messages.SuccessMessage("Student","Deleted");
        }
        _unitOfWork.Commit();

    }
    public void UpdateStudent()
    {
    InputIdSection:
        Messages.InputMessage("id");
        string inputId = Console.ReadLine();
        if (!int.TryParse(inputId, out int id))
        {
            Messages.InvalidInputMessage("id");
            goto InputIdSection;
        }

        Student student = _unitOfWork.Students.Get(id);
        if (student == null)
        {
            Messages.NotFoundMessage("Student");
            return;
        }

    NameInput:
        Messages.InputMessage("new name");
        string name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            Messages.InvalidInputMessage("Name");
            goto NameInput;
        }

    SurNameInput:
        Messages.InputMessage("new surname");
        string surname = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(surname))
        {
            Messages.InvalidInputMessage("Surname");
            goto SurNameInput;
        }

        student.Name = name;
        student.Surname = surname;
        _unitOfWork.Students.Update(student);
        Messages.SuccessMessage("student","updated");
        _unitOfWork.Commit();
    }
}
