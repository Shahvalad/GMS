using GMS.Application.Common.Interfaces.Persistance;
using GMS.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Infrastructure.Persistance
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users= new();
        public void Add(User user)
        {
            _users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(u=>u.Email == email);
        }

        public User? GetUserByName(string name)
        {
            return _users.SingleOrDefault(u => String.Equals(u.FirstName, name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
