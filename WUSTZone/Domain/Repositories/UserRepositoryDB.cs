using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WUSTZone.Domain.Entityies;

namespace WUSTZone.Domain.Repositories
{
    /// <summary>
    /// 用户数据库仓储
    /// </summary>
    public class UserRepositoryDB : IUserRepository
    {
        private readonly AppDbContext context;

        // 依赖注入
        public UserRepositoryDB(AppDbContext context)
        {
            this.context = context;
        }

        public User AddUser(User newUser)
        {
            context.Users.Add(newUser);
            context.SaveChanges();
            return newUser;
        }

        public User GetUser(int id)
        {
            return context.Users.Find(id);
        }

        public User GetUser(string userName)
        {
            return context.Users
                .Where(user => user.UserName == userName)
                .FirstOrDefault();
        }

        public User GetUser(string userName, string password)
        {
            return context.Users
                .Where(user => user.UserName == userName && user.Password == password)
                .FirstOrDefault();
        }

        public User UpdateUser(User user)
        {
            var updatedUser = context.Users.Attach(user);
            updatedUser.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return user;
        }
    }
}
