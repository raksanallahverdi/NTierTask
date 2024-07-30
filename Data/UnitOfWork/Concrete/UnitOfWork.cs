using Data.Contexts;
using Data.Repositories.Concrete;
using Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.UnitOfWork.Concrete;

public class UnitOfWork:IUnitOfWork
{
    public readonly GroupRepository Groups;
    public readonly StudentRepository Students;
    private readonly AppDbContext _context;
    public UnitOfWork()
    {
        _context = new AppDbContext();

        Groups = new GroupRepository(_context);
        Students = new StudentRepository(_context);
    }
    public void Commit()
    {
        try
        {
            _context.SaveChanges();
        }
        catch (Exception)
        {

            throw;
        }

    }
}
