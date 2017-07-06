using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TaskListApi.Core.Data;
using TaskListApi.Core.Service;
using TaskListApi.Core.Util;
using TaskListApi.Dto;
using TaskListApi.Models;

namespace TaskListApi.Service
{
    public class UserService : IUserService
    {
        IUserRepo repo;
        IObjectBuilder<User, UserDto> builder;

        public UserService(IUserRepo repo, IObjectBuilder<User, UserDto> builder)
        {
            this.repo = repo;
            this.builder = builder;
        }

        public async Task Add(User user)
        {
            var users = await repo.GetAll();
            var usernameClash = users.Select(x => x.username == user.username).ToList();
            if (usernameClash != null && usernameClash.Count > 0) return;
            await repo.Add(builder.ToObject(user));
        }
        public async Task Delete(long id) => await repo.Delete(id);
        public async Task<User> GetByUsername(string username, long userid) => builder.ToObject(await repo.GetByUsername(username, userid));
        public async Task Update(User user) => await repo.Update(builder.ToObject(user));
    }
}