using HugDb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HugDb.Repositories
{
    public class UserRepository
    {
        HugDbContext _context;
        public UserRepository(HugDbContext context)
        {
            _context = context;
        }

        public User GetUser(int id)
        {
            return _context.Users.Single(x => x.Id == id);
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.Take(100).ToList();
        }

        public List<User> GetUserByName(string name)
        {
            // Tik loadinama, duomenys dar neistraukiami
            var users = _context.Users.Where(x => x.FirstName.Equals(name, StringComparison.InvariantCultureIgnoreCase));
            var result = users.ToList(); // IQueryable neigyvendintas sql, duomenys dar neistraukiami
            return result;
        }

        public void Delete(int userId)
        {
            var user = _context.Users.Find(userId);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
