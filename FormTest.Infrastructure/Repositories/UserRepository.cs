using FormTest.Core.Interfaces;
using FormTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormTest.Core.Entities;

namespace FormTest.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public User? GetByEmailAndPassword(string email, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
        public User? GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);


        }
    }
}