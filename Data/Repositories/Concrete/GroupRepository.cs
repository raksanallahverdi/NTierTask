using Data.Repositories.Abstract;
using Data.Repositories.Base;
using Core.Entities;
using Data.Contexts;
using Data.UnitOfWork.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Concrete;

public class GroupRepository : Repository<Group>,IGroupRepository
{
    private readonly AppDbContext _context;
    public GroupRepository(AppDbContext context) : base(context)
    {
        _context = context;

    }
    public Group GetStudentsByGroupId(int id)
    {
        return _context.Groups.Include(x => x.Students).FirstOrDefault(x => x.Id == id);
    }
    public Group GetByName(string name)
    {
        return _context.Groups.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());

    }
}
