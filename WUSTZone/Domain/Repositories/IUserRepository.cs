using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WUSTZone.Domain.Entityies;

namespace WUSTZone.Domain.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// 通过Id获取User
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User类实体</returns>
        public User GetUser(int id);
        /// <summary>
        /// 通过UserName获取User
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User类实体</returns>
        public User GetUser(string userName);
        /// <summary>
        /// 通过账号密码获取User
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User类实体</returns>
        public User GetUser(string userName, string password);
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns>新添加的用户实体</returns>
        public User AddUser(User newUser);
    }
}
