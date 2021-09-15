using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(SqlContext context) : base(context)
        {
        }
        public User GetAllAuthentication(string emailAut, string passwordAut)
        {
            var obj = CurrentSet
                       .Where(x => x.Email == emailAut && x.Password == passwordAut)
                       .FirstOrDefault();
            return obj;
        }
    }
}
