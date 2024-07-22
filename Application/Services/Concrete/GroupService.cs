using Data.Contexts;
using Data.Repositories.Concrete;
using Data.UnitOfWork.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Entities;
using Application.Services.Abstract;

using System.Threading.Tasks;
using Core.Constants;

namespace Application.Services.Concrete;

public class GroupService:IGroupService
{
    private readonly UnitOfWork _unitOfWork;
    public GroupService()
    {
        _unitOfWork = new UnitOfWork();

    }
    public void GetAllGroups()
    {
        foreach (var group in _unitOfWork.Groups.GetAll()) {
            Console.WriteLine(group);
        } 
    }
    public void GetGroupByName(int id)
    {
       
       _unitOfWork.Groups.Get( id);
    }
    public void AddGroup(Group group)
    {
        _unitOfWork.Groups.Add(group);
    }
    public void RemoveGroup(Group group) { 
    _unitOfWork.Groups.Delete(group);    
    }
    public void UpdateGroup(Group group) { 
    _unitOfWork.Groups.Update(group);
    }

    
    
}
