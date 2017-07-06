using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TaskListApi.Models;

namespace TaskListApi.Core.Service
{
    public interface IUserService
    {
        Task Add(User t);
        Task<User> GetByUsername(string username, long userid);
        Task Delete(long id);
        Task Update(User t);
    }
}